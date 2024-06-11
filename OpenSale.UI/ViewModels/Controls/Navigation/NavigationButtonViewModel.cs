using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSale.UI.ViewModels.Controls.Navigation
{
    public partial class NavigationButtonViewModel : ViewModelBase
    {
        private readonly string name;
        private readonly Type type;

        [ObservableProperty]
        private string? icon;

        public NavigationButtonViewModel(string name, Type type)
        {
            this.name = name;
            this.type = type;
            selected = AppServices.Instance.Window?.CurrentPage.GetType() == type;
            AppServices.OnNavigated += AppServices_OnNavigated;
        }

        private void AppServices_OnNavigated(ViewModelBase vm)
        {
            Selected = vm.GetType() == type;
        }

        public string Name => name;

        [ObservableProperty]
        private bool selected;

        [RelayCommand]
        private void Navigate()
        {
            if (!Design.IsDesignMode)
            {
                AppServices.Instance.Navigate(AppServices.Instance.ServiceProvider?.GetService(type) as ViewModelBase ?? throw new ArgumentException("Website has not been registered"));
            }
            else
            {
                AppServices.Instance.Navigate((ViewModelBase)Activator.CreateInstance(type)!);
            }
        }
    }
}
