// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace EjercicioiOSActivosPasivos
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnCalcular { get; set; }

		[Outlet]
		UIKit.UITextField txtBanco { get; set; }

		[Outlet]
		UIKit.UITextField txtCaja { get; set; }

		[Outlet]
		UIKit.UITextField txtCapitalContable { get; set; }

		[Outlet]
		UIKit.UITextField txtCuentasporCobrar { get; set; }

		[Outlet]
		UIKit.UITextField txtPagoaCredito { get; set; }

		[Outlet]
		UIKit.UITextField txtPagoaProveedores { get; set; }

		[Outlet]
		UIKit.UITextField txtRenta { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtCaja != null) {
				txtCaja.Dispose ();
				txtCaja = null;
			}

			if (txtBanco != null) {
				txtBanco.Dispose ();
				txtBanco = null;
			}

			if (txtCuentasporCobrar != null) {
				txtCuentasporCobrar.Dispose ();
				txtCuentasporCobrar = null;
			}

			if (txtPagoaCredito != null) {
				txtPagoaCredito.Dispose ();
				txtPagoaCredito = null;
			}

			if (txtPagoaProveedores != null) {
				txtPagoaProveedores.Dispose ();
				txtPagoaProveedores = null;
			}

			if (txtRenta != null) {
				txtRenta.Dispose ();
				txtRenta = null;
			}

			if (txtCapitalContable != null) {
				txtCapitalContable.Dispose ();
				txtCapitalContable = null;
			}

			if (btnCalcular != null) {
				btnCalcular.Dispose ();
				btnCalcular = null;
			}
		}
	}
}
