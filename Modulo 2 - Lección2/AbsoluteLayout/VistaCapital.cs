using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AbsoluteLayout
{
    [Activity(Label = "VistaCapital")]
    public class VistaCapital : Activity
    {
		double defaultValue;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VistaCapital);
            //double CapitalM, CapitalC;
           // Button btnSalir = FindViewById<Button>
             //   (Resource.Id.btnsalir);
            EditText txtCapitalM = FindViewById<EditText>
                (Resource.Id.txtcapitalM);
            EditText txtCapitalC = FindViewById<EditText>
                (Resource.Id.txtcapitalC);
			ImageView ImagenMex = FindViewById<ImageView>
				(Resource.Id.imagenmex);
			ImageView ImagenCol = FindViewById<ImageView>
				(Resource.Id.imagencol);
			Button btnSalir = FindViewById<Button>
				(Resource.Id.btnsalir);

			try
            {
				txtCapitalM.Text = Intent.GetDoubleExtra("CapitalM", defaultValue).ToString();
				txtCapitalC.Text = Intent.GetDoubleExtra("CapitalC", defaultValue).ToString();
				ImagenMex.SetImageResource(Resource.Drawable.mexico);
				ImagenCol.SetImageResource(Resource.Drawable.colombia);
            }
            catch (Exception ex)
            {
                Toast.MakeText
                         (this, ex.Message,
                          ToastLength.Short).Show();
            }
			btnSalir.Click += delegate {
				Android.OS.Process.KillProcess(Android.OS.Process.MyPid());	
			};
        }
    }
}