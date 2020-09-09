using System;

namespace AlimanProject.ExtraClasses
{
    public class AccountPages
    {
        public EditPage Edit { get; set; } = new EditPage();
        public AddPage Add { get; set; } = new AddPage();
        public ChatPage Chat { get; set; } = new ChatPage();
        public CallPage Call { get; set; } = new CallPage();
        public PhotoPage Photo { get; set; } = new PhotoPage();
        public ContactPage Contact { get; set; } = new ContactPage();
        public GuestPage Guest { get; set; } = new GuestPage();
    }

    public class EditPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();
    }
    public class AddPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();

    }
    public class ChatPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();

    }
    public class CallPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();

    }
    public class PhotoPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();

    }

    public class ContactPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();
    }

    public class GuestPage
    {
        public ClickedButton Button { get; set; } = new ClickedButton();
    }

    public class ClickedButton
    {
        public bool IsClicked { get; set; }
        public string Active { get; set; }
        public string NotActive { get; set; }

        public string GetValue ()
        {
            if (IsClicked)
            {
                return Active;
            } else
            {
                return NotActive;
            }
        }

        public void Activate ()
        {
            IsClicked = true;
        }
    }

}
