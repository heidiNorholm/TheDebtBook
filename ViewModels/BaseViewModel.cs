using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DebtBook.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void RaisePropertyChanged(params string[] properties)
        {
            foreach (var propertyName in properties)
            {
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
