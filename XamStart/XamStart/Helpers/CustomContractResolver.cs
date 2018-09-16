using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using XamStart.Interfaces;

namespace XamStart.Helpers
{
    public class CustomContractResolver : DefaultContractResolver, ICustomContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public CustomContractResolver(Dictionary<string,string> dict)
        {
            this.PropertyMappings = dict;
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out string resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}
