using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.ViewModel.AdminViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.ViewModel.StudentViewModel
{
    public class StudentTestingViewModel:BaseViewModel
    {
        private readonly TestContext context;
        public StudentTestingViewModel(StudentTestViewModel viewModel)
        {
           context = new();
           SelectedTest = viewModel.SelectedTest;
           Questions = new ObservableCollection<Question>(context.Questions.Where(q => q.TestId == selectedTest.IdTest).ToList());
           Answers = new ObservableCollection<Answer>(context.Answers.Where(a => a.QuestionID == 1).ToList());
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
        public Question SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                selectedQuestion = value;
                Answers = new ObservableCollection<Answer>(context.Answers.Where(a => a.QuestionID == selectedQuestion.IdQuestion).ToList());
                OnPropertyChanged();
            }
        }
        private Question selectedQuestion;
        private Test selectedTest;
        public ObservableCollection<Question> Questions
        {
            get => questions;
            set
            {
                questions = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Answer> Answers
        {
            get => answers;
            set
            {
                answers = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Answer> answers;
        private ObservableCollection<Question> questions;
    }
}
