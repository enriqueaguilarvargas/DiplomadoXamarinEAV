using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace SQLiteSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "todo.db");
			LoadApplication (new App (dbPath));

			return base.FinishedLaunching (app, options);
		}
	}
}

