using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Dispatching
{
	[Serializable]
	public class GMapTableView
	{
		public GMapTableView(GMapRoute RouteBase)
		{
			this.Route = RouteBase;
			Markers = new List<PointLatLng>();
			MarkersDistance = new List<double>();
		}
		[Browsable(false)]
		public GMapRoute Route { get; set; }
		[Browsable(false)]
		public List<PointLatLng> Markers { get; set; }
		[Browsable(false)]
		public List<Double> MarkersDistance { get; set; }
		[DisplayName("Название")]
		public String Name {
			get
			{
				return Route.Name;
			}
			set
			{
				Route.Name = value;
			}
		}
		[DisplayName("Расстояние")]
		public Double Distanse {
			get
			{
				return Route.Distance;
			}
		}
		[DisplayName("Показать")]
		public Boolean IsVisible {
			get
			{
				return Route.IsVisible;
			}
			set
			{
				Route.IsVisible = value;
			}
		}
		[DisplayName("Цвет")]
		public Color Color
		{
			get;
			set;
		}
		public override string ToString()
		{
			return Route.Name;
		}
	}
}
