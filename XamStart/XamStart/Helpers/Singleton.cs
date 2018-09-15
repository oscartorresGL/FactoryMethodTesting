using System;
using System.Collections.Generic;
using System.Text;

namespace XamStart.Helpers
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance = new T();

        private Singleton() { }

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
