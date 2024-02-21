using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    public class AdminEditDisciplineViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand EditDisciplineCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public AdminEditDisciplineViewModel(AdminDisciplineViewModel viewModel)
        {
            context = new();
            Id = viewModel.SelectedDiscipline.IdDiscipline;
            SelectedDiscipline = viewModel.SelectedDiscipline;
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            EditDisciplineCommand = new RelayCommand(ExecuteEditDisciplineCommand, CanExecuteEditDisciplineCommand);
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
        public Discipline SelectedDiscipline
        {
            get => selectedDiscipline;
            set
            {
                selectedDiscipline = value;
                OnPropertyChanged();
            }
        }
        private int id;
        private Discipline selectedDiscipline;
        private void ExecuteEditDisciplineCommand()
        {
            try
            {
                var discipline = context.Disciplines.FirstOrDefault(d => d.IdDiscipline == id);
                if (discipline != null)
                {
                    discipline.DisciplineName = SelectedDiscipline.DisciplineName;
                    context.Disciplines.Update(discipline);
                    context.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    AdminDisciplineView adminDisciplineView = new();
                    OpenNextWindow(adminDisciplineView);
                }
                else
                {
                    MessageBox.Show("Такой группы не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
                Debug.WriteLine(ex.Message);
            }
        }
        private bool CanExecuteEditDisciplineCommand()
        {
            return !string.IsNullOrEmpty(selectedDiscipline.DisciplineName);
        }
        private void BackCommandExecute()
        {
            AdminDisciplineView adminDisciplineView = new();
            OpenNextWindow(adminDisciplineView);
        }
    }
}
