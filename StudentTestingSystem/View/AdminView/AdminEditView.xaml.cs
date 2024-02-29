using StudentTestingSystem.Models;
using StudentTestingSystem.ViewModel.AdminViewModel;
using System.Windows;

namespace StudentTestingSystem.View.AdminView
{
    /// <summary>
    /// Логика взаимодействия для AdminEditView.xaml
    /// </summary>
    public partial class AdminEditView : Window
    {
        public AdminEditView(AdminUsersViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new AdminEditViewModel(viewModel);
        }
    }
}
