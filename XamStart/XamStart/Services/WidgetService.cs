using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamStart.Factories;
using XamStart.Helpers;
using XamStart.Interfaces;
using XamStart.Models;
using Unity;

namespace XamStart.Services
{
    public class WidgetService : IWidgetService
    {
        private List<Widget> widgets;

        public WidgetService(){
            widgets = new List<Widget>();
        }

        public List<Widget> GetWidgets(){


            // pretend you just called an API and got this response
            var response = @"[{'firstName':'Fred','lastName':'Jones'},{'firstName':'Jessie','lastName':'Smith'}]";
            HttpObjFactoryBase responseFactory = (HttpObjFactoryBase)ViewModelLocator.Container.Resolve<IResponseHttpObjFactory>();
            var tempWidgets = responseFactory.GetWidgets(response);
            tempWidgets.ForEach(x => widgets.Add(x as Widget));
            return widgets;
        }

        public List<Widget> AddWidgetToMachine(Widget newWidget){
            // first lets get an object ready to send to our pretend API.  This endpong needs
            // a Widget with the added property "dateTime"
            HttpObjFactoryBase sendFactory = (HttpObjFactoryBase)ViewModelLocator.Container.Resolve<ISendHttpObjFactory>();
            IHttpObj widget = sendFactory.GetWidget(newWidget);

            // now that our object is ready, lets send it to our pretend API (we don't actually use the object above, just pretend we do).
            // lets now pretend the next line is the response from the API.
             var response = @"{'first_Name':'Izzy','last_Name':'Gonzales'}";
            // Unfortunately for us,
            // the response is in a different format than most of our other models.  The response has
            // the property names with underscores! So we'll send it to our factories to get back a proper type we can use
            HttpObjFactoryBase responseFactory = (HttpObjFactoryBase)ViewModelLocator.Container.Resolve<IResponseHttpObjFactory>();
            var responseWidget = (Widget)responseFactory.GetWidget<string>(response);


            if (widgets == null) widgets = new List<Widget>();
            if (widgets.Count < 3) 
                widgets.Add(responseWidget);
            return widgets;
        }

    }
}
