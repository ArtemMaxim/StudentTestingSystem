using Microsoft.EntityFrameworkCore;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.StudentView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.StudentViewModel
{
    public class StudentTestViewModel: BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand GoCommand { get; private set; }

        public StudentTestViewModel()
        {
            context = new();

            Tests = new ObservableCollection<Test>(context.Tests.ToList());
            TimeString = new ObservableCollection<string>();
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
            GoCommand = new RelayCommand(ExecuteGoCommand, CanExecuteSelectCommand);
        }
        private void ExecuteGoCommand()
        {
            StudentTestingView studentTestingView = new(this);
            OpenNextWindow(studentTestingView);
        }
        private bool CanExecuteSelectCommand()
        {
            if (selectedTest != null)
                return true;
            else
                return false;
        }
        private void ExecuteBackCommand()
        {
            StudentMainView teacherMainView = new();
            OpenNextWindow(teacherMainView);
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
        private Test selectedTest;
        public Test SelectedTest
        {
            get => selectedTest;
            set
            {
                selectedTest = value;
                OnPropertyChanged();
            }
        }
        private Theme selectedTheme;
        public Theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                selectedTheme = value;
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
        private ObservableCollection<string> timeString;
        public ObservableCollection<string> TimeString
        {
            get => timeString;
            set
            {
                timeString = value;
                OnPropertyChanged();
            }
        }
    }
}

