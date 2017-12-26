using Xamarin.Forms;

namespace Prism700p5Try.Views
{
    public partial class StaffListPage : ContentPage
    {
        public StaffListPage()
        {
            InitializeComponent();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}
