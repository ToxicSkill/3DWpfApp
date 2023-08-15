using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmFluentDIApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        public string welcomeString = "HELLO FROM HOME!";
    }
}