using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using FRESHTeaTime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using STimer = System.Timers;
using ReactiveUI;
using FRESHTeaTime.Views;
using Avalonia.Controls;
using FRESHTeaTime.Services.Notifications;

namespace FRESHTeaTime.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Timer> Timers { get; set; } = new();

        public bool AreNotificationsAvailable => App.Notifications.Notifier is DefaultNotificationProvider;

        private Window Window
        {
            get
            {
                if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                    return desktop.MainWindow;
                else return null;
            }
        }

        public MainWindowViewModel()
        {
            App.TimeKeeping.Updated += TimeKeeping_Updated;
            //var timer = new STimer.Timer(10);
            //timer.Elapsed += TimeKeeping_Updated;
            //timer.Start();
        }

        private void TimeKeeping_Updated(object? sender, EventArgs e)
        {
            Timers.Clear();
            foreach (var timer in App.TimeKeeping.Timers) Timers.Add(timer);
        }

        public async void AddTimerCommand()
        {
            var dialog = new NewTimerDialog().Initialize();
            await dialog.ShowDialog(Window);
            if (dialog.ViewModel.OK)
            {
                if 
                    (
                    int.TryParse(dialog.ViewModel.Hours, out int hours) && 
                    int.TryParse(dialog.ViewModel.Minutes, out int minutes) &&
                    int.TryParse(dialog.ViewModel.Seconds, out int seconds)
                    )
                {
                    App.TimeKeeping.AddTimer(new Timer { Name = dialog.ViewModel.TimerName, TimeLeft = new TimeSpan(hours, minutes, seconds) });
                }
            }
        }

        public void CloseCommand()
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
            App.Notifications.Notifier.Close();
        }
    }
}
