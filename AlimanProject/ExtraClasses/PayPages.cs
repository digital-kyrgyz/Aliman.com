using System;

namespace AlimanProject.ExtraClasses
{
    public class PayPages : Page
    {
        public StorePage Store { get; set; } = new StorePage();
        public MoviePage Movie { get; set; } = new MoviePage();
        public TvPage Tv { get; set; } = new TvPage();
        public AdsPage Ads { get; set; } = new AdsPage();
    }

    public class StorePage : Page
    {
    }
    public class MoviePage : Page
    {
    }
    public class TvPage : Page
    {
    }
    public class AdsPage : Page
    {
    }
}
