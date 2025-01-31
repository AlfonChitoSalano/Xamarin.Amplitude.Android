﻿using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Content.PM;

namespace Xamarin.Amplitude.Android.UsageChecker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Com.Amplitude.Api.Amplitude.Instance.Initialize(this, "your_amplitude_token")
                .EnableForegroundTracking(Application)
                .TrackSessionEvents(true);

            Com.Amplitude.Api.Amplitude.Instance.LogEvent("android binding working");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}