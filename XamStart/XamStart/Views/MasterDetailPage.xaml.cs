using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;
using XamStart.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamStart.Models;

namespace XamStart.Views
{
    public partial class MDPage : MasterDetailPage, IMDPage
    {
        public Page MDPDetail;  // only used in NavigationService reference
        public MDPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MDPDetail = this.Detail;  // only used in NavigationService reference
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        public bool DoBack
        {
            // refer to:  https://stackoverflow.com/questions/28767357/prevent-closing-by-back-button-in-xamarin-forms-on-android
            get
            {
                MasterDetailPage mainPage = App.Current.MainPage as MasterDetailPage;

                if (mainPage != null)
                {
                    bool canDoBack = mainPage.Detail.Navigation.NavigationStack.Count > 1 || mainPage.IsPresented;

                    // we are on a top level page and the Master menu is NOT showing
                    if (!canDoBack)
                    {
                        // don't exit the app just show the Master menu page
                        mainPage.IsPresented = true;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
        }
    }

}