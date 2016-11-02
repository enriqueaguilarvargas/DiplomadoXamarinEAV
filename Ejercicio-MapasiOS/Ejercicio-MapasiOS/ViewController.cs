using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;
using Foundation;
namespace EjercicioMapasiOS
{
	public partial class ViewController : UIViewController
	{
		private List<Datos> Lista;
		public ViewController (IntPtr handle) : base (handle)
		{
			Lista = DatosLista ();
		}
		public List<Datos> DatosLista()
		{
			var InformacionLista = new List<Datos> () {
				new Datos ("León, México", 21.152676, -101.711698),
				new Datos ("Cancún, México", 21.052743, -86.847242),
				new Datos ("Tijuana, México", 32.526384, -117.028983),
			};
				return InformacionLista;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Visor.Image = UIImage.FromFile("fp.jpg");
			string htmlString =
					"<HTML><BODY BGCOLOR=BLUE><p><center><h1>Hola Web Embebido</h1></center></p></body></html>";
			VisorWeb.LoadHtmlString(htmlString, new NSUrl
				("./", true));
			Selector.ValueChanged += (s, e) => {
				switch (Selector.SelectedSegment) 
				{
				case 0:
					Mapa.MapType = MKMapType.Standard;
					break;
				case 1:
					Mapa.MapType = MKMapType.Satellite;
					break;
				case 2:
					Mapa.MapType = MKMapType.Hybrid;
					break;
				}
			};
			Lista.ForEach (x => Mapa.AddAnnotation (new MKPointAnnotation () {
				Title = x.Titulo,
				Coordinate = new CLLocationCoordinate2D () {
					Latitude = x.Latitud,
					Longitude = x.Longitud
				}
			}));
			var Leon = new CLLocationCoordinate2D (21.152676, -101.711698);
			var Cancun = new CLLocationCoordinate2D (21.052743, -86.847242);
			var Tijuana = new CLLocationCoordinate2D(32.526384, -117.028983);
			var Info = new NSDictionary ();
			var OrigenDestino = new MKDirectionsRequest () {
				Source = new MKMapItem (new MKPlacemark (Leon, Info)),
				Destination = new MKMapItem (new MKPlacemark (Cancun, Info)),
			};
			var OrigenDestino2 = new MKDirectionsRequest()
			{
				Source = new MKMapItem(new MKPlacemark(Leon, Info)),
				Destination = new MKMapItem(new MKPlacemark(Tijuana, Info)),
			};
			var RutaLeonCancun = new MKDirections (OrigenDestino);
			RutaLeonCancun.CalculateDirections ((response, error) => {
				if (error == null) {
					var ruta = response.Routes [0];
					var Linea = new MKPolylineRenderer(ruta.Polyline)
					{
						LineWidth = 5.0f,
						StrokeColor = UIColor.Red,
					};
					Mapa.OverlayRenderer = (Res, Err) => Linea;
					Mapa.AddOverlay (ruta.Polyline, MKOverlayLevel.AboveRoads);
				}
			});
			var RutaLeonTijuana = new MKDirections(OrigenDestino2);
			RutaLeonTijuana.CalculateDirections((response, error) =>
			{
				if (error == null)
				{
					var ruta = response.Routes[0];
					var Linea = new MKPolylineRenderer(ruta.Polyline)
					{
						LineWidth = 5.0f,
						StrokeColor = UIColor.Blue,
					};
					Mapa.OverlayRenderer = (Res, Err) => Linea;
					Mapa.AddOverlay(ruta.Polyline, MKOverlayLevel.AboveRoads);
				}
			});
		}
		private void MessageBox(string Title, string message)
		{
			using (UIAlertView Alerta = new UIAlertView ()) 
			{
				Alerta.Title = Title;
				Alerta.Message = message;
				Alerta.AddButton ("OK");
				Alerta.Show ();
			}
		}
	}
	public class Datos
	{
		public Datos (string titulo, double latitud, double longitud)
		{
			Titulo = titulo;
			Latitud = latitud;
			Longitud = longitud;
		}
		public string Titulo {
			get;
			set;
		}
		public double Latitud {
			get;
			set;
		}
		public double Longitud {
			get;
			set;
		}
	}
}

