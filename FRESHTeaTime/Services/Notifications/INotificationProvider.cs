using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRESHTeaTime.Services.Notifications
{
    public interface INotificationProvider
    {
        public void SendNotification(Notification notification);

        public void Close();
    }

    public class Notification
    {
        public string? Header { get; init; }

        public string? Content { get; init; }

        public NotificationButton[]? Buttons { get; init; }
    }

    public class NotificationButton
    {
        public string? Label { get; init; }

        public Action? OnPressed { get; init; }
    }
}
