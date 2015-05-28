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
			StopsNames = new List<string>();
		}
		[Browsable(false)]
		public GMapRoute Route { get; set; }
		[Browsable(false)]
		public List<PointLatLng> Markers { get; set; }
		[Browsable(false)]
		public List<String> StopsNames { get; set; }
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

		[DisplayName("Показать")]
		public Boolean IsVisible
		{
			get
			{
				return Route.IsVisible;
			}
			set
			{
				Route.IsVisible = value;
			}
		}

		[DisplayName("Расстояние(км)")]
		public Double Distanse {
			get
			{
				return Math.Round(Route.Distance, 2);
			}
		}

		[DisplayName("Кол-во остановок")]
		public Double StopsNumber
		{
			get
			{
				return Markers.Count;
			}
		}

		[DisplayName("Ср. скорость(км/ч)")]
		public Double Speed { get; set; }

		[DisplayName("Объем перевозок(чел/день)")]
		public Double DayPeople { get; set; }

		[DisplayName("Кол-во мест")]
		public Double InBusPeople { get; set; }

		[DisplayName("Кол-во авто")]
		public Int32 AutoNumber { get; set; }

		[Browsable(false)]
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
