using Microsoft.EntityFrameworkCore;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.TeacherViewModel
{
   public class TeacherThemeViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
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
        public TeacherThemeViewModel()
        {
            context = new();
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            Disciplines = new ObservableCollection<Discipline>(context.Disciplines.ToList());
            AddCommand = new RelayCommand(ExecuteAddCommand, CanExecuteCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteSelectCommand);
            EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteSelectCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
        }
        private void ExecuteBackCommand()
        {
            TeacherMainView teacherMainView = new();
            OpenNextWindow(teacherMainView);
        }
        private void ExecuteDeleteCommand()
        {
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить тему {selectedTheme.ThemeName}?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Themes.Where(u => u.IdTheme == selectedTheme.IdTheme).ExecuteDelete();
                Themes.Remove(selectedTheme);
                context.SaveChanges();
            }
        }
        private void ExecuteEditCommand()
        {
            TeacherEditThemeView teacherEditThemeView = new(this);
            OpenNextWindow(teacherEditThemeView);
        }
        private bool CanExecuteSelectCommand()
        {
            if (selectedTheme != null)
                return true;
            else
                return false;
        }
        private void ExecuteAddCommand()
        {
            TeacherAddThemeView teacherAddThemeView = new();
            OpenNextWindow(teacherAddThemeView);
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

