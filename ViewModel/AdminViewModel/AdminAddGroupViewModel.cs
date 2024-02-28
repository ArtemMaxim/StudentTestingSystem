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
    internal class AdminAddGroupViewModel: BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand AddGroupCommand { get; private set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string name;
        public AdminAddGroupViewModel()
        {
            context = new();
            Groups = new ObservableCollection<Group>(context.Groups.ToList());
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            AddGroupCommand = new RelayCommand(ExecuteAddGroupCommand, CanExecuteAddGroupCommand);
        }
        private void BackCommandExecute()
        {
            AdminGroupView adminGroupView = new();
            OpenNextWindow(adminGroupView);
        }
        private void ExecuteAddGroupCommand()
        {
            try
            {
                var group = context.Groups.FirstOrDefault(g => g.GroupName == name);
                if (group == null)
                {
                    var g = new Group { GroupName = name};
                    context.Groups.Add(g);
                    context.SaveChanges();
                    MessageBox.Show("Группа успешна зарегестрирована");
                    AdminGroupView adminGroupView = new();
                    OpenNextWindow(adminGroupView);
                }
                else
                    MessageBox.Show("Группа с таким названием уже существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
            }
        }
        private bool CanExecuteAddGroupCommand()
        {
            return !string.IsNullOrEmpty(name);
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

