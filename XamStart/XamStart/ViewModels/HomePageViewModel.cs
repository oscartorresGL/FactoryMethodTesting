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
            // lets pretend we have this widget we need to add to some machine. 
            // Unfortunately the API that accepts the widget won't take a normal widget because it require a DateTime value
            // So we had to create a similar model just to add the DateTime property, and we called it WidgetForAdding
            var fakeWidgetForAdding = new WidgetForAdding(); // lets not worry about actually adding properties to it because they aren't used anyway
            var newListofWidgets = widgetService.AddWidgetToMachine(fakeWidgetForAdding);
            Widgets.Clear();
            newListofWidgets.ForEach(x => {

                Widgets.Add(x);
            });
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
