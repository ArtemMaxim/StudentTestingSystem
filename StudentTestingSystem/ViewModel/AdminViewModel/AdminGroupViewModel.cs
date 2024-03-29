﻿using Microsoft.EntityFrameworkCore;
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
    public class AdminGroupViewModel: BaseViewModel
    {
        private readonly TestContext context;
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
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
        public AdminGroupViewModel()
        {
            context = new();
            Groups = new ObservableCollection<Group>(context.Groups.ToList());
            AddCommand = new RelayCommand(ExecuteAddCommand, CanExecuteCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteSelectCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
            EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteSelectCommand);
        }
        private void ExecuteDeleteCommand()
        {
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить группу {selectedGroup.GroupName}?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Groups.Where(u => u.IdGroup == selectedGroup.IdGroup).ExecuteDelete();
                Groups.Remove(selectedGroup);
                context.SaveChanges();
            }
        }
        private void ExecuteEditCommand()
        {
            AdminEditGroupView adminEditView = new(this);
            OpenNextWindow(adminEditView);
        }
        private bool CanExecuteSelectCommand()
        {
            if (selectedGroup != null)
                return true;
            else
                return false;
        }
        private void ExecuteAddCommand()
        {
            AdminAddGroupView adminAddGroupView = new();
            OpenNextWindow(adminAddGroupView);
        }
        private void ExecuteBackCommand()
        {
            AdminMainView adminMainView = new AdminMainView();
            OpenNextWindow(adminMainView);
        }

        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set
            {
                groups = value;
                OnPropertyChanged();
            }
        }

    }
}

