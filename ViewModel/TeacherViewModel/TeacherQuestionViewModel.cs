using ABI.System;
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
    internal class TeacherQuestionViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public Question SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                selectedQuestion = value;
                OnPropertyChanged();
            }
        }
        private Question selectedQuestion;
        public TeacherQuestionViewModel()
        {
            context = new();
            Questions = new ObservableCollection<Question>(context.Questions.ToList());
            Types = new ObservableCollection<Models.Type>(context.Types.ToList());
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
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить вопрос {selectedQuestion.QuestionText}?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Questions.Where(q => q.IdQuestion == selectedQuestion.IdQuestion).ExecuteDelete();
                Questions.Remove(selectedQuestion);
                context.SaveChanges();
            }
        }
        private void ExecuteEditCommand()
        {
            //TeacherEditThemeView teacherEditThemeView = new();
            //OpenNextWindow(teacherEditThemeView);
        }
        private bool CanExecuteSelectCommand()
        {
            if (selectedQuestion != null)
                return true;
            else
                return false;
        }
        private void ExecuteAddCommand()
        {
            TeacherAddQuestionView teacherAddQuestionView = new();
            OpenNextWindow(teacherAddQuestionView);
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
    }
}
