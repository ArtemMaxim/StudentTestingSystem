using Microsoft.EntityFrameworkCore;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    public class AdminUsersViewModel: BaseViewModel
    {
        private readonly TestContext context;
        public ICommand RegCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }
        private User selectedUser;
        public AdminUsersViewModel()
        {
            context = new();
            Users = new ObservableCollection<User>(context.Users.ToList());
            Roles = new ObservableCollection<Role>(context.Roles.ToList());
            Groups = new ObservableCollection<Group>(context.Groups.ToList());
            RegCommand = new RelayCommand(ExecuteRegCommand, CanExecuteCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteSelectCommand);
            EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteSelectCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
        }
        private void ExecuteBackCommand()
        {
            AdminMainView adminMainView = new AdminMainView();
            OpenNextWindow(adminMainView);
        }
        private void ExecuteDeleteCommand()
        {
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить пользователя {selectedUser.UserLogin}?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Users.Where(u => u.IdUser == selectedUser.IdUser).ExecuteDelete();
                Users.Remove(selectedUser);
                context.SaveChanges();
            }
        }
        private void ExecuteEditCommand()
        {
            AdminEditView adminEditView = new(this);
            OpenNextWindow(adminEditView);
        }
        private bool CanExecuteSelectCommand()
        {
            if(selectedUser!=null)
                return true;
            else
                return false;
        }
        private void ExecuteRegCommand()
        {
            AdminRegView adminRegView = new();
            OpenNextWindow(adminRegView);
        }
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Role> roles;
        public ObservableCollection<Role> Roles
        {
            get => roles;
            set
            {
                roles = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set
            {
                groups = value;
                OnPropertyChanged();
            }
        }

    }
}
