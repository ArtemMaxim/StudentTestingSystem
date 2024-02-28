using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.TeacherView;
using StudentTestingSystem.ViewModel.TeacherViewModel;
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
    public class TeacherEditThemeViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand EditThemeCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public TeacherEditThemeViewModel(TeacherThemeViewModel viewModel)
        {
            context = new();
            Id = viewModel.SelectedTheme.IdTheme;
            SelectedTheme = viewModel.SelectedTheme;
            SelectedDiscipline = viewModel.SelectedTheme.Discipline;
            Disciplines = new ObservableCollection<Discipline>(context.Disciplines.ToList());
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            EditThemeCommand = new RelayCommand(ExecuteEditThemeCommand, CanExecuteEditThemeCommand);
            
            
        }
        private void ExecuteEditThemeCommand()
        {
            try
            {
                var theme = context.Themes.FirstOrDefault(t => t.IdTheme == id);
                if (theme != null)
                {
                    theme.ThemeName = SelectedTheme.ThemeName;
                    theme.DisciplineId = SelectedDiscipline.IdDiscipline;
                    context.Themes.Update(theme);
                    context.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    TeacherThemeView teacherThemeView = new();
                    OpenNextWindow(teacherThemeView);
                }
                else
                {
                    MessageBox.Show("Такой темы не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
                Debug.WriteLine(ex.Message);
            }
        }
        private bool CanExecuteEditThemeCommand()
        {
            return (!string.IsNullOrEmpty(selectedTheme.ThemeName) && !string.IsNullOrEmpty(selectedDiscipline.DisciplineName));
        }
        private void BackCommandExecute()
        {
            TeacherThemeView teacherThemeView = new();
            OpenNextWindow(teacherThemeView);
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

        public Theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                selectedTheme = value;
                OnPropertyChanged();
            }
        }
        private Theme selectedTheme;
        public Discipline SelectedDiscipline
        {
            get => selectedDiscipline;
            set
            {
                selectedDiscipline = value;
                OnPropertyChanged();
            }
        }
        private Discipline selectedDiscipline;
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

    }
}
