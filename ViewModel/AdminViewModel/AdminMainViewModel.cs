using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    internal class AdminMainViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; private set; }
        public ICommand ExitCommand {  get; private set; }
        public ICommand UserCommand { get; private set; }
        public ICommand GroupCommand { get; private set; }
        public ICommand DisciplineCommand {  get; private set; }
        public AdminMainViewModel() 
        {
            CloseCommand = new RelayCommand(CloseCommandExecute, CanExecuteCommand);
            ExitCommand = new RelayCommand(ExitCommandExecute, CanExecuteCommand);
            UserCommand = new RelayCommand(UserCommandExecute, CanExecuteCommand);
            GroupCommand = new RelayCommand(GroupCommandExecute, CanExecuteCommand);
            DisciplineCommand = new RelayCommand(DisciplineCommandExecute, CanExecuteCommand);
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
        private void DisciplineCommandExecute()
        {
            AdminDisciplineView adminDisciplineView = new();
            OpenNextWindow(adminDisciplineView);
        }
        private void UserCommandExecute()
        {
            AdminUsersView adminUsersView = new();
            OpenNextWindow(adminUsersView);
        }
        private void GroupCommandExecute()
        {
            AdminGroupView adminGroupView = new();
            OpenNextWindow(adminGroupView);
        }
    }
}
