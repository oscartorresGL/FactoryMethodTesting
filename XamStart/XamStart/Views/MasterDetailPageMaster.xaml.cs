using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamStart.Views
{
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            //BindingContext = new MasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}