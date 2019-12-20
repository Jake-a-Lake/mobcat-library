﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using NUnit.Runner.Services;
using Microsoft.MobCAT.Repository.Test;

namespace Microsoft.MobCAT.Repository.EntityFrameworkCore.Test.Android
{
    [Activity(Label = "EFCore-Tests", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var nunit = new NUnit.Runner.App
            {
                Options = new TestOptions
                {
                    AutoRun = true,
                    CreateXmlResultFile = true
                }
            };

            var storageFilepath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Bootstrap.Begin((datastoreName) => new EFCoreSampleRepositoryContext(Guard.NullOrWhitespace(storageFilepath), datastoreName));

            LoadApplication(nunit);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] global::Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}