using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using XamStart.Interfaces;
using XamStart.Models;

namespace XamStart.Factories
{
    public abstract class HttpObjFactoryBase
    {
        public abstract IHttpObj CreateWidget(IHttpObj httpObj);
        public abstract IHttpObj CreateWidget(string json);

        public abstract List<IHttpObj> CreateWidgetList(string json);


        /// <summary>
        /// not used but shows how you could use this type of method
        /// that allows you to change base behavior of all ineriting objects assuming
        /// IHttObj had public methods which it doesn't
        /// </summary>
        public IHttpObj GetWidget<T>(T item)
        {
            IHttpObj myHttpObj;
            if (typeof(T) == typeof(string)){
                // this is json
                myHttpObj = this.CreateWidget(item as string);
            } else {
                myHttpObj = this.CreateWidget(item as IHttpObj);
            }

            // do stuff you want to do to ALL types of widgets
            return myHttpObj;
        }

        public List<IHttpObj> GetWidgets(string json){
            List<IHttpObj> x = this.CreateWidgetList(json);
            return x;
        }

    }
}
