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
using BinSerializer;

namespace Dispatching
{
	public partial class Form1 : Form
	{
		private readonly string template = "Маршрут №";
		private Boolean isEdit = false;
		private List<GMapTableView> routes;
		private GMapRoute route;
		private List<GMapMarker> routeMarkers;
		private List<GMapMarker> Stops;
		private GMapOverlay markersOverlay;
		private GMapOverlay routeOverlay;
		private PointLatLng lastPoint = PointLatLng.Empty;
		private Stack<Int32> LastPointsAdded = new Stack<Int32>();
		private Stack<Boolean> LastMarkerAdded = new Stack<Boolean>();
		private Stack<Double> Distanse = new Stack<Double>();
		public Form1()
		{
			routes = new List<GMapTableView>();
			routeMarkers = new List<GMapMarker>();
			Stops = new List<GMapMarker>();
			InitializeComponent();
			listBox1.DataSource = new BindingSource();
			(listBox1.DataSource as BindingSource).DataSource = routes;
			gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
			gmap.SetPositionByKeywords("Krivoy Rog, Ukraine");
			markersOverlay = new GMapOverlay("markers");
			routeOverlay = new GMapOverlay("routs");
			gmap.Overlays.Add(markersOverlay);
			gmap.Overlays.Add(routeOverlay);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GetTextDialog gtd = new GetTextDialog();
			if(gtd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				AddMarker(gmap.Position, gtd.TextResult);
		}
		
		private void buttonAddRoadPoint_Click(object sender, EventArgs e)
		{
			AddPointToRoute(gmap.Position, null);			
		}
		
		private void buttonAddRoute_Click(object sender, EventArgs e)
		{
			AddNewRoute();
		}

		private void buttonFinish_Click(object sender, EventArgs e)
		{
			FinishEditRoute();
		}
		
		private void buttonSetColor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if(cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				route.Stroke = new Pen(new SolidBrush(cd.Color), 2);
			}
			RefreshMap();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Undo();
		}

		private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Undo();
		}

		private void открітьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadFile();
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFile();
		}

		private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			New();
		}

		private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
		{
			AddPointToRoute(item.Position, item);
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox1.Items.Count > 0 && (listBox1.SelectedItem as GMapTableView) != null)
			{
				foreach (var item in routes)
					item.Route.Stroke.Width = 2;
				if ((listBox1.SelectedItem as GMapTableView).IsVisible)
					(listBox1.SelectedItem as GMapTableView).Route.Stroke.Width = 5;
				RefreshMap();
			}
		}

		private void маршрутыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fmRoutes routesView = new fmRoutes(routes);
			routesView.ShowDialog();
			UpdateData();
		}


