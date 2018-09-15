using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using XamStart.Interfaces;
using Xamarin.Forms;

namespace XamStart.ViewModels
{
    public class ErrorPageViewModel : BaseViewModel, IErrorPageViewModel
    {
        HtmlWebViewSource htmlSource;
        public HtmlWebViewSource HTMLSource
        {
            get { return htmlSource; }
            set { SetProperty(ref htmlSource, value); }
        }
        
        public ErrorPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, IPlatformStuff platformStuff) : base(currentlySelectedFactory)
        {
            Title = "Error";
            IsBusy = false;
            HTMLSource = HTMLSource ?? new HtmlWebViewSource();
            HTMLSource.BaseUrl = platformStuff.GetBaseUrl();
            //HTMLSource.BaseUrl = DependencyService.Get<IPlatformStuff>().GetBaseUrl();
            HTMLSource.Html = currentlySelectedFactory.SelectedUser.Error.issue;
            currentlySelectedFactory.SelectedUser.Error = null;            
        }        
    }
}