using XamStart.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamStart.Models;
using Newtonsoft.Json.Linq;

namespace XamStart.ViewModels
{
    public class HomePageViewModel : BaseViewModel, IHomePageViewModel
    {
        INavigationService navigationService;
        IWidgetService widgetService;

        public ObservableCollection<Widget> Widgets { get; set; }
        public HomePageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, INavigationService navigationService, IWidgetService widgetService) : base(currentlySelectedFactory)
        {
            Title = "My Home!!!";
            this.navigationService = navigationService;
            this.widgetService = widgetService;
            AddWidgetCommand = new Command(() => AddWidget());
            ShowWidgetsCommand = new Command(() => ShowWidgets());
            Widgets = new ObservableCollection<Widget>();
        }
        private void AddWidget()
        {
            // lets pretend we added a new widget using a form on the home page
            var newWidget = new Widget()
            {
                firstName = "Little",
                lastName = "Abner"
            };
            // now lets add it to the machine (just pretend the machine is something important we have to add it to)
            var newWidgetList = widgetService.AddWidgetToMachine(newWidget);
            Widgets.Clear();
            newWidgetList.ForEach(x => Widgets.Add(x));

        }
        private void ShowWidgets(){
            Widgets.Clear();
            var returnWidgets = widgetService.GetWidgets();
            returnWidgets.ForEach(x => Widgets.Add(x));
        }
        public ICommand ShowWidgetsCommand { get; set; }
        public ICommand AddWidgetCommand { get; set; }
    }    
}
