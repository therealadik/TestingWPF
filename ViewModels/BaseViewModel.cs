using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Testing.ViewModels
{
    /// <summary>
    /// Базовый класс для ViewModel с реализацией INotifyPropertyChanged.
    /// </summary>

    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
