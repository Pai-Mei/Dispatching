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
	public partial class GetTextDialog : Form
	{
		public String TextResult { get; private set; }

		public GetTextDialog()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			TextResult = textBox1.Text;
		}

		private void GetTextDialog_Load(object sender, EventArgs e)
		{
			this.ActiveControl = textBox1;
		}

		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TextResult = textBox1.Text;
				DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}
	}
}
