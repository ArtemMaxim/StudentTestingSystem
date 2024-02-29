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
    public class TeacherEditTestViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand EditTestCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand QuestionCommand { get; private set; }
        public TeacherEditTestViewModel(TeacherTestViewModel viewModel)
        {
            context = new();
            Id = viewModel.SelectedTest.IdTest;
            SelectedTest= viewModel.SelectedTest;
            SelectedTheme = viewModel.SelectedTest.Theme;
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            QuestionCommand = new RelayCommand(QuestionCommandExecute, CanExecuteCommand);
            EditTestCommand = new RelayCommand(ExecuteEditTestCommand, CanExecuteEditTestCommand);
        }
        private void ExecuteEditTestCommand()
        {
            try
            {
                var test = context.Tests.FirstOrDefault(t => t.IdTest == id);
                if (test != null)
                {
                    test.TestTime = SelectedTest.TestTime;
                    test.ThemeID = SelectedTheme.IdTheme;
                    context.Tests.Update(test);
                    context.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    TeacherTestView teacherTestView = new();
                    OpenNextWindow(teacherTestView);
                }
                else
                {
                    MessageBox.Show("Такого теста не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
                Debug.WriteLine(ex.Message);
            }
        }
        private bool CanExecuteEditTestCommand()
        {
            return !string.IsNullOrEmpty(selectedTest.ThemeID.ToString());
        }
        private void BackCommandExecute()
        {
            TeacherTestView teacherTestView = new();
            OpenNextWindow(teacherTestView);
        }
        private void QuestionCommandExecute()
        {
            TeacherQuestionView teacherQuestionView = new();
            OpenNextWindow(teacherQuestionView);
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

        public Test SelectedTest
        {
            get => selectedTest;
            set
            {
                selectedTest = value;
                OnPropertyChanged();
            }
        }
        private Test selectedTest;
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
