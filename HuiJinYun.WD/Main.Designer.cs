namespace HuiJinYun.WD
{
    partial class Main
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
            this.bt_automaticStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_Manual = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_automatic = new System.Windows.Forms.RadioButton();
            this.bt_Initialization = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_speed = new System.Windows.Forms.ComboBox();
            this.rb_agv_05 = new System.Windows.Forms.RadioButton();
            this.bt_Output_fan_close = new System.Windows.Forms.Button();
            this.bt_Output_zheng_close = new System.Windows.Forms.Button();
            this.bt_Output_fan_open = new System.Windows.Forms.Button();
            this.bt_Output_zheng_open = new System.Windows.Forms.Button();
            this.bt_FrontLine = new System.Windows.Forms.Button();
            this.rb_agv_02 = new System.Windows.Forms.RadioButton();
            this.rb_agv_01 = new System.Windows.Forms.RadioButton();
            this.bt_Vulcanization_in = new System.Windows.Forms.Button();
            this.bt_Vulcanization_out = new System.Windows.Forms.Button();
            this.bt_Enlace = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_automaticStart
            // 
            this.bt_automaticStart.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_automaticStart.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_automaticStart.Location = new System.Drawing.Point(30, 20);
            this.bt_automaticStart.Name = "bt_automaticStart";
            this.bt_automaticStart.Size = new System.Drawing.Size(114, 56);
            this.bt_automaticStart.TabIndex = 0;
            this.bt_automaticStart.Text = "开始";
            this.bt_automaticStart.UseVisualStyleBackColor = false;
            this.bt_automaticStart.Click += new System.EventHandler(this.bt_automaticStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "东风美晨自动硫化生产线";
            // 
            // rb_Manual
            // 
            this.rb_Manual.AutoSize = true;
            this.rb_Manual.Checked = true;
            this.rb_Manual.Location = new System.Drawing.Point(23, 34);
            this.rb_Manual.Name = "rb_Manual";
            this.rb_Manual.Size = new System.Drawing.Size(47, 16);
            this.rb_Manual.TabIndex = 2;
            this.rb_Manual.TabStop = true;
            this.rb_Manual.Text = "手动";
            this.rb_Manual.UseVisualStyleBackColor = true;
            this.rb_Manual.CheckedChanged += new System.EventHandler(this.rb_Manual_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_automatic);
            this.groupBox1.Controls.Add(this.rb_Manual);
            this.groupBox1.Location = new System.Drawing.Point(6, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行方式";
            // 
            // rb_automatic
            // 
            this.rb_automatic.AutoSize = true;
            this.rb_automatic.Location = new System.Drawing.Point(86, 34);
            this.rb_automatic.Name = "rb_automatic";
            this.rb_automatic.Size = new System.Drawing.Size(47, 16);
            this.rb_automatic.TabIndex = 2;
            this.rb_automatic.Text = "自动";
            this.rb_automatic.UseVisualStyleBackColor = true;
            this.rb_automatic.CheckedChanged += new System.EventHandler(this.rb_automatic_CheckedChanged);
            // 
            // bt_Initialization
            // 
            this.bt_Initialization.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Initialization.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Initialization.Location = new System.Drawing.Point(29, 33);
            this.bt_Initialization.Name = "bt_Initialization";
            this.bt_Initialization.Size = new System.Drawing.Size(132, 110);
            this.bt_Initialization.TabIndex = 0;
            this.bt_Initialization.Text = "初始化";
            this.bt_Initialization.UseVisualStyleBackColor = false;
            this.bt_Initialization.Click += new System.EventHandler(this.bt_Initialization_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_automaticStart);
            this.groupBox2.Location = new System.Drawing.Point(748, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 90);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自动化操作";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.bt_Vulcanization_in);
            this.groupBox3.Controls.Add(this.bt_Vulcanization_out);
            this.groupBox3.Controls.Add(this.bt_Enlace);
            this.groupBox3.Location = new System.Drawing.Point(265, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 308);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分段操作";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.cmb_speed);
            this.groupBox6.Controls.Add(this.rb_agv_05);
            this.groupBox6.Controls.Add(this.bt_Output_fan_close);
            this.groupBox6.Controls.Add(this.bt_Output_zheng_close);
            this.groupBox6.Controls.Add(this.bt_Output_fan_open);
            this.groupBox6.Controls.Add(this.bt_Output_zheng_open);
            this.groupBox6.Controls.Add(this.bt_FrontLine);
            this.groupBox6.Controls.Add(this.rb_agv_02);
            this.groupBox6.Controls.Add(this.rb_agv_01);
            this.groupBox6.Location = new System.Drawing.Point(210, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(237, 288);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "AGV控制";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "AGV编号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "AGV速度：";
            // 
            // cmb_speed
            // 
            this.cmb_speed.FormattingEnabled = true;
            this.cmb_speed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmb_speed.Location = new System.Drawing.Point(73, 54);
            this.cmb_speed.Name = "cmb_speed";
            this.cmb_speed.Size = new System.Drawing.Size(121, 20);
            this.cmb_speed.TabIndex = 1;
            // 
            // rb_agv_05
            // 
            this.rb_agv_05.AutoSize = true;
            this.rb_agv_05.Location = new System.Drawing.Point(179, 21);
            this.rb_agv_05.Name = "rb_agv_05";
            this.rb_agv_05.Size = new System.Drawing.Size(35, 16);
            this.rb_agv_05.TabIndex = 0;
            this.rb_agv_05.Text = "05";
            this.rb_agv_05.UseVisualStyleBackColor = true;
            // 
            // bt_Output_fan_close
            // 
            this.bt_Output_fan_close.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Output_fan_close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Output_fan_close.Location = new System.Drawing.Point(120, 212);
            this.bt_Output_fan_close.Name = "bt_Output_fan_close";
            this.bt_Output_fan_close.Size = new System.Drawing.Size(108, 60);
            this.bt_Output_fan_close.TabIndex = 0;
            this.bt_Output_fan_close.Text = "滚轮-反-关";
            this.bt_Output_fan_close.UseVisualStyleBackColor = false;
            this.bt_Output_fan_close.Click += new System.EventHandler(this.bt_Output_fan_close_Click);
            // 
            // bt_Output_zheng_close
            // 
            this.bt_Output_zheng_close.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Output_zheng_close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Output_zheng_close.Location = new System.Drawing.Point(120, 145);
            this.bt_Output_zheng_close.Name = "bt_Output_zheng_close";
            this.bt_Output_zheng_close.Size = new System.Drawing.Size(108, 60);
            this.bt_Output_zheng_close.TabIndex = 0;
            this.bt_Output_zheng_close.Text = "滚轮-正-关";
            this.bt_Output_zheng_close.UseVisualStyleBackColor = false;
            this.bt_Output_zheng_close.Click += new System.EventHandler(this.bt_Output_zheng_close_Click);
            // 
            // bt_Output_fan_open
            // 
            this.bt_Output_fan_open.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Output_fan_open.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Output_fan_open.Location = new System.Drawing.Point(6, 212);
            this.bt_Output_fan_open.Name = "bt_Output_fan_open";
            this.bt_Output_fan_open.Size = new System.Drawing.Size(108, 60);
            this.bt_Output_fan_open.TabIndex = 0;
            this.bt_Output_fan_open.Text = "滚轮-反-开";
            this.bt_Output_fan_open.UseVisualStyleBackColor = false;
            this.bt_Output_fan_open.Click += new System.EventHandler(this.bt_Output_fan_open_Click);
            // 
            // bt_Output_zheng_open
            // 
            this.bt_Output_zheng_open.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Output_zheng_open.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Output_zheng_open.Location = new System.Drawing.Point(6, 146);
            this.bt_Output_zheng_open.Name = "bt_Output_zheng_open";
            this.bt_Output_zheng_open.Size = new System.Drawing.Size(108, 60);
            this.bt_Output_zheng_open.TabIndex = 0;
            this.bt_Output_zheng_open.Text = "滚轮-正-开";
            this.bt_Output_zheng_open.UseVisualStyleBackColor = false;
            this.bt_Output_zheng_open.Click += new System.EventHandler(this.bt_Output_zheng_open_Click);
            // 
            // bt_FrontLine
            // 
            this.bt_FrontLine.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_FrontLine.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_FrontLine.Location = new System.Drawing.Point(19, 93);
            this.bt_FrontLine.Name = "bt_FrontLine";
            this.bt_FrontLine.Size = new System.Drawing.Size(195, 47);
            this.bt_FrontLine.TabIndex = 0;
            this.bt_FrontLine.Text = "前巡";
            this.bt_FrontLine.UseVisualStyleBackColor = false;
            this.bt_FrontLine.Click += new System.EventHandler(this.bt_FrontLine_Click);
            // 
            // rb_agv_02
            // 
            this.rb_agv_02.AutoSize = true;
            this.rb_agv_02.Location = new System.Drawing.Point(132, 20);
            this.rb_agv_02.Name = "rb_agv_02";
            this.rb_agv_02.Size = new System.Drawing.Size(35, 16);
            this.rb_agv_02.TabIndex = 0;
            this.rb_agv_02.Text = "02";
            this.rb_agv_02.UseVisualStyleBackColor = true;
            // 
            // rb_agv_01
            // 
            this.rb_agv_01.AutoSize = true;
            this.rb_agv_01.Checked = true;
            this.rb_agv_01.Location = new System.Drawing.Point(79, 20);
            this.rb_agv_01.Name = "rb_agv_01";
            this.rb_agv_01.Size = new System.Drawing.Size(35, 16);
            this.rb_agv_01.TabIndex = 0;
            this.rb_agv_01.TabStop = true;
            this.rb_agv_01.Text = "01";
            this.rb_agv_01.UseVisualStyleBackColor = true;
            // 
            // bt_Vulcanization_in
            // 
            this.bt_Vulcanization_in.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Vulcanization_in.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Vulcanization_in.Location = new System.Drawing.Point(15, 223);
            this.bt_Vulcanization_in.Name = "bt_Vulcanization_in";
            this.bt_Vulcanization_in.Size = new System.Drawing.Size(189, 73);
            this.bt_Vulcanization_in.TabIndex = 0;
            this.bt_Vulcanization_in.Text = "硫化道入口工序";
            this.bt_Vulcanization_in.UseVisualStyleBackColor = false;
            this.bt_Vulcanization_in.Click += new System.EventHandler(this.bt_Vulcanization_in_Click);
            // 
            // bt_Vulcanization_out
            // 
            this.bt_Vulcanization_out.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Vulcanization_out.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Vulcanization_out.Location = new System.Drawing.Point(15, 20);
            this.bt_Vulcanization_out.Name = "bt_Vulcanization_out";
            this.bt_Vulcanization_out.Size = new System.Drawing.Size(189, 77);
            this.bt_Vulcanization_out.TabIndex = 0;
            this.bt_Vulcanization_out.Text = "硫化道出口工序";
            this.bt_Vulcanization_out.UseVisualStyleBackColor = false;
            this.bt_Vulcanization_out.Click += new System.EventHandler(this.bt_Vulcanization_out_Click);
            // 
            // bt_Enlace
            // 
            this.bt_Enlace.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Enlace.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Enlace.Location = new System.Drawing.Point(15, 122);
            this.bt_Enlace.Name = "bt_Enlace";
            this.bt_Enlace.Size = new System.Drawing.Size(189, 75);
            this.bt_Enlace.TabIndex = 0;
            this.bt_Enlace.Text = "包胶缠绕工序";
            this.bt_Enlace.UseVisualStyleBackColor = false;
            this.bt_Enlace.Click += new System.EventHandler(this.bt_Enlace_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.bt_Initialization);
            this.groupBox4.Location = new System.Drawing.Point(22, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 308);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "初始化操作";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(748, 172);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 212);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "操作说明：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "4：分别执行对应的程序";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "3：选择手动或是自动";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "2:初始化程序";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "1:启动U3D动画";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 396);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FET智能生产线";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_automaticStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_Manual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_automatic;
        private System.Windows.Forms.Button bt_Initialization;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bt_Vulcanization_in;
        private System.Windows.Forms.Button bt_Vulcanization_out;
        private System.Windows.Forms.Button bt_Enlace;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rb_agv_05;
        private System.Windows.Forms.RadioButton rb_agv_02;
        private System.Windows.Forms.RadioButton rb_agv_01;
        private System.Windows.Forms.Button bt_FrontLine;
        private System.Windows.Forms.Button bt_Output_fan_close;
        private System.Windows.Forms.Button bt_Output_zheng_close;
        private System.Windows.Forms.Button bt_Output_fan_open;
        private System.Windows.Forms.Button bt_Output_zheng_open;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_speed;
    }
}