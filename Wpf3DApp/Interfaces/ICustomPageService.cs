using System;
using Wpf.Ui.Mvvm.Contracts;

namespace Wpf3DApp.Interfaces
{
    public interface ICustomPageService : IPageService
    {
        event EventHandler<string> OnPageNavigate;
    }
}