using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using OpenSale.UI.Attributes;
using OpenSale.UI.ViewModels.Controls.Navigation;
using OpenSale.UI.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace OpenSale.UI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string greeting = "Welcome to Avalonia!";

        [ObservableProperty]
        private ObservableCollection<NavigationButtonViewModel> navigations = new();

        public MainWindowViewModel()
        {
            AppServices.Instance.Window = this;

            if (Design.IsDesignMode)
            {
                currentPage = new HomeViewModel();
            }
            else
            {
                currentPage = AppServices.Instance.GetService<HomeViewModel>() ?? throw new Exception("Error Getting Values");
            }

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(ViewModelBase)) && x.CustomAttributes.Any(x => x.AttributeType == typeof(PageAttribute)));

            List<(int, NavigationButtonViewModel)> list = new();

            foreach (var type in types)
            {
                var page = type.GetCustomAttributes<PageAttribute>().First();
                var index = page.Position;
                var navButton = new NavigationButtonViewModel(page.Name, type);
                navButton.Icon = page.Icon;
                list.Add((index, navButton));
            }

            navigations = new(list.OrderBy(x => x.Item1).Select(x => x.Item2));
        }

        [ObservableProperty]
        private ViewModelBase currentPage;
    }
}
