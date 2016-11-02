// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AccesoSQLiteyServicio
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnEnviar { get; set; }

		[Outlet]
		UIKit.UIButton btnGuardar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGuardar != null) {
				btnGuardar.Dispose ();
				btnGuardar = null;
			}

			if (btnEnviar != null) {
				btnEnviar.Dispose ();
				btnEnviar = null;
			}
		}
	}
}
