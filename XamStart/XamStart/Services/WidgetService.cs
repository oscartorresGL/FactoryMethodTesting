using System;
using System.Collections.Generic;
using XamStart.Interfaces;
using XamStart.Models;

namespace XamStart.Services
{
    public class WidgetService : IWidgetService
    {
        private List<Widget> widgets;

        public List<Widget> GetWidgets(){
                widgets = new List<Widget>(){
                    new Widget(){
                        firstName = "Fred",
                        lastName = "Jones"
                    },
                    new Widget() {
                        firstName = "Jessie",
                        lastName = "James"
                    }
                };
            return widgets;
        }

        public List<Widget> AddWidgetToMachine(WidgetForAdding widgetForAdding){

            // pretent you sent off widgetForAdding (which is different than a plain widget) and you are getting
            // back a 3rd type of widget you call WidgetForAddingReturn type.  It is different because it uses
            // underscores in the property names.

            // pretend this returnObject is what the API sent back
            if (widgets == null) widgets = new List<Widget>();
            var returnObject = new WidgetForAddingReturn()
            {
                date_Time = DateTime.Now,
                first_Name = "James",
                last_Name = "Smith"
            };
            var convertedWidget = new Widget()
            {
                firstName = returnObject.first_Name,
                lastName = returnObject.last_Name
            };
            if(widgets.Count < 3) 
            widgets.Add(convertedWidget);
            return widgets;
        }
    }
}
