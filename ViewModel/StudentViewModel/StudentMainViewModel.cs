using StudentTestingSystem.Command;
using StudentTestingSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StudentTestingSystem.View.StudentView;

namespace StudentTestingSystem.ViewModel.StudentViewModel
{
    internal class StudentMainViewModel:BaseViewModel
    {
        public ICommand TestCommand { get; private set; }
        public ICommand MarkCommand { get; private set;}
        public ICommand CloseCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public StudentMainViewModel()
        {
            TestCommand = new RelayCommand(TestCommandExecute, CanExecuteCommand);
            MarkCommand = new RelayCommand(MarkCommandExecute, CanExecuteCommand);
            CloseCommand = new RelayCommand(CloseCommandExecute, CanExecuteCommand);
            ExitCommand = new RelayCommand(ExitCommandExecute, CanExecuteCommand);
        }
        private void CloseCommandExecute()
        {
            Application.Current.Shutdown();
        }
        private void ExitCommandExecute()
        {
            AuthView authView = new();
            OpenNextWindow(authView);
        }
        private void TestCommandExecute()
        {
            StudentTestView studentTestView = new();
            OpenNextWindow(studentTestView);
        }
        private void MarkCommandExecute()
        {
            StudentTestView studentTestView = new();
            OpenNextWindow(studentTestView);
        }
    }
}

