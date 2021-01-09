using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using AlimanProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AlimanProject.Services;
using System.Linq;
using Microsoft.AspNetCore.Authentication;

namespace AlimanProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class SigninModel : PageModel
    {
        private readonly IVerification _verificationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;

        public SigninModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IVerification verificationService,
                ILogger<RegisterModel> logger)
        {
            _verificationService = verificationService;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public Input InputModel { get; set; }

        private InputModelRegister InputRegister { get; set; }

        private InputModelLogin InputLogin { get; set; }


        public class Input
        {
            [Required(ErrorMessage = "Введите номер телефона")]
            [Display(Name = "Номер телефона")]
            public string PhoneNumber { get; set; }
        }

        public class InputModelRegister
        {
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [RegularExpression("\\+\\d+", ErrorMessage = "Write the phone number in the international format without spaces.")]
            public string FullPhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Channel")]
            public string Channel { get; set; }
        }


        public class InputModelLogin
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {

            // Clear the existing external cookie to ensure a clean login process
            HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");

            InputLogin = new InputModelLogin();
            InputRegister = new InputModelRegister();

            // Username and password from phone number
            InputLogin.Username = InputModel.PhoneNumber;
            InputLogin.Password = InputModel.PhoneNumber;
            InputRegister.UserName = InputModel.PhoneNumber;
            InputRegister.Password = InputModel.PhoneNumber;
            InputRegister.FullPhoneNumber = InputModel.PhoneNumber; 

            // try login
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(InputLogin.Username, InputLogin.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    // try verify
                    var user = new ApplicationUser { UserName = InputRegister.UserName, PhoneNumber = InputRegister.FullPhoneNumber, Verified = false };

                    var verification =
                        await _verificationService.StartVerificationAsync(user.PhoneNumber, "sms");

                    if (verification.IsValid)
                    {
                        HttpContext.Session.SetString("_UserId", user.Id);
                        await _signInManager.PasswordSignInAsync(InputRegister.UserName, InputRegister.Password, false, lockoutOnFailure: true);
                        return LocalRedirect(Url.Content($"~/Identity/Account/Verify/?phoneNumber={user.PhoneNumber}&returnUrl={returnUrl}"));
                    }

                    await _userManager.DeleteAsync(user);

                    foreach (var error in verification.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }

                // try register
                var userRegister = new ApplicationUser { UserName = InputRegister.UserName, PhoneNumber = InputRegister.FullPhoneNumber, Verified = false };
                var resultRegister = await _userManager.CreateAsync(userRegister, InputRegister.Password);
                if (resultRegister.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var verification =
                        await _verificationService.StartVerificationAsync(userRegister.PhoneNumber, "sms");

                    if (verification.IsValid)
                    {
                        HttpContext.Session.SetString("_UserId", userRegister.Id);
                        await _signInManager.PasswordSignInAsync(InputRegister.UserName, InputRegister.Password, false, lockoutOnFailure: true);
                        return LocalRedirect(Url.Content($"~/Identity/Account/Verify/?phoneNumber={userRegister.PhoneNumber}&returnUrl={returnUrl}"));
                    }

                    await _userManager.DeleteAsync(userRegister);

                    foreach (var error in verification.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
                foreach (var error in resultRegister.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
