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
    /// Логика взаимодействия для TeacherEditTestView.xaml
    /// </summary>
    public partial class TeacherEditTestView : Window
    {
        public TeacherEditTestView(TeacherTestViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new TeacherEditTestViewModel(viewModel);
        }
    }
}
