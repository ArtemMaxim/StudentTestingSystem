using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    internal class AdminAddDisciplineViewModel:BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand AddDisciplineCommand { get; private set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string name;
        public AdminAddDisciplineViewModel()
        {
            context = new();
            Disciplines = new ObservableCollection<Discipline>(context.Disciplines.ToList());
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            AddDisciplineCommand = new RelayCommand(ExecuteAddDisciplineCommand, CanExecuteAddDisciplineCommand);
        }
        private void BackCommandExecute()
        {
            AdminDisciplineView adminDisciplineView = new();
            OpenNextWindow(adminDisciplineView);
        }
        private void ExecuteAddDisciplineCommand()
        {
            try
            {
                var discipline = context.Disciplines.FirstOrDefault(d => d.DisciplineName == name);
                if (discipline == null)
                {
                    var d = new Discipline { DisciplineName = name };
                    context.Disciplines.Add(d);
                    context.SaveChanges();
                    MessageBox.Show("Предмет успешно добавлен");
                    AdminDisciplineView adminDisciplineView = new();
                    OpenNextWindow(adminDisciplineView);
                }
                else
                    MessageBox.Show("Предмет с таким названием уже существует");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка!");
            }
        }
        private bool CanExecuteAddDisciplineCommand()
        {
            return !string.IsNullOrEmpty(name);
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
