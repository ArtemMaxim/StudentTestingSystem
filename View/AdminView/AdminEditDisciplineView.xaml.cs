using StudentTestingSystem.ViewModel.AdminViewModel;
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
using StudentTestingSystem.ViewModel.AdminViewModel;

namespace StudentTestingSystem.View.AdminView
{
    /// <summary>
    /// Логика взаимодействия для AdminEditDisciplineView.xaml
    /// </summary>
    public partial class AdminEditDisciplineView : Window
    {
        public AdminEditDisciplineView(AdminDisciplineViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new AdminEditDisciplineViewModel(viewModel);
        }
    }
}
