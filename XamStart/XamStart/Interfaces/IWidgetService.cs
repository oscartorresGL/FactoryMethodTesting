using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using XamStart.Models;

namespace XamStart.Interfaces
{
    public interface IWidgetService
    {
        List<Widget> GetWidgets();
        List<Widget> AddWidgetToMachine(Widget newWidget);
    }
}
