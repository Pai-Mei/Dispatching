namespace Dispatching
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.gmap = new GMap.NET.WindowsForms.GMapControl();
			this.groupBoxRoutes = new System.Windows.Forms.GroupBox();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.buttonAddRoute = new System.Windows.Forms.Button();
			this.groupBoxRouteEdit = new System.Windows.Forms.GroupBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonFinish = new System.Windows.Forms.Button();
			this.buttonSetColor = new System.Windows.Forms.Button();
			this.buttonAddStation = new System.Windows.Forms.Button();
			this.buttonAddRoadPoint = new System.Windows.Forms.Button();
			this.checkBoxCircle = new System.Windows.Forms.CheckBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открітьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBoxRoutes.SuspendLayout();
			this.groupBoxRouteEdit.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gmap);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxRoutes);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxNumber);
			this.splitContainer1.Panel2.Controls.Add(this.buttonAddRoute);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxRouteEdit);
			this.splitContainer1.Size = new System.Drawing.Size(669, 387);
			this.splitContainer1.SplitterDistance = 432;
			this.splitContainer1.TabIndex = 0;
			// 
			// gmap
			// 
			this.gmap.Bearing = 0F;
			this.gmap.CanDragMap = true;
			this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
			this.gmap.GrayScaleMode = false;
			this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gmap.LevelsKeepInMemmory = 5;
			this.gmap.Location = new System.Drawing.Point(0, 0);
			this.gmap.MarkersEnabled = true;
			this.gmap.MaxZoom = 20;
			this.gmap.MinZoom = 2;
			this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gmap.Name = "gmap";
			this.gmap.NegativeMode = false;
			this.gmap.PolygonsEnabled = true;
			this.gmap.RetryLoadTile = 0;
			this.gmap.RoutesEnabled = true;
			this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gmap.ShowTileGridLines = false;
			this.gmap.Size = new System.Drawing.Size(428, 383);
			this.gmap.TabIndex = 0;
			this.gmap.Zoom = 10D;
			// 
			// groupBoxRoutes
			// 
			this.groupBoxRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxRoutes.Controls.Add(this.listBox1);
			this.groupBoxRoutes.Location = new System.Drawing.Point(3, 227);
			this.groupBoxRoutes.Name = "groupBoxRoutes";
			this.groupBoxRoutes.Size = new System.Drawing.Size(223, 153);
			this.groupBoxRoutes.TabIndex = 7;
			this.groupBoxRoutes.TabStop = false;
			this.groupBoxRoutes.Text = "Маршруты";
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumber.Location = new System.Drawing.Point(174, 5);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(52, 20);
			this.textBoxNumber.TabIndex = 6;
			// 
			// buttonAddRoute
			// 
			this.buttonAddRoute.Location = new System.Drawing.Point(3, 3);
			this.buttonAddRoute.Name = "buttonAddRoute";
			this.buttonAddRoute.Size = new System.Drawing.Size(165, 23);
			this.buttonAddRoute.TabIndex = 5;
			this.buttonAddRoute.Text = "Добавить новый маршрут";
			this.buttonAddRoute.UseVisualStyleBackColor = true;
			this.buttonAddRoute.Click += new System.EventHandler(this.buttonAddRoute_Click);
			// 
			// groupBoxRouteEdit
			// 
			this.groupBoxRouteEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxRouteEdit.Controls.Add(this.buttonCancel);
			this.groupBoxRouteEdit.Controls.Add(this.buttonFinish);
			this.groupBoxRouteEdit.Controls.Add(this.buttonSetColor);
			this.groupBoxRouteEdit.Controls.Add(this.buttonAddStation);
			this.groupBoxRouteEdit.Controls.Add(this.buttonAddRoadPoint);
			this.groupBoxRouteEdit.Controls.Add(this.checkBoxCircle);
			this.groupBoxRouteEdit.Enabled = false;
			this.groupBoxRouteEdit.Location = new System.Drawing.Point(3, 32);
			this.groupBoxRouteEdit.Name = "groupBoxRouteEdit";
			this.groupBoxRouteEdit.Size = new System.Drawing.Size(223, 189);
			this.groupBoxRouteEdit.TabIndex = 4;
			this.groupBoxRouteEdit.TabStop = false;
			this.groupBoxRouteEdit.Text = "Редактирование маршрута";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(5, 129);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(210, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonFinish
			// 
			this.buttonFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFinish.Location = new System.Drawing.Point(5, 158);
			this.buttonFinish.Name = "buttonFinish";
			this.buttonFinish.Size = new System.Drawing.Size(210, 23);
			this.buttonFinish.TabIndex = 3;
			this.buttonFinish.Text = "Закончить маршрут";
			this.buttonFinish.UseVisualStyleBackColor = true;
			this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
			// 
			// buttonSetColor
			// 
			this.buttonSetColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetColor.Location = new System.Drawing.Point(5, 100);
			this.buttonSetColor.Name = "buttonSetColor";
			this.buttonSetColor.Size = new System.Drawing.Size(210, 23);
			this.buttonSetColor.TabIndex = 4;
			this.buttonSetColor.Text = "Выбрать цвет";
			this.buttonSetColor.UseVisualStyleBackColor = true;
			this.buttonSetColor.Click += new System.EventHandler(this.buttonSetColor_Click);
			// 
			// buttonAddStation
			// 
			this.buttonAddStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddStation.Location = new System.Drawing.Point(6, 19);
			this.buttonAddStation.Name = "buttonAddStation";
			this.buttonAddStation.Size = new System.Drawing.Size(211, 23);
			this.buttonAddStation.TabIndex = 0;
			this.buttonAddStation.Text = "Добавить остановку";
			this.buttonAddStation.UseVisualStyleBackColor = true;
			this.buttonAddStation.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonAddRoadPoint
			// 
			this.buttonAddRoadPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddRoadPoint.Location = new System.Drawing.Point(5, 48);
			this.buttonAddRoadPoint.Name = "buttonAddRoadPoint";
			this.buttonAddRoadPoint.Size = new System.Drawing.Size(211, 23);
			this.buttonAddRoadPoint.TabIndex = 1;
			this.buttonAddRoadPoint.Text = "Добавить точку маршрута";
			this.buttonAddRoadPoint.UseVisualStyleBackColor = true;
			this.buttonAddRoadPoint.Click += new System.EventHandler(this.buttonAddRoadPoint_Click);
			// 
			// checkBoxCircle
			// 
			this.checkBoxCircle.AutoSize = true;
			this.checkBoxCircle.Location = new System.Drawing.Point(6, 77);
			this.checkBoxCircle.Name = "checkBoxCircle";
			this.checkBoxCircle.Size = new System.Drawing.Size(128, 17);
			this.checkBoxCircle.TabIndex = 2;
			this.checkBoxCircle.Text = "Кольцевой маршрут";
			this.checkBoxCircle.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.настройкиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(669, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem,
            this.открітьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// очиститьToolStripMenuItem
			// 
			this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
			this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.очиститьToolStripMenuItem.Text = "Очистить";
			this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 6);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.выходToolStripMenuItem.Text = "Выход";
			// 
			// правкаToolStripMenuItem
			// 
			this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменаToolStripMenuItem});
			this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
			this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.правкаToolStripMenuItem.Text = "Правка";
			// 
			// отменаToolStripMenuItem
			// 
			this.отменаToolStripMenuItem.Name = "отменаToolStripMenuItem";
			this.отменаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.отменаToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.отменаToolStripMenuItem.Text = "Отмена";
			this.отменаToolStripMenuItem.Click += new System.EventHandler(this.отменаToolStripMenuItem_Click);
			// 
			// настройкиToolStripMenuItem
			// 
			this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
			this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.настройкиToolStripMenuItem.Text = "Настройки";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(3, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(217, 134);
			this.listBox1.TabIndex = 1;
			// 
			// сохранитьToolStripMenuItem
			// 
			this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
			this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.сохранитьToolStripMenuItem.Text = "Сохранить";
			this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
			// 
			// открітьToolStripMenuItem
			// 
			this.открітьToolStripMenuItem.Name = "открітьToolStripMenuItem";
			this.открітьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.открітьToolStripMenuItem.Text = "Открыть";
			this.открітьToolStripMenuItem.Click += new System.EventHandler(this.открітьToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 411);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Расписание движение автотранспорта";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBoxRoutes.ResumeLayout(false);
			this.groupBoxRouteEdit.ResumeLayout(false);
			this.groupBoxRouteEdit.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private GMap.NET.WindowsForms.GMapControl gmap;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
		private System.Windows.Forms.Button buttonAddStation;
		private System.Windows.Forms.Button buttonAddRoadPoint;
		private System.Windows.Forms.CheckBox checkBoxCircle;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.Button buttonAddRoute;
		private System.Windows.Forms.GroupBox groupBoxRouteEdit;
		private System.Windows.Forms.Button buttonFinish;
		private System.Windows.Forms.Button buttonSetColor;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отменаToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxRoutes;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открітьToolStripMenuItem;

	}
}

