using System;

namespace AlimanProject.ExtraClasses
{
    public class HomePages : Page
    {
        public ClipPage Clip { get; set; } = new ClipPage();
        public ConcertPage Concert { get; set; } = new ConcertPage();
        public AlbumPage Album { get; set; } = new AlbumPage();
        public ChanelPage Chanel { get; set; } = new ChanelPage();
    }

    public class ClipPage : Page
    {
    }
    public class ConcertPage : Page
    {
    }
    public class AlbumPage : Page
    {
    }
    public class ChanelPage : Page
    {
    }

    public class Page
    {
        public bool IsCurrentPage { get; set; } = false;
        public ClickedButton Button { get; set; } = new ClickedButton();

        public void Activate ()
        {
            IsCurrentPage = true;
        }

        public void Deactivate ()
        {
            IsCurrentPage = false;
        }
    }
}
