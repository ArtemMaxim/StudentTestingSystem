﻿using Microsoft.EntityFrameworkCore;
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
    internal class TeacherTestViewModel: BaseViewModel
    {
        private readonly TestContext context;
        public ICommand BackCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public TeacherTestViewModel()
        {
            context = new();
            Tests = new ObservableCollection<Test>(context.Tests.ToList());
            Themes = new ObservableCollection<Theme>(context.Themes.ToList());
            Disciplines = new ObservableCollection<Discipline>(context.Disciplines.ToList());
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteSelectCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteCommand);
        }
        private void ExecuteDeleteCommand()
        {
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить тест на тему {selectedTest.Theme.ThemeName}?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Tests.Where(t => t.IdTest == selectedTest.IdTest).ExecuteDelete();
                Tests.Remove(selectedTest);
                context.SaveChanges();
            }
        }
        private bool CanExecuteSelectCommand()
        {
            if (selectedTest != null)
                return true;
            else
                return false;
        }
        private void ExecuteBackCommand()
        {
            TeacherMainView teacherMainView = new();
            OpenNextWindow(teacherMainView);
        }
        private ObservableCollection<Test> tests;
        public ObservableCollection<Test> Tests
        {
            get => tests;
            set
            {
                tests = value;
                OnPropertyChanged();
            }
        }
        private Test selectedTest;
        public Test SelectedTest
        {
            get => selectedTest;
            set
            {
                selectedTest = value;
                OnPropertyChanged();
            }
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
