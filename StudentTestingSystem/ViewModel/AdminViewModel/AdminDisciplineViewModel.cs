using Microsoft.EntityFrameworkCore;
using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    public class AdminDisciplineViewModel: BaseViewModel
    {
        private readonly TestContext context;
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        private Discipline selectedDiscipline;
        public Discipline SelectedDiscipline
        {
            get => selectedDiscipline;
            set
            {
                selectedDiscipline = value;
                OnPropertyChanged();
            }
        }
        public AdminDisciplineViewModel()
        {
            context = new();
            Disciplines = new ObservableCollection<Discipline>(context.Disciplines.ToList());
            AddCommand = new RelayCommand(ExecuteAddCommand, CanExecuteCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteSelectCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
            EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteSelectCommand);
        }
        private void ExecuteDeleteCommand()
        {
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить предмет {selectedDiscipline.DisciplineName}?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Disciplines.Where(u => u.IdDiscipline == selectedDiscipline.IdDiscipline).ExecuteDelete();
                Disciplines.Remove(selectedDiscipline);
                context.SaveChanges();
            }
        }
        private void ExecuteEditCommand()
        {
            AdminEditDisciplineView adminEditView = new(this);
            OpenNextWindow(adminEditView);
        }
        private bool CanExecuteSelectCommand()
        {
            if (selectedDiscipline != null)
                return true;
            else
                return false;
        }
        private void ExecuteAddCommand()
        {
            AdminAddDisciplineView adminAddDisciplineView = new();
            OpenNextWindow(adminAddDisciplineView);
        }
        private void ExecuteBackCommand()
        {
            AdminMainView adminMainView = new AdminMainView();
            OpenNextWindow(adminMainView);
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

