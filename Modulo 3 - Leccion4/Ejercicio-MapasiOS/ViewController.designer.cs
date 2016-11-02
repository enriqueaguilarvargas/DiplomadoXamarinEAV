// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace EjercicioMapasiOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnUbicar { get; set; }

		[Outlet]
		MapKit.MKMapView Mapa { get; set; }

		[Outlet]
		UIKit.UISegmentedControl Selector { get; set; }

		[Outlet]
		UIKit.UITextField txtLatitud { get; set; }

		[Outlet]
		UIKit.UITextField txtLongitud { get; set; }

		[Outlet]
		UIKit.UIImageView Visor { get; set; }

		[Outlet]
		UIKit.UIWebView VisorWeb { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (VisorWeb != null) {
				VisorWeb.Dispose ();
				VisorWeb = null;
			}

			if (Visor != null) {
				Visor.Dispose ();
				Visor = null;
			}

			if (btnUbicar != null) {
				btnUbicar.Dispose ();
				btnUbicar = null;
			}

			if (Mapa != null) {
				Mapa.Dispose ();
				Mapa = null;
			}

			if (Selector != null) {
				Selector.Dispose ();
				Selector = null;
			}

			if (txtLatitud != null) {
				txtLatitud.Dispose ();
				txtLatitud = null;
			}

			if (txtLongitud != null) {
				txtLongitud.Dispose ();
				txtLongitud = null;
			}
		}
	}
}
