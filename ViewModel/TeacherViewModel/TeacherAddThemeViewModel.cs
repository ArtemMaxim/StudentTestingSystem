using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.TeacherViewModel
{
    internal class TeacherAddThemeViewModel:BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand AddThemeCommand { get; private set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public Discipline Discipline
        {
            get => discipline;
            set
            {
                discipline = value;
                OnPropertyChanged();
            }
        }

        private string name;
        private Discipline discipline;
        public TeacherAddThemeViewModel()
        {
            context = new();
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            Disciplines = new ObservableCollection<Discipline>(context.Disciplines.ToList());   
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            AddThemeCommand = new RelayCommand(ExecuteAddThemeCommand, CanExecuteAddThemeCommand);
        }
        private void BackCommandExecute()
        {
            TeacherThemeView adminUsersView = new();
            OpenNextWindow(adminUsersView);
        }
        private void ExecuteAddThemeCommand()
        {
            try
            {
                var theme = context.Themes.FirstOrDefault(t => t.ThemeName == Name);
                if (theme == null)
                {
                    var t = new Theme { ThemeName = name, DisciplineId = discipline.IdDiscipline };
                    context.Themes.Add(t);
                    context.SaveChanges();
                    MessageBox.Show("Тема успешно создана");
                    TeacherThemeView teacherThemeView = new();
                    OpenNextWindow(teacherThemeView);
                }
                else
                    MessageBox.Show("Тема уже существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
            }
        }
        private bool CanExecuteAddThemeCommand()
        {
            return (!string.IsNullOrEmpty(name)&& !string.IsNullOrEmpty(discipline.DisciplineName));
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
        private ObservableCollection<Discipline> disciplines;
        public ObservableCollection<Discipline> Disciplines
        {
            get => disciplines;
            set
            {
                disciplines = value;
                OnPropertyChanged();
            }
        }
    }
}

