using System;

namespace HuiJinYun.WD
{
    partial class GCode_Test
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
            this.components = new System.ComponentModel.Container();
            this.lb_xAxis = new System.Windows.Forms.Label();
            this.lb_yAxis = new System.Windows.Forms.Label();
            this.lb_zAxis = new System.Windows.Forms.Label();
            this.lb_wAxis = new System.Windows.Forms.Label();
            this.lb_xAxisLocation = new System.Windows.Forms.Label();
            this.lb_yAxisLocation = new System.Windows.Forms.Label();
            this.lb_zAxisLocation = new System.Windows.Forms.Label();
            this.lb_uAxisLocation = new System.Windows.Forms.Label();
            this.lb_unit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_manual = new System.Windows.Forms.Button();
            this.bt_automatic = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_linkState = new System.Windows.Forms.Label();
            this.lb_runningState = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lb_xAxis
            // 
            this.lb_xAxis.AutoSize = true;
            this.lb_xAxis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_xAxis.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_xAxis.Location = new System.Drawing.Point(265, 90);
            this.lb_xAxis.Name = "lb_xAxis";
            this.lb_xAxis.Size = new System.Drawing.Size(57, 29);
            this.lb_xAxis.TabIndex = 1;
            this.lb_xAxis.Text = "X轴";
            // 
            // lb_yAxis
            // 
            this.lb_yAxis.AutoSize = true;
            this.lb_yAxis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_yAxis.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_yAxis.Location = new System.Drawing.Point(265, 140);
            this.lb_yAxis.Name = "lb_yAxis";
            this.lb_yAxis.Size = new System.Drawing.Size(57, 29);
            this.lb_yAxis.TabIndex = 2;
            this.lb_yAxis.Text = "Y轴";
            this.lb_yAxis.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lb_zAxis
            // 
            this.lb_zAxis.AutoSize = true;
            this.lb_zAxis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_zAxis.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_zAxis.Location = new System.Drawing.Point(265, 190);
            this.lb_zAxis.Name = "lb_zAxis";
            this.lb_zAxis.Size = new System.Drawing.Size(57, 29);
            this.lb_zAxis.TabIndex = 3;
            this.lb_zAxis.Text = "Z轴";
            // 
            // lb_wAxis
            // 
            this.lb_wAxis.AutoSize = true;
            this.lb_wAxis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_wAxis.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_wAxis.Location = new System.Drawing.Point(265, 240);
            this.lb_wAxis.Name = "lb_wAxis";
            this.lb_wAxis.Size = new System.Drawing.Size(57, 29);
            this.lb_wAxis.TabIndex = 4;
            this.lb_wAxis.Text = "U轴";
            // 
            // lb_xAxisLocation
            // 
            this.lb_xAxisLocation.AutoSize = true;
            this.lb_xAxisLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_xAxisLocation.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_xAxisLocation.Location = new System.Drawing.Point(328, 97);
            this.lb_xAxisLocation.Name = "lb_xAxisLocation";
            this.lb_xAxisLocation.Size = new System.Drawing.Size(2, 23);
            this.lb_xAxisLocation.TabIndex = 5;
            // 
            // lb_yAxisLocation
            // 
            this.lb_yAxisLocation.AutoSize = true;
            this.lb_yAxisLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_yAxisLocation.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_yAxisLocation.Location = new System.Drawing.Point(328, 147);
            this.lb_yAxisLocation.Name = "lb_yAxisLocation";
            this.lb_yAxisLocation.Size = new System.Drawing.Size(2, 23);
            this.lb_yAxisLocation.TabIndex = 6;
            // 
            // lb_zAxisLocation
            // 
            this.lb_zAxisLocation.AutoSize = true;
            this.lb_zAxisLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_zAxisLocation.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_zAxisLocation.Location = new System.Drawing.Point(328, 197);
            this.lb_zAxisLocation.Name = "lb_zAxisLocation";
            this.lb_zAxisLocation.Size = new System.Drawing.Size(2, 23);
            this.lb_zAxisLocation.TabIndex = 7;
            // 
            // lb_uAxisLocation
            // 
            this.lb_uAxisLocation.AutoSize = true;
            this.lb_uAxisLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_uAxisLocation.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_uAxisLocation.Location = new System.Drawing.Point(328, 247);
            this.lb_uAxisLocation.Name = "lb_uAxisLocation";
            this.lb_uAxisLocation.Size = new System.Drawing.Size(2, 23);
            this.lb_uAxisLocation.TabIndex = 8;
            // 
            // lb_unit
            // 
            this.lb_unit.AutoSize = true;
            this.lb_unit.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_unit.Location = new System.Drawing.Point(433, 97);
            this.lb_unit.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lb_unit.Name = "lb_unit";
            this.lb_unit.Size = new System.Drawing.Size(32, 21);
            this.lb_unit.TabIndex = 9;
            this.lb_unit.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(433, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(433, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(433, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "mm";
            // 
            // bt_manual
            // 
            this.bt_manual.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_manual.Location = new System.Drawing.Point(222, 309);
            this.bt_manual.Name = "bt_manual";
            this.bt_manual.Size = new System.Drawing.Size(112, 69);
            this.bt_manual.TabIndex = 13;
            this.bt_manual.Text = "手动";
            this.bt_manual.UseVisualStyleBackColor = true;
            this.bt_manual.Click += new System.EventHandler(this.bt_manual_Click);
            this.bt_manual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_manual_Click);
            // 
            // bt_automatic
            // 
            this.bt_automatic.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_automatic.Location = new System.Drawing.Point(393, 309);
            this.bt_automatic.Name = "bt_automatic";
            this.bt_automatic.Size = new System.Drawing.Size(112, 69);
            this.bt_automatic.TabIndex = 14;
            this.bt_automatic.Text = "自动";
            this.bt_automatic.UseVisualStyleBackColor = true;
            this.bt_automatic.Click += new System.EventHandler(this.bt_automatic_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "链接状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "运行状态";
            // 
            // lb_linkState
            // 
            this.lb_linkState.AutoSize = true;
            this.lb_linkState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_linkState.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_linkState.ForeColor = System.Drawing.Color.Black;
            this.lb_linkState.Location = new System.Drawing.Point(103, 8);
            this.lb_linkState.Name = "lb_linkState";
            this.lb_linkState.Size = new System.Drawing.Size(2, 23);
            this.lb_linkState.TabIndex = 17;
            // 
            // lb_runningState
            // 
            this.lb_runningState.AutoSize = true;
            this.lb_runningState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_runningState.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_runningState.ForeColor = System.Drawing.Color.Black;
            this.lb_runningState.Location = new System.Drawing.Point(103, 53);
            this.lb_runningState.Name = "lb_runningState";
            this.lb_runningState.Size = new System.Drawing.Size(2, 23);
            this.lb_runningState.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(542, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "label6";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GCode_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 412);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_runningState);
            this.Controls.Add(this.lb_linkState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_automatic);
            this.Controls.Add(this.bt_manual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_unit);
            this.Controls.Add(this.lb_uAxisLocation);
            this.Controls.Add(this.lb_zAxisLocation);
            this.Controls.Add(this.lb_yAxisLocation);
            this.Controls.Add(this.lb_xAxisLocation);
            this.Controls.Add(this.lb_wAxis);
            this.Controls.Add(this.lb_zAxis);
            this.Controls.Add(this.lb_yAxis);
            this.Controls.Add(this.lb_xAxis);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GCode_Test";
            this.Text = "主页面";
            this.Load += new System.EventHandler(this.GCode_Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Label lb_xAxis;
        private System.Windows.Forms.Label lb_yAxis;
        private System.Windows.Forms.Label lb_zAxis;
        private System.Windows.Forms.Label lb_wAxis;
        private EventHandler label1_Click;
        private System.Windows.Forms.Label lb_xAxisLocation;
        private System.Windows.Forms.Label lb_yAxisLocation;
        private System.Windows.Forms.Label lb_zAxisLocation;
        private System.Windows.Forms.Label lb_uAxisLocation;
        private System.Windows.Forms.Label lb_unit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_manual;
        private System.Windows.Forms.Button bt_automatic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_linkState;
        private System.Windows.Forms.Label lb_runningState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
    }
}