using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRESHTeaTime.Services.Notifications
{
    public class NotificationService
    {
        public INotificationProvider Notifier { get; private set; }

        public NotificationService()
        {
#if WINDOWS
            Notifier = new Windows10NotificationProvider();
#else
            Notifier = new DefaultNotificationProvider();
#endif

        }
    }
}
