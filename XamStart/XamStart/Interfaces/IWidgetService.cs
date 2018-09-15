using System;
using System.Collections.Generic;
using XamStart.Models;

namespace XamStart.Interfaces
{
    public interface IWidgetService
    {
        List<Widget> GetWidgets();
        List<Widget> AddWidgetToMachine(WidgetForAdding widgetForAdding);
    }
}
