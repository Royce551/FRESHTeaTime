using FRESHTeaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STimers = System.Timers;
using Avalonia;
using Avalonia.Threading;
using FRESHTeaTime.Services.Notifications;

namespace FRESHTeaTime.Services
{
    public class TimeKeepingService
    {
        public List<Timer> Timers { get; private set; } = new();

        public event EventHandler? Updated;

        public void AddTimer(Timer timer)
        {
            Timers.Add(timer);
            var newTimer = new STimers.Timer(1000);
            newTimer.Elapsed += async (sender, e) =>
            {
                timer.TimeLeft -= TimeSpan.FromSeconds(1);
                if (timer.TimeLeft.TotalSeconds <= 0)
                {
                    RemoveTimer(timer);
                    newTimer.Stop();
                    App.Notifications.Notifier.SendNotification(new Notification { Header = "Timer done!", Content = $"\"{timer.Name}\"" });
                }
                await Dispatcher.UIThread.InvokeAsync(() => Updated?.Invoke(null, EventArgs.Empty));
            };
            newTimer.Start();
            Updated?.Invoke(null, EventArgs.Empty);
        }

        public void RemoveTimer(Timer timer)
        {
            Timers.Remove(timer);
            Updated?.Invoke(null, EventArgs.Empty);
        }
    }
}