//----------------------------------------------------------------------------------

		private void AddMarker(PointLatLng pointLatLng, string text)
		{
			GMarkerGoogle marker = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.green_small);
			marker.ToolTipText = text;
			markersOverlay.Markers.Add(marker);
			Stops.Add(marker);
		}

		private void AddPointToRoute(PointLatLng point, GMapMarker Marker)
		{
			if (isEdit)
			{
				LastMarkerAdded.Push(Marker != null);
				routeMarkers.Add(Marker);
				if (lastPoint == PointLatLng.Empty)
				{
					route.Points.Add(point);
					LastPointsAdded.Push(1);
					Distanse.Push(route.Distance);
				}
				else
				{
					MapRoute routePart = GMap.NET.MapProviders.BingMapProvider.Instance.GetRoute(
							lastPoint, point, false, false, 15);
					if (routePart != null)
					{
						route.Points.AddRange(routePart.Points);
						LastPointsAdded.Push(routePart.Points.Count);
					}
					else
					{
						route.Points.Add(point);
						LastPointsAdded.Push(1);
					}
					Distanse.Push(route.Distance);
				}
				lastPoint = point;
				RefreshMap();
			}
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
			if (isEdit)
			{
				if (LastPointsAdded.Count > 0)
				{
					var n = LastPointsAdded.Pop();
					route.Points.RemoveRange(route.Points.Count - n, n);
				}
				if (Distanse.Count > 0)
					Distanse.Pop();
				RefreshMap();
			}
			else
			{
				if (Stops.Count > 0)
				{
					Stops.RemoveAt(Stops.Count - 1);
					markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
				}
			}
		}

		private void FinishEditRoute()
		{
			if (isEdit)
			{
				var result = new GMapTableView(route);
				result.Route.Stroke.Width = 2;
				result.Color = route.Stroke.Color;
				var currentIndex = result.Route.Points.Count - 1;
				var currentMark = LastMarkerAdded.Pop();
				var currentPos = result.Route.Points[currentIndex];
				var dist = Distanse.Pop();
				if (currentMark)
					result.Markers.Add(currentPos);
				while (LastMarkerAdded.Count > 0)
				{
					currentMark = LastMarkerAdded.Pop();
					var index = LastPointsAdded.Pop();
					dist = Distanse.Pop();
					currentIndex -= index;
					currentPos = result.Route.Points[currentIndex];
					if (currentMark)
					{
						result.Markers.Add(currentPos);
					}
				}
				
				routes.Add(result);
				buttonAddRoute.Enabled = true;
				groupBoxRouteEdit.Enabled = false;
				isEdit = false;
				lastPoint = PointLatLng.Empty;
				UpdateRoutesList();
				route = null;
			}
		}

		private void AddNewRoute()
		{
			if (!isEdit)
			{
				if((from r in routes where r.Name == template + textBoxNumber.Text select r).Any())
				{
					MessageBox.Show("Такой маршрут уже существует!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				LastMarkerAdded.Clear();
				LastPointsAdded.Clear();
				route = new GMapRoute(template + textBoxNumber.Text);
				route.Stroke.Width = 5;
				route.Stroke.Color = Color.Red;
				routeOverlay.Routes.Add(route);
				buttonAddRoute.Enabled = false;
				groupBoxRouteEdit.Enabled = true;
				isEdit = true;
			}
		}

		private void LoadFile()
		{
			var ofd = new OpenFileDialog();
			ofd.Filter = "Routes Files(*rts) | *.rts";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				New();
				GlobalObject GO = new GlobalObject();
				try
				{
					GO = new BinSerializer.BinSerializer().DeserializeObject<GlobalObject>(ofd.FileName);
					routes = GO.routes;
					Stops = GO.stops;
				}
				catch
				{
					MessageBox.Show("Не удалось открыть файл!","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
				UpdateData();
			}
		}

		private void UpdateRoutes()
		{
			routeOverlay.Routes.Clear();
			for (int i = 0; i < routes.Count; i++)
			{
				var item = routes[i];
				if (!item.IsVisible)
					continue;
				routeOverlay.Routes.Add(new GMapRoute(item.Route.Points, item.Name));
				//routeOverlay.Routes[i].Stroke.Color = item.Color;
				routeOverlay.Routes.Last().Stroke.Width = 2;
			}
			UpdateRoutesList();
		}

		private void UpdateStops()
		{
			markersOverlay.Markers.Clear();
			foreach (var m in Stops)
			{
				markersOverlay.Markers.Add(m);
			}
		}

		private void UpdateData()
		{
			UpdateRoutes();
			UpdateStops();
			RefreshMap();
		}

		private void SaveFile()
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = "Routes Files(*rts) | *.rts";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				try
				{
					GlobalObject GO = new GlobalObject();
					GO.stops = Stops;
					GO.routes = routes;
					new BinSerializer.BinSerializer().SerializeObject<GlobalObject>(sfd.FileName, GO);
				}
				catch 
				{ }
			}
		}

		private void New()
		{
			routes.Clear();
			LastPointsAdded.Clear();
			LastMarkerAdded.Clear();
			lastPoint = PointLatLng.Empty;
			markersOverlay.Markers.Clear();
			routeOverlay.Routes.Clear();
			UpdateRoutesList();
		}

		private void UpdateRoutesList()
		{
			(listBox1.DataSource as BindingSource).DataSource = routes;
			(listBox1.DataSource as BindingSource).ResetBindings(false);
		}
	
	}
}
