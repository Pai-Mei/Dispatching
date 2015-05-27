using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dispatching
{
	[Serializable]
	public class GlobalObject
	{
		public List<GMapTableView> routes { get; set; }
		public List<GMapMarker> stops { get; set; }
	}
}
