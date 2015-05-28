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
	public partial class fmCreateShedule : Form
	{
		GlobalObject m_Data;

		public fmCreateShedule(GlobalObject data)
		{
			m_Data = data;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CreateShedule();
		}

		private void dataGridViewStartTimes_SelectionChanged(object sender, EventArgs e)
		{
			if(dataGridViewStartTimes.SelectedRows.Count == 0)
				return;
			var item = (dataGridViewStartTimes.SelectedRows[0]).DataBoundItem as TimeList;
			if (item == null)
				return;
			dataGridViewStopsTimes.DataSource = new BindingSource();
			(dataGridViewStopsTimes.DataSource as BindingSource).DataSource = item.Shedule;			
		}

//-------------------------------------------------------

		private void CreateShedule()
		{
			

			var StopsDelay = (int)numericUpDown1.Value;
			var StartTime = dateTimePickerStart.Value.TimeOfDay;
			var EndTime = dateTimePickerEnd.Value.TimeOfDay;
			var Stops = m_Data.stops;
			var Routes = m_Data.routes;

			foreach (var R in Routes)
			{
				if(R.Speed == 0)
				{
					MessageBox.Show("Укажите скорость движения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if(R.AutoNumber == 0)
				{
					MessageBox.Show("Укажите кол-во авто!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			List<TimeList> TimeList = new List<TimeList>();

			foreach (var R in Routes)
			{
				int fullTimeMinutes = (int)(R.Distanse / R.Speed * 60 + StopsDelay * R.Markers.Count);
				TimeSpan fullRouteTime = new TimeSpan(0, fullTimeMinutes, 0);
				TimeSpan stepTime = new TimeSpan(0, 0, (int)(fullRouteTime.TotalSeconds * 2 / R.AutoNumber));
				TimeList TL = new Dispatching.TimeList();
				TL.Name = R.Name;
				for (TimeSpan t = StartTime; t < EndTime; t = t.Add(stepTime))
				{
					TL.Time += String.Format("{0:hh\\:mm} ", t);
				}
				TL.Shedule = new List<StopsShedule>();
				for (int i = R.Markers.Count - 1; i > 0; i--)
				{
					var SS = new StopsShedule();
					SS.Name = R.StopsNames[i];
					SS.Time = String.Format("{0:hh\\:mm}", new TimeSpan(0, 0, (int)(R.MarkersDistance[i] / R.Speed * 3600 + (R.Markers.Count - 1 - i) * StopsDelay * 60)));
					TL.Shedule.Add(SS);
				}
				TimeList.Add(TL);
			}
			dataGridViewStartTimes.DataSource = new BindingSource();
			(dataGridViewStartTimes.DataSource as BindingSource).DataSource = TimeList;
		}

		
	}

	class TimeList
	{
		[DisplayName("Название")]
		public String Name { get; set; }
		[DisplayName("График")]
		public String Time { get; set; }
		[Browsable(false)]
		public List<StopsShedule> Shedule { get; set; }
	}

	class StopsShedule
	{
		[DisplayName("Остановка")]
		public String Name { get; set; }
		[DisplayName("Время от начала")]
		public String Time { get; set; }
	}
}
