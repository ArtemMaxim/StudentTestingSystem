using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.TeacherViewModel
{
    class TeacherAddTestViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand AddTestCommand { get; private set; }
        public TimeOnly Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged();
            }
        }
        public Theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                selectedTheme = value;
                OnPropertyChanged();
            }
        }
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        private int id;
        private TimeOnly time;
        private Theme selectedTheme;
        public TeacherAddTestViewModel()
        {
            context = new();
            Tests = new ObservableCollection<Test>(context.Tests.ToList());
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            SelectedTheme = Themes.First();
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            AddTestCommand = new RelayCommand(ExecuteAddTestCommand, CanExecuteAddThemeCommand);
        }
        private void BackCommandExecute()
        {
            TeacherThemeView adminUsersView = new();
            OpenNextWindow(adminUsersView);
        }
        private void ExecuteAddTestCommand()
        {
            try
            {
                var test = context.Tests.FirstOrDefault(t => t.IdTest== Id);
                if (test == null)
                {
                    var t = new Test { ThemeID = selectedTheme.IdTheme, TestTime = time };
                    context.Tests.Add(t);
                    context.SaveChanges();
                    MessageBox.Show("Тест успешно создан");
                    TeacherTestView teacherTestView = new();
                    OpenNextWindow(teacherTestView);
                }
                else
                    MessageBox.Show("Тест уже существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
            }
        }
        private bool CanExecuteAddThemeCommand()
        {
            return !string.IsNullOrEmpty(selectedTheme.ThemeName) && !string.IsNullOrEmpty(time.ToString());
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
    }
}
