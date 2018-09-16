using System;
using XamStart.Interfaces;

namespace XamStart.Models
{
    /// <summary>
    /// Notice this Widget has the added property "dateTime"
    /// Widget used SENDING to the AddWidgetToMachine API
    /// </summary>
    public class WidgetVariant1 : IHttpObj
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateTime { get; set; }
    }
}
