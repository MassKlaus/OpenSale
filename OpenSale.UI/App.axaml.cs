using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using OpenSale.UI.ViewModels;
using OpenSale.UI.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace OpenSale.UI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);

                var collection = new ServiceCollection();
                collection.AddScoped<FakeService>();
                collection.LoadViewModels();

                var services = collection.BuildServiceProvider();

                    AppServices.Instance.ServiceProvider = services;


                desktop.MainWindow = new MainWindow
                {
                    DataContext = services.GetService<MainWindowViewModel>()!
                };

            }

            base.OnFrameworkInitializationCompleted();
        }

    }

    public class FakeService()
    {
        public string Scream()
        {
            return "Test";
        }
    }

    public class AppServices : IServiceProvider
    {
        public MainWindowViewModel? Window { get; set; }
        public IServiceProvider? ServiceProvider { get; set; }

        public delegate void AppNavigated(ViewModelBase vm);
        public static event AppNavigated? OnNavigated;

        public object? GetService(Type serviceType)
        {
            return ServiceProvider?.GetService(serviceType);
        }

        public void Navigate(ViewModelBase viewModel)
        {
            if (Window is null)
            {
                return;
            }

            Window.CurrentPage = viewModel;
            OnNavigated?.Invoke(viewModel);
        }

        public static AppServices Instance { get; set; } = new();
    }

    public static class DependencyInjectionExpantion
    {
        public static IServiceCollection LoadViewModels(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var viewModelTypes = assembly.DefinedTypes.Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

            foreach (var viewModelType in viewModelTypes)
            {
                services.AddTransient(viewModelType);
            }

            return services;
        }
    }
}