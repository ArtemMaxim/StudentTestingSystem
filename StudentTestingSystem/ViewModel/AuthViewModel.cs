using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StudentTestingSystem.View;
using StudentTestingSystem.View.AdminView;
using StudentTestingSystem.View.TeacherView;
using StudentTestingSystem.View.StudentView;
using System.Diagnostics;

namespace StudentTestingSystem.ViewModel
{
    public class AuthViewModel : BaseViewModel 
    {
        private readonly TestContext context;
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
        private string login;
        private string password;
        public ICommand EnterCommand{ get; private set; }
        public ICommand CloseCommand{ get; private set; }
        public AuthViewModel()
        {
            context = new TestContext();
            EnterCommand = new RelayCommand(ExecuteEnterCommand, CanExecuteEnterCommand);
            CloseCommand = new RelayCommand(ExecuteCloseCommand, CanExecuteCommand);
        }
        private void ExecuteEnterCommand()
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.UserLogin == login && u.UserPassword == password);
                if (user != null)
                {
                    Window window = null;
                    switch (user.RoleId)
                    {
                        case 1:
                            {
                                window = new AdminMainView();
                                break;
                            }
                        case 2:
                            {
                                window = new TeacherMainView();
                                break;
                            }
                        case 3:
                            {
                                window = new StudentMainView();
                                break;
                            }
                    }
                    OpenNextWindow(window);
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Ошибка при выполнении запроса" + ex.Message, "Ошибка подключения к БД");
            }
        }
        private void ExecuteCloseCommand()
        {
            Application.Current.Shutdown();
        }
        private bool CanExecuteEnterCommand()
        {
            return !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password);
        }

    }
}
