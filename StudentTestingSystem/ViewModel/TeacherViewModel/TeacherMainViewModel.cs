using StudentTestingSystem.Command;
using StudentTestingSystem.View.TeacherView;
using StudentTestingSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace StudentTestingSystem.ViewModel.TeacherViewModel
{
    internal class TeacherMainViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ThemeCommand { get; private set; }
        public ICommand TestCommand { get; private set; }
        public ICommand WorkCommand { get; private set; }
        public TeacherMainViewModel()
        {
            CloseCommand = new RelayCommand(CloseCommandExecute, CanExecuteCommand);
            ExitCommand = new RelayCommand(ExitCommandExecute, CanExecuteCommand);
            ThemeCommand = new RelayCommand(ThemeCommandExecute, CanExecuteCommand);
            TestCommand = new RelayCommand(TestCommandExecute, CanExecuteCommand);
            WorkCommand = new RelayCommand(WorkCommandExecute, CanExecuteCommand);
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
        private void WorkCommandExecute()
        {
            TeacherWorkView teacherWorkView = new();
            OpenNextWindow(teacherWorkView);
        }
        private void ThemeCommandExecute()
        {
            TeacherThemeView teacherThemeView = new();
            OpenNextWindow(teacherThemeView);
        }
        private void TestCommandExecute()
        {
            TeacherTestView teacherTestView = new();
            OpenNextWindow(teacherTestView);
        }
    }
}
