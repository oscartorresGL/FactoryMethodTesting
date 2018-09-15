using System;
using System.Collections.Generic;
using System.Text;

namespace XamStart.Models
{
    public class ErrorItem
    {
        public string date { get; set; }
        public string issue { get; set; }
        public bool isHTML { get; set; }

        public override string ToString()
        {
            return $"{date}: {issue}";
        }
    }
    
    public class Errors
    {
        public List<ErrorItem> ErrorItems { get; set; }
        public string HostName { get; set; }
    }
}
