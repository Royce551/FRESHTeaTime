using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FRESHTeaTime.Services;
using FRESHTeaTime.Services.Notifications;
using FRESHTeaTime.ViewModels;
using FRESHTeaTime.Views;

namespace FRESHTeaTime
{
    public class App : Application
    {
        public static TimeKeepingService TimeKeeping = new(); // using static maybe isn't the best idea
                                                              // but there should only be 1 of these anyway

        public static NotificationService Notifications = new();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
