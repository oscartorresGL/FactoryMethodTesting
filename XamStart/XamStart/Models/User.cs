using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamStart.Models
{
    public class User
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public ErrorItem Error {get; set;}
    }
}
