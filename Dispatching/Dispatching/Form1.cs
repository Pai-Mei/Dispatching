using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dispatching
{
	public partial class Form1 : Form
	{
		private readonly string template = "Маршрут №";
		private Boolean isEdit = false;
		private List<GMapRoute> routes;
		private GMapRoute route;
		private GMapOverlay markersOverlay;
		private GMapOverlay routeOverlay;
		private PointLatLng lastPoint = PointLatLng.Empty;
		private Stack<Int32> LastPointsAdded = new Stack<Int32>();
		private Stack<Boolean> LastMarkerAdded = new Stack<Boolean>();

		public Form1()
		{
			routes = new List<GMapRoute>();
			InitializeComponent();
			gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
			gmap.SetPositionByKeywords("Krivoy Rog, Ukraine");
			markersOverlay = new GMapOverlay("markers");
			routeOverlay = new GMapOverlay("routs");
			gmap.Overlays.Add(markersOverlay);
			gmap.Overlays.Add(routeOverlay);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AddPointToRoute(gmap.Position, true);
		}

		private void buttonAddRoadPoint_Click(object sender, EventArgs e)
		{
			AddPointToRoute(gmap.Position, false);			
		}
		
		private void buttonAddRoute_Click(object sender, EventArgs e)
		{
			if (!isEdit)
			{
				route = new GMapRoute(template + textBoxNumber.Text);
				routeOverlay.Routes.Add(route);
				buttonAddRoute.Enabled = false;
				groupBoxRouteEdit.Enabled = true;
				isEdit = true;
			}
		}

		private void buttonFinish_Click(object sender, EventArgs e)
		{
			if (isEdit)
			{
				routes.Add(route);
				buttonAddRoute.Enabled = true;
				groupBoxRouteEdit.Enabled = false;
				isEdit = false;
				lastPoint = PointLatLng.Empty;
			}
		}

		private void buttonSetColor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if(cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				route.Stroke = new Pen(new SolidBrush(cd.Color), 2);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Undo();
		}

//----------------------------------------------------------------------------------

		private void AddPointToRoute(PointLatLng point, Boolean isMarker)
		{
			LastMarkerAdded.Push(isMarker);
			if (isMarker)
			{
				GMarkerGoogle marker = new GMarkerGoogle(gmap.Position, GMarkerGoogleType.green_dot);
				markersOverlay.Markers.Add(marker);
			}
			if (lastPoint == PointLatLng.Empty)
			{
				route.Points.Add(gmap.Position);
			}
			else
			{
				MapRoute routePart = GMap.NET.MapProviders.BingMapProvider.Instance.GetRoute(
						lastPoint, gmap.Position, false, false, 15);
				if (routePart != null)
				{
					route.Points.AddRange(routePart.Points);
					LastPointsAdded.Push(routePart.Points.Count);
				}
				else
				{
					route.Points.Add(gmap.Position);
					LastPointsAdded.Push(1);
				}
			}
			lastPoint = gmap.Position;
			RefreshMap();
		}

		private void RefreshMap()
		{
			gmap.Zoom += 1;
			gmap.Refresh();
			gmap.Zoom -= 1;
			gmap.Refresh();
		}

		private void Undo()
		{
			if (LastPointsAdded.Count > 0)
			{
				var n = LastPointsAdded.Pop();
				route.Points.RemoveRange(route.Points.Count - n, n);
			}
			if (LastMarkerAdded.Count > 0)
			{
				if (LastMarkerAdded.Pop())
				{
					markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
				}
			}
			RefreshMap();
		}
	}
}
