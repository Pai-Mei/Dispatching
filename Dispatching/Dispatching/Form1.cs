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
		public Form1()
		{
			InitializeComponent();
			gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
			gmap.SetPositionByKeywords("Krivoy Rog, Ukraine");
		}

		private void gmap_Click(object sender, EventArgs e)
		{
			GMapOverlay markersOverlay = new GMapOverlay("markers");
			GMarkerGoogle marker = new GMarkerGoogle(gmap.Position,
			  GMarkerGoogleType.green);
			markersOverlay.Markers.Add(marker);
			gmap.Overlays.Add(markersOverlay);
			gmap.Zoom += 1;
			gmap.Refresh();
			gmap.Zoom -= 1;
			gmap.Refresh();
		}
	}
}
