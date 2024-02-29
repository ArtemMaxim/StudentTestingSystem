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
    class TeacherAddQuestionViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand AddQuestionCommand { get; private set; }
        public Models.Type SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
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
        public string EnterText
        {
            get => enterText;
            set
            {
                enterText = value;
                OnPropertyChanged();
            }
        }
        private string enterText;
        private int id;
        private TimeOnly time;
        private Models.Type selectedType;
        public TeacherAddQuestionViewModel()
        {
            context = new();
            Questions = new ObservableCollection<Question>(context.Questions.ToList());
            Types = new ObservableCollection<Models.Type>(context.Types.ToList());
            SelectedType = Types.First();
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            AddQuestionCommand = new RelayCommand(ExecuteAddQuestionCommand, CanExecuteAddQuestionCommand);
        }
        private void BackCommandExecute()
        {
            TeacherQuestionView teacherQuestionView = new();
            OpenNextWindow(teacherQuestionView);
        }
        private void ExecuteAddQuestionCommand()
        {
            try
            {
                var question = context.Questions.FirstOrDefault(t => t.IdQuestion == Id);
                if (question == null)
                {
                    var q = new Question { TypeId = selectedType.IdType, QuestionText =  enterText, TestId = 1};
                    context.Questions.Add(q);
                    context.SaveChanges();
                    MessageBox.Show("Вопрос успешно добавлен");
                    TeacherQuestionView teacherQuestionView = new();
                    OpenNextWindow(teacherQuestionView);
                }
                else
                    MessageBox.Show("Тест уже существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
            }
        }
        private bool CanExecuteAddQuestionCommand()
        {
             return !string.IsNullOrEmpty(selectedType.TypeName) && !string.IsNullOrEmpty(enterText);
        }
        private ObservableCollection<Models.Type> types;
        public ObservableCollection<Models.Type> Types
        {
            get => types;
            set
            {
                types = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions
        {
            get => questions;
            set
            {
                questions = value;
                OnPropertyChanged();
            }
        }
    }
}

