using Android.App;
using Android.Widget;
using Android.OS;
namespace AbsoluteLayout
{
	[Activity(Label = "Convertidor", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			Button btnConvertir = FindViewById<Button>
				(Resource.Id.btnconvertir);
			EditText txtDolares = FindViewById<EditText>
				(Resource.Id.txtdolares);
			EditText txtPesos = FindViewById<EditText>
				(Resource.Id.txtpesos);
			double pesos, dolares;
			btnConvertir.Click += delegate
			{
				try
				{
					dolares = double.Parse(txtDolares.Text);
					pesos = dolares * 19.5;
					txtPesos.Text = pesos.ToString();
				}
				catch (System.Exception ex)
				{
					Toast.MakeText
					     (this, ex.Message, 
					      ToastLength.Short).Show();
				}
			};			
		}
	}
}

