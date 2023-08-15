using CommunityToolkit.Mvvm.ComponentModel;
using Wpf3DApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Controls;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Controls.Navigation;

namespace Wpf3DApp.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public ICollection<INavigationControl> menuItems;

        [ObservableProperty]
        public ICollection<INavigationControl> footerItems;

        public MainWindowViewModel()
        {
            menuItems = new ObservableCollection<INavigationControl>();
            footerItems = new ObservableCollection<INavigationControl>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            MenuItems.Add(new NavigationItem()
            {
                Icon = SymbolRegular.Home20,
                PageTag = "home",
                Cache = true,
                Content = "Home",
                PageType = typeof(HomeView)
            });
            MenuItems.Add(new NavigationSeparator());
            MenuItems.Add(new NavigationItem()
            {
                Icon = SymbolRegular.ContentSettings20,
                PageTag = "content",
                Cache = true,
                Content = "Content",
                PageType = typeof(ContentView)
            });
            FooterItems.Add(new NavigationSeparator());
            FooterItems.Add(new NavigationItem()
            {
                Icon = SymbolRegular.Settings20,
                PageTag = "settings",
                Cache = true,
                Content = "Settings",
                PageType = typeof(SettingsView)
            });
        }
    }
}
