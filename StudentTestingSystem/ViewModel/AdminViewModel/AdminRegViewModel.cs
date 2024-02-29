using Microsoft.VisualBasic.Logging;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    public class AdminRegViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand AddUserCommand { get; private set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;   
                OnPropertyChanged();
            }
        }
        public string Surame
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
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
        private string name;
        private string surname;
        private string login;
        private string password;
        private Group? group;
        private Role role;
        public AdminRegViewModel() 
        {
            context = new();
            Users = new ObservableCollection<User>(context.Users.ToList());
            Roles = new ObservableCollection<Role>(context.Roles.ToList());
            Groups = new ObservableCollection<Group>(context.Groups.ToList());
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            AddUserCommand = new RelayCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
        }
        private void BackCommandExecute()
        {
            AdminUsersView adminUsersView = new();
            OpenNextWindow(adminUsersView);
        }
        private void ExecuteAddUserCommand()
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.UserLogin == login);
                if (user == null)
                {
                    var u = new User { UserName = name, UserSurname = surname, UserLogin = login, UserPassword = password, GroupId = group.IdGroup, RoleId = role.IdRole };
                    context.Users.Add(u);
                    context.SaveChanges();
                    MessageBox.Show("Пользователь успешно зарегестрирован");
                    AdminUsersView adminUsersView = new();
                    OpenNextWindow(adminUsersView);
                }
                else
                    MessageBox.Show("Пользователь с таким именем уже существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}","Ошибка!");
            }
        }
        private bool CanExecuteAddUserCommand()
        {
            return (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(role.RoleName));
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
