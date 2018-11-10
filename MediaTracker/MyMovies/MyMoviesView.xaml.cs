using System.Collections.Generic;
using System.Windows.Controls;

namespace MediaTracker.MyMovies
{
    /// <summary>
    /// Interaction logic for MyMoviesView.xaml
    /// </summary>
    public partial class MyMoviesView : UserControl
    {
        public MyMoviesView()
        {
            InitializeComponent();
        }

        public List<MovieWatch> GetMovies()
        {
            return new List<MovieWatch>
            {
                new MovieWatch{ Id=1, MovieId=5, WatchNumber=1},
                new MovieWatch{ Id=2, MovieId=5381, WatchNumber=1}
            };
        }
    }
}