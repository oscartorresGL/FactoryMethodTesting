using CommonServiceLocator;
using XamStart.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Unity;
using System.Windows.Input;

namespace XamStart.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly ICurrentlySelectedFactory currentlySelectedFactory;
        bool isBusy = false;
        string title = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoadedCommand { protected set; get; }
        public BaseViewModel(ICurrentlySelectedFactory currentlySelectedFactory)
        {
            this.currentlySelectedFactory = currentlySelectedFactory;
            LoadedCommand = new Command(async () => {
                await Init();
            });
        }

        //protected abstract Task Init();
        protected virtual async Task Init()
        {
            await DummyTask();
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public async Task DummyTask()
        {
            await Task.Delay(0);
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
