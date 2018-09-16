using System;
using XamStart.Interfaces;

namespace XamStart.Models
{
    /// <summary>
    /// Widget used in most of my viewmodels
    /// </summary>
    public class Widget : BaseINotifyModel, IHttpObj
    {

        private string _firstName;

        public string firstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;

        public string lastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

    }
}
