using MediaTracker.Common;
using MediaTracker.Models;

namespace MediaTracker.Home
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Home";
    }
}