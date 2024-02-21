using Microsoft.VisualBasic.Logging;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.TeacherViewModel
{
    internal class TeacherWorkViewModel:BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
      
        public TeacherWorkViewModel()
        {
            context = new();
            Works = new ObservableCollection<Work>(context.Works.ToList());
            Users = new ObservableCollection<User>(context.Users.ToList());
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            Tests = new ObservableCollection<Test>(context.Tests.ToList());
            Groups = new ObservableCollection<Group>(context.Groups.ToList());
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
        }
        private void ExecuteBackCommand()
        {
            TeacherMainView teacherMainView = new();
            OpenNextWindow(teacherMainView);
        }
        private void ExecuteSeletionCommand()
        {
             
        }
        private Group selectedGroup;
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Work> works;
        public ObservableCollection<Work> Works
        {
            get => works;
            set
            {
                works = value;
                OnPropertyChanged();
            }
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
        private ObservableCollection<Test> tests;
        public ObservableCollection<Test> Tests
        {
            get => tests;
            set
            {
                tests = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Theme> themes;
        public ObservableCollection<Theme> Themes
        {
            get => themes;
            set
            {
                themes = value;
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
