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
	public partial class fmRoutes : Form
	{
		List<GMapTableView> m_Routes = null;

		public fmRoutes(List<GMapTableView> routes)
		{
			m_Routes = routes;
			InitializeComponent();
		}

		private void fmRoutes_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = new BindingSource();
			(dataGridView1.DataSource as BindingSource).DataSource = m_Routes;
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			dataGridView1.RefreshEdit();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dataGridView1.RefreshEdit();
		}
	}
}
