using StudentTestingSystem.ViewModel.AdminViewModel;
using StudentTestingSystem.ViewModel.TeacherViewModel;
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

namespace StudentTestingSystem.View.TeacherView
{
    /// <summary>
    /// Логика взаимодействия для TeacherEditThemeView.xaml
    /// </summary>
    public partial class TeacherEditThemeView : Window
    {
        public TeacherEditThemeView(TeacherThemeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new TeacherEditThemeViewModel(viewModel);
        }
    }
}
