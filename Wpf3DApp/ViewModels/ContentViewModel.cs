using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Wpf3DApp.ViewModels
{
    public partial class ContentViewModel : ObservableObject
    {

        [ObservableProperty]
        public string welcomeString = "HELLO FROM CONTENT VIEW!";

        [ObservableProperty]
        public string axisRotation;

        [ObservableProperty]
        public int xAxisValue;

        [ObservableProperty]
        public int yAxisValue;

        [ObservableProperty]
        public int zAxisValue;

        [ObservableProperty]
        public List<string> axisItemsSource;

        [ObservableProperty]
        public string selectedAxis;


        public ContentViewModel()
        {
            AxisItemsSource = new List<string>()
            {
                "0 0 1",
                "1 0 0",
                "0 1 0",
                "0 1 1",
                "1 1 0",
                "0 1 1",
                "1 1 1"
            };
            SelectedAxis = AxisItemsSource.First();
        }

        partial void OnXAxisValueChanged(int value)
        {
            UpdateAxisRotation();
        }

        partial void OnYAxisValueChanged(int value)
        {
            UpdateAxisRotation();
        }

        partial void OnZAxisValueChanged(int value)
        {
            UpdateAxisRotation();
        }

        private void UpdateAxisRotation()
        {
            AxisRotation = $"{XAxisValue} {YAxisValue} {ZAxisValue}";
        }

        partial void OnSelectedAxisChanged(string value)
        {
            AxisRotation = SelectedAxis;
        }
    }
}
