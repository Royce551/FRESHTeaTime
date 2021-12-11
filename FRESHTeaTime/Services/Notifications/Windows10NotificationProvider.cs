#if WINDOWS
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FRESHTeaTime.Services.Notifications
{
    public class Windows10NotificationProvider : INotificationProvider
    {
        static Windows10NotificationProvider()
        {
            ToastNotificationManagerCompat.OnActivated += ToastNotificationManagerCompat_OnActivated;
        }

        private static void ToastNotificationManagerCompat_OnActivated(ToastNotificationActivatedEventArgsCompat e)
        {
            throw new NotImplementedException();
        }

        public void SendNotification(Notification notification)
        {
            new ToastContentBuilder()
                .AddText(notification.Header)
                .AddText(notification.Content)
                .AddAppLogoOverride(new Uri(@"https://royce551.github.io/assets/images/fmp/fullfmplogo.png")) // placeholder
                .AddAudio(new Uri(@"ms-winsoundevent:Notification.Default"), silent: true)
                .Show();
        }

        public void Close()
        {
            ToastNotificationManagerCompat.Uninstall();
        }
    }
}
#endif
