using System;
using Wpf.Ui.Mvvm.Contracts;

namespace MvvmFluentDIApp.Interfaces
{
    public interface ICustomPageService : IPageService
    {
        event EventHandler<string> OnPageNavigate;
    }
}