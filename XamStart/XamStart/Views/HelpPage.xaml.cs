using XamStart.Interfaces;
using XamStart.Views;
using Xamarin.Forms;
using Unity;

namespace XamStart.Views
{    
    public partial class HelpPage : ContentPageBase, IHelpPage
    {
        public HelpPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            // Cannot be depended on in Android when navigating back to page
            base.OnAppearing();
            Track("Help Page");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}