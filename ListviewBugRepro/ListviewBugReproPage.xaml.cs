using System.Linq;
using Xamarin.Forms;

namespace ListviewBugRepro
{
    public partial class ListviewBugReproPage : ContentPage
    {
        public ListviewBugReproPage()
        {
            InitializeComponent();

            this.TheListView.ItemsSource = Enumerable.Range(1, 5000).Select(i => i.ToString());
        }
    }
}
