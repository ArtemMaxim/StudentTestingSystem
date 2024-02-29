using StudentTestingSystem.ViewModel.StudentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentTestingSystem.View.StudentView
{
    /// <summary>
    /// Логика взаимодействия для StudentTestingView.xaml
    /// </summary>
    public partial class StudentTestingView : Window
    {
        public StudentTestingView(StudentTestViewModel viewModel)
        {
            InitializeComponent();
            Title = viewModel.SelectedTest.Theme.ThemeName;
            DataContext = new StudentTestingViewModel(viewModel);
        }
    }
}
