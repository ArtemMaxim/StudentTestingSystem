using Microsoft.EntityFrameworkCore;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    public class AdminEditViewModel : BaseViewModel
    {
   
        public AdminEditViewModel(AdminUsersViewModel viewModel)
        {
            context = new();
            Id = viewModel.SelectedUser.IdUser;
            SelectedUser = viewModel.SelectedUser;
            SelectedRole = viewModel.SelectedUser.Role;
            Roles = viewModel.Roles;
            Group = viewModel.SelectedUser.Group;
            Groups = viewModel.Groups;
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            EditUserCommand = new RelayCommand(ExecuteEditUserCommand, CanExecuteEditUserCommand);
        }

        private User selectedUser;
        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand EditUserCommand { get; private set; }
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
      
        public Group? Group
        {
            get => group;
            set
            {
                group = value;
                OnPropertyChanged();
            }
        }


        public Role SelectedRole
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged();
            }
        }
        private int id;
        private Group? group;
        private Role role;
      
        private void BackCommandExecute()
        {
            AdminUsersView adminUsersView = new();
            OpenNextWindow(adminUsersView);
        }
        private void ExecuteEditUserCommand()
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.IdUser == id);
                if (user != null)
                {
                    user.UserName = SelectedUser.UserName;
                    user.UserSurname = SelectedUser.UserSurname;
                    user.UserLogin = SelectedUser.UserLogin;
                    user.UserPassword = SelectedUser.UserPassword;
                    user.GroupId = group.IdGroup;
                    user.RoleId = role.IdRole;
                    context.Users.Update(user);
                    context.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    AdminUsersView adminUsersView = new();
                    OpenNextWindow(adminUsersView);
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
                Debug.WriteLine(ex.Message);
            }
        }
        private bool CanExecuteEditUserCommand()
        {
            return (!string.IsNullOrEmpty(selectedUser.UserName) && !string.IsNullOrEmpty(selectedUser.UserSurname)
                && !string.IsNullOrEmpty(selectedUser.UserLogin) && !string.IsNullOrEmpty(selectedUser.UserPassword) 
                && !string.IsNullOrEmpty(SelectedRole.RoleName));
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
