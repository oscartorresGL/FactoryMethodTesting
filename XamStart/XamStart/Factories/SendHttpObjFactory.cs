using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamStart.Interfaces;
using XamStart.Models;

namespace XamStart.Factories
{
    public class SendHttpObjFactory : HttpObjFactoryBase, ISendHttpObjFactory
     {
        public override IHttpObj CreateWidget(string json)
        {
            throw new NotImplementedException();
        }
        public override IHttpObj CreateWidget(IHttpObj httpObj)
        {
            var x = new WidgetVariant1()
            {
                firstName = (httpObj as Widget).firstName,
                lastName = (httpObj as Widget).lastName,
                dateTime = DateTime.Now
            };

            return x;
        }

        public override List<IHttpObj> CreateWidgetList(string json)
        {
            throw new NotImplementedException();
        }
    }
}
