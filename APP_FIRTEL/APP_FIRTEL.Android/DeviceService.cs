using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using APP_FIRTEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Provider;

using APP_FIRTEL.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceService))]
namespace APP_FIRTEL.Droid
{
    
    class DeviceService :IDeviceService
    {
        public string GetDeviceId()
        {
            return Settings.Secure.GetString(
                Android.App.Application.Context.ContentResolver,
                Settings.Secure.AndroidId
            );
        }
    }
}