using CommunityToolkit.Mvvm.ComponentModel;

namespace Wpf3DApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        public string welcomeString = "HELLO FROM HOME!";
    }
}