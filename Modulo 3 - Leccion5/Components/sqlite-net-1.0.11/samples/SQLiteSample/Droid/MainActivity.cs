using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SQLiteSample.Droid
{
	[Activity (Label = "SQLiteSample.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			global::Acr.UserDialogs.UserDialogs.Init (this);

			var dbPath = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), "todo.db");
			LoadApplication (new App (dbPath));
		}
	}
}

