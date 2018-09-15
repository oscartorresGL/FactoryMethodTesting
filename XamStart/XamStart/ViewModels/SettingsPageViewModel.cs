using XamStart.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamStart.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel, ISettingsPageViewModel
    {       

        public SettingsPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory) : base(currentlySelectedFactory)
        {
            Title = "Settings";

        }
        protected override async Task Init()
        {
            IsBusy = true;
            // act like you processed something
            await Task.Delay(2000);
            IsBusy = false;
        }

    }    
}
