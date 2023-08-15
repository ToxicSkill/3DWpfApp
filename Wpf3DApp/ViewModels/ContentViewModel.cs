using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;

namespace MvvmFluentDIApp.ViewModels
{
    public partial class ContentViewModel : ObservableObject
    {
        [ObservableProperty]
        public string welcomeString = "HELLO FROM CONTENT VIEW!";

        [ObservableProperty]
        public string axisRotation = "2 0 0";

        [ObservableProperty]
        public List<string> axisItemsSource;

        [ObservableProperty]
        public string selectedAxis;


        public ContentViewModel()
        {
            axisItemsSource = new List<string>()
            {
                "0 0 1",
                "1 0 0",
                "0 1 1",
                "1 0 1",
                "1 1 0",
                "1 1 1"
            };
        }

        [RelayCommand]
        private void Select()
        {
            AxisRotation = SelectedAxis;
        }
    }
}
