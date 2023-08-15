using Wpf3DApp.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace Wpf3DApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class HomeView : INavigableView<HomeViewModel>
    {
        public HomeViewModel ViewModel
        {
            get;
        }

        public HomeView(HomeViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
