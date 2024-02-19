using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTestingSystem.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void OpenNextWindow(Window newwindow)
        {
            App.Current.MainWindow.Close();
            App.Current.MainWindow = newwindow;
            newwindow.Show();
        }
        protected bool CanExecuteCommand()
        {
            return true;
        }
    }
}
