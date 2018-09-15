using XamStart.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamStart.Interfaces;
using System.Threading.Tasks;
using XamStart.Models;

namespace XamStart.ViewModels
{
    public class MasterDetailPageMasterViewModel : BaseViewModel, IMasterDetailPageMasterViewModel
    {
        public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }
        public MasterDetailPageMasterViewModel(ICurrentlySelectedFactory currentlySelectedFactory) : base(currentlySelectedFactory)
        {
            Title = "Master";
            MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
                {
                    new MasterDetailPageMenuItem { Id = 0, Title = "Home", TargetType = typeof(Home)},
                    new MasterDetailPageMenuItem { Id = 1, Title = "Logout", TargetType = typeof(LogoutPage)},
                    new MasterDetailPageMenuItem { Id = 1, Title = "Settings", TargetType = typeof(SettingsPage)},
                    new MasterDetailPageMenuItem { Id = 1, Title = "Help", TargetType = typeof(HelpPage)}
                    
                });
        }

        
    }
}
