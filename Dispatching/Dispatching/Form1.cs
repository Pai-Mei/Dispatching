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
		private GMapOverlay markersOverlay;
		private GMapOverlay routeOverlay;
		private PointLatLng lastPoint = PointLatLng.Empty;
		private Stack<Int32> LastPointsAdded = new Stack<Int32>();
		private Stack<Boolean> LastMarkerAdded = new Stack<Boolean>();
		private Stack<Double> Distanse = new Stack<Double>();
		public Form1()
		{
			routes = new List<GMapTableView>();
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
			AddPointToRoute(gmap.Position, true);
		}

		private void buttonAddRoadPoint_Click(object sender, EventArgs e)
		{
			AddPointToRoute(gmap.Position, false);			
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
				LastPointsAdded.Push(1);
				Distanse.Push(route.Distance);
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
				Distanse.Push(route.Distance);
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
				if (LastMarkerAdded.Pop())
					markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
			if (Distanse.Count > 0)
				Distanse.Pop();
			RefreshMap();
		}

		private void FinishEditRoute()
		{
			if (isEdit)
			{
				var result = new GMapTableView(route);
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
			}
		}

		private void AddNewRoute()
		{
			if (!isEdit)
			{
				LastMarkerAdded.Clear();
				LastPointsAdded.Clear();
				route = new GMapRoute(template + textBoxNumber.Text);
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
				try
				{
					routes = new BinSerializer.BinSerializer().DeserializeObject<List<GMapTableView>>(ofd.FileName);
				}
				catch
				{
					MessageBox.Show("Не удалось открыть файл!","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
				UpdateRoutes();
			}
		}

		private void UpdateRoutes()
		{
			routeOverlay.Routes.Clear();
			markersOverlay.Markers.Clear();
			foreach (var item in routes)
			{
				routeOverlay.Routes.Add(item.Route);
				foreach (var mark in item.Markers)
				{
					markersOverlay.Markers.Add(new GMarkerGoogle(mark, GMarkerGoogleType.arrow));
				}
			}
			UpdateRoutesList();
		}

		private void SaveFile()
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = "Routes Files(*rts) | *.rts";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				new BinSerializer.BinSerializer().SerializeObject<List<GMapTableView>>(sfd.FileName, routes);
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
			(listBox1.DataSource as BindingSource).ResetBindings(false);
		}
	}
}
