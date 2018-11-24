using MediaTracker.Common;
using MediaTracker.Models;
using System.Windows.Input;

namespace MediaTracker.Home
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        private ICommand searchCommand;
        private string searchText;

        public string Name => "Home";

        public ICommand SearchClick
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(param => Search());

                return searchCommand;
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (value != searchText)
                {
                    searchText = value;
                    OnPropertyChanged("SearchText");
                }
            }
        }

        private void Search()
        {
            //search movies for their text
        }
    }
}