using System;
namespace XamStart.Models
{
    public class Widget : BaseINotifyModel
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
