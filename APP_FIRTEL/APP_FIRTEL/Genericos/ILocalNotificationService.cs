using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Genericos
{
    public interface ILocalNotificationService
    {
        void ShowNotification(string title, string message);
    }
}
