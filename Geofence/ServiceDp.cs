using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Size = Xamarin.Forms.Size;
using Android.Util;
using App1.Droid;

[assembly: Dependency(typeof(ServiceDp))]
namespace App1.Droid
{
    public class ServiceDp : IServiceDp
    {
        public double GetDpScale()
        {
            double dp;

            dp = Android.App.Application.Context.Resources.DisplayMetrics.Density;

            return dp;
        }
    }
}