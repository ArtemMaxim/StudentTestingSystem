using StudentTestingSystem.Command;
using StudentTestingSystem.Models;
using StudentTestingSystem.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentTestingSystem.ViewModel.AdminViewModel
{
    public class AdminEditGroupViewModel : BaseViewModel
    {
        private readonly TestContext context;
        public ICommand EditGroupCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public AdminEditGroupViewModel(AdminGroupViewModel viewModel)
        {
            context = new();
            Id = viewModel.SelectedGroup.IdGroup;
            SelectedGroup = viewModel.SelectedGroup;  
            BackCommand = new RelayCommand(BackCommandExecute, CanExecuteCommand);
            EditGroupCommand = new RelayCommand(ExecuteEditGroupCommand, CanExecuteEditGroupCommand);
        }
        private Group selectedGroup;
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
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
        private int id;
        private void ExecuteEditGroupCommand()
        {
            try
            {
                var group = context.Groups.FirstOrDefault(g => g.IdGroup == id);
                if (group != null)
                {
                    group.GroupName = SelectedGroup.GroupName;
                    context.Groups.Update(group);
                    context.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    AdminGroupView adminGroupView = new();
                    OpenNextWindow(adminGroupView);
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
        private bool CanExecuteEditGroupCommand()
        {
            return !string.IsNullOrEmpty(selectedGroup.GroupName);
        }
        private void BackCommandExecute()
        {
            AdminGroupView adminGroupsView = new();
            OpenNextWindow(adminGroupsView);
        }
    }
}