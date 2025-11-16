namespace QuanLyCafe
{
    partial class fThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.dtpktoDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkfromDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.d = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(796, 77);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(300, 300);
            this.chartDoanhThu.TabIndex = 4;
            this.chartDoanhThu.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.dtpktoDate);
            this.panel2.Controls.Add(this.dtpkfromDate);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 50);
            this.panel2.TabIndex = 3;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(669, 2);
            this.btnView.Margin = new System.Windows.Forms.Padding(2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(90, 43);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Thống Kê";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpktoDate
            // 
            this.dtpktoDate.Location = new System.Drawing.Point(339, 15);
            this.dtpktoDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpktoDate.Name = "dtpktoDate";
            this.dtpktoDate.Size = new System.Drawing.Size(311, 26);
            this.dtpktoDate.TabIndex = 1;
            // 
            // dtpkfromDate
            // 
            this.dtpkfromDate.Location = new System.Drawing.Point(15, 15);
            this.dtpkfromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpkfromDate.Name = "dtpkfromDate";
            this.dtpkfromDate.Size = new System.Drawing.Size(311, 26);
            this.dtpkfromDate.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.d);
            this.panel1.Location = new System.Drawing.Point(13, 77);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 428);
            this.panel1.TabIndex = 2;
            // 
            // d
            // 
            this.d.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d.Location = new System.Drawing.Point(15, 19);
            this.d.Margin = new System.Windows.Forms.Padding(2);
            this.d.Name = "d";
            this.d.RowHeadersWidth = 82;
            this.d.RowTemplate.Height = 33;
            this.d.Size = new System.Drawing.Size(744, 358);
            this.d.TabIndex = 0;
            // 
            // fThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 532);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fThongKe";
            this.Text = "fThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dtpktoDate;
        private System.Windows.Forms.DateTimePicker dtpkfromDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView d;
    }
}