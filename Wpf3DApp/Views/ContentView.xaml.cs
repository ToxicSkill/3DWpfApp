using Wpf3DApp.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace Wpf3DApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class ContentView : INavigableView<ContentViewModel>
    {
        public ContentViewModel ViewModel
        {
            get;
        }

        public ContentView(ContentViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
