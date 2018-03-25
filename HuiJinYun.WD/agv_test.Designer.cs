namespace HuiJinYun.WD
{
    partial class agv_test
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
            this.bt_agv_qinjing = new System.Windows.Forms.Button();
            this.bt_agv_houtui = new System.Windows.Forms.Button();
            this.bt_agv_right = new System.Windows.Forms.Button();
            this.bt_agv_left = new System.Windows.Forms.Button();
            this.bt_agv_stop = new System.Windows.Forms.Button();
            this.bt_Output = new System.Windows.Forms.Button();
            this.bt_Output_close = new System.Windows.Forms.Button();
            this.bt_Output_fan = new System.Windows.Forms.Button();
            this.bt_Output_fan_close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_carnumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Write_Read_data = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_write_Read = new System.Windows.Forms.Button();
            this.tb_read_data = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Read_Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Write_data = new System.Windows.Forms.TextBox();
            this.tb_Write_Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_Write = new System.Windows.Forms.Button();
            this.bt_Read = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_agv_qinjing
            // 
            this.bt_agv_qinjing.Location = new System.Drawing.Point(144, 103);
            this.bt_agv_qinjing.Name = "bt_agv_qinjing";
            this.bt_agv_qinjing.Size = new System.Drawing.Size(96, 67);
            this.bt_agv_qinjing.TabIndex = 1;
            this.bt_agv_qinjing.Text = "前进";
            this.bt_agv_qinjing.UseVisualStyleBackColor = true;
            this.bt_agv_qinjing.Click += new System.EventHandler(this.bt_agv_qinjing_Click);
            // 
            // bt_agv_houtui
            // 
            this.bt_agv_houtui.Location = new System.Drawing.Point(144, 295);
            this.bt_agv_houtui.Name = "bt_agv_houtui";
            this.bt_agv_houtui.Size = new System.Drawing.Size(96, 67);
            this.bt_agv_houtui.TabIndex = 2;
            this.bt_agv_houtui.Text = "后退";
            this.bt_agv_houtui.UseVisualStyleBackColor = true;
            this.bt_agv_houtui.Click += new System.EventHandler(this.bt_agv_houtui_Click);
            // 
            // bt_agv_right
            // 
            this.bt_agv_right.Location = new System.Drawing.Point(286, 129);
            this.bt_agv_right.Name = "bt_agv_right";
            this.bt_agv_right.Size = new System.Drawing.Size(96, 67);
            this.bt_agv_right.TabIndex = 3;
            this.bt_agv_right.Text = "右转";
            this.bt_agv_right.UseVisualStyleBackColor = true;
            this.bt_agv_right.Click += new System.EventHandler(this.bt_agv_right_Click);
            // 
            // bt_agv_left
            // 
            this.bt_agv_left.Location = new System.Drawing.Point(12, 129);
            this.bt_agv_left.Name = "bt_agv_left";
            this.bt_agv_left.Size = new System.Drawing.Size(96, 67);
            this.bt_agv_left.TabIndex = 4;
            this.bt_agv_left.Text = "左转";
            this.bt_agv_left.UseVisualStyleBackColor = true;
            this.bt_agv_left.Click += new System.EventHandler(this.bt_agv_left_Click);
            // 
            // bt_agv_stop
            // 
            this.bt_agv_stop.Location = new System.Drawing.Point(144, 188);
            this.bt_agv_stop.Name = "bt_agv_stop";
            this.bt_agv_stop.Size = new System.Drawing.Size(96, 67);
            this.bt_agv_stop.TabIndex = 5;
            this.bt_agv_stop.Text = "停止";
            this.bt_agv_stop.UseVisualStyleBackColor = true;
            this.bt_agv_stop.Click += new System.EventHandler(this.bt_agv_stop_Click);
            // 
            // bt_Output
            // 
            this.bt_Output.BackColor = System.Drawing.Color.Red;
            this.bt_Output.Location = new System.Drawing.Point(286, 227);
            this.bt_Output.Name = "bt_Output";
            this.bt_Output.Size = new System.Drawing.Size(96, 67);
            this.bt_Output.TabIndex = 6;
            this.bt_Output.Text = "输出-正-开";
            this.bt_Output.UseVisualStyleBackColor = false;
            this.bt_Output.Click += new System.EventHandler(this.bt_Output_Click);
            // 
            // bt_Output_close
            // 
            this.bt_Output_close.BackColor = System.Drawing.Color.Red;
            this.bt_Output_close.Location = new System.Drawing.Point(286, 300);
            this.bt_Output_close.Name = "bt_Output_close";
            this.bt_Output_close.Size = new System.Drawing.Size(96, 67);
            this.bt_Output_close.TabIndex = 7;
            this.bt_Output_close.Text = "输出-正-关";
            this.bt_Output_close.UseVisualStyleBackColor = false;
            this.bt_Output_close.Click += new System.EventHandler(this.bt_Output_close_Click);
            // 
            // bt_Output_fan
            // 
            this.bt_Output_fan.BackColor = System.Drawing.Color.Red;
            this.bt_Output_fan.Location = new System.Drawing.Point(12, 227);
            this.bt_Output_fan.Name = "bt_Output_fan";
            this.bt_Output_fan.Size = new System.Drawing.Size(96, 67);
            this.bt_Output_fan.TabIndex = 8;
            this.bt_Output_fan.Text = "输出-反-开";
            this.bt_Output_fan.UseVisualStyleBackColor = false;
            this.bt_Output_fan.Click += new System.EventHandler(this.bt_Output_fan_Click);
            // 
            // bt_Output_fan_close
            // 
            this.bt_Output_fan_close.BackColor = System.Drawing.Color.Red;
            this.bt_Output_fan_close.Location = new System.Drawing.Point(12, 300);
            this.bt_Output_fan_close.Name = "bt_Output_fan_close";
            this.bt_Output_fan_close.Size = new System.Drawing.Size(96, 67);
            this.bt_Output_fan_close.TabIndex = 9;
            this.bt_Output_fan_close.Text = "输出-反-关";
            this.bt_Output_fan_close.UseVisualStyleBackColor = false;
            this.bt_Output_fan_close.Click += new System.EventHandler(this.bt_Output_fan_close_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 67);
            this.button1.TabIndex = 10;
            this.button1.Text = "AGV状态监测";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(41, 17);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 11;
            this.tb_ip.Text = "192.168.10.46";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "IP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "车辆编号：";
            // 
            // tb_carnumber
            // 
            this.tb_carnumber.Location = new System.Drawing.Point(83, 48);
            this.tb_carnumber.Name = "tb_carnumber";
            this.tb_carnumber.Size = new System.Drawing.Size(100, 21);
            this.tb_carnumber.TabIndex = 14;
            this.tb_carnumber.Text = "6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Write_Read_data);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bt_write_Read);
            this.groupBox1.Controls.Add(this.tb_read_data);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_Read_Port);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_Write_data);
            this.groupBox1.Controls.Add(this.tb_Write_Port);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.bt_Write);
            this.groupBox1.Controls.Add(this.bt_Read);
            this.groupBox1.Location = new System.Drawing.Point(438, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 374);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "龙门输出测试";
            // 
            // tb_Write_Read_data
            // 
            this.tb_Write_Read_data.Location = new System.Drawing.Point(90, 91);
            this.tb_Write_Read_data.Name = "tb_Write_Read_data";
            this.tb_Write_Read_data.Size = new System.Drawing.Size(100, 21);
            this.tb_Write_Read_data.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "输出读取：";
            // 
            // bt_write_Read
            // 
            this.bt_write_Read.Location = new System.Drawing.Point(152, 135);
            this.bt_write_Read.Name = "bt_write_Read";
            this.bt_write_Read.Size = new System.Drawing.Size(75, 23);
            this.bt_write_Read.TabIndex = 23;
            this.bt_write_Read.Text = "输出读取";
            this.bt_write_Read.UseVisualStyleBackColor = true;
            this.bt_write_Read.Click += new System.EventHandler(this.bt_write_Read_Click);
            // 
            // tb_read_data
            // 
            this.tb_read_data.Location = new System.Drawing.Point(94, 259);
            this.tb_read_data.Name = "tb_read_data";
            this.tb_read_data.Size = new System.Drawing.Size(100, 21);
            this.tb_read_data.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "输入数值：";
            // 
            // tb_Read_Port
            // 
            this.tb_Read_Port.Location = new System.Drawing.Point(90, 227);
            this.tb_Read_Port.Name = "tb_Read_Port";
            this.tb_Read_Port.Size = new System.Drawing.Size(100, 21);
            this.tb_Read_Port.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "输入端口：";
            // 
            // tb_Write_data
            // 
            this.tb_Write_data.Location = new System.Drawing.Point(90, 56);
            this.tb_Write_data.Name = "tb_Write_data";
            this.tb_Write_data.Size = new System.Drawing.Size(100, 21);
            this.tb_Write_data.TabIndex = 18;
            // 
            // tb_Write_Port
            // 
            this.tb_Write_Port.Location = new System.Drawing.Point(90, 17);
            this.tb_Write_Port.Name = "tb_Write_Port";
            this.tb_Write_Port.Size = new System.Drawing.Size(100, 21);
            this.tb_Write_Port.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "输出数据:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出端口：";
            // 
            // bt_Write
            // 
            this.bt_Write.Location = new System.Drawing.Point(24, 135);
            this.bt_Write.Name = "bt_Write";
            this.bt_Write.Size = new System.Drawing.Size(98, 23);
            this.bt_Write.TabIndex = 1;
            this.bt_Write.Text = "输出写入";
            this.bt_Write.UseVisualStyleBackColor = true;
            this.bt_Write.Click += new System.EventHandler(this.bt_Write_Click);
            // 
            // bt_Read
            // 
            this.bt_Read.Location = new System.Drawing.Point(124, 327);
            this.bt_Read.Name = "bt_Read";
            this.bt_Read.Size = new System.Drawing.Size(75, 23);
            this.bt_Read.TabIndex = 0;
            this.bt_Read.Text = "读取";
            this.bt_Read.UseVisualStyleBackColor = true;
            this.bt_Read.Click += new System.EventHandler(this.bt_Read_Click);
            // 
            // agv_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_carnumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_Output_fan_close);
            this.Controls.Add(this.bt_Output_fan);
            this.Controls.Add(this.bt_Output_close);
            this.Controls.Add(this.bt_Output);
            this.Controls.Add(this.bt_agv_stop);
            this.Controls.Add(this.bt_agv_left);
            this.Controls.Add(this.bt_agv_right);
            this.Controls.Add(this.bt_agv_houtui);
            this.Controls.Add(this.bt_agv_qinjing);
            this.Name = "agv_test";
            this.Text = "AGV-控制";
            this.Load += new System.EventHandler(this.agv_test_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_agv_qinjing;
        private System.Windows.Forms.Button bt_agv_houtui;
        private System.Windows.Forms.Button bt_agv_right;
        private System.Windows.Forms.Button bt_agv_left;
        private System.Windows.Forms.Button bt_agv_stop;
        private System.Windows.Forms.Button bt_Output;
        private System.Windows.Forms.Button bt_Output_close;
        private System.Windows.Forms.Button bt_Output_fan;
        private System.Windows.Forms.Button bt_Output_fan_close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_carnumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Write;
        private System.Windows.Forms.Button bt_Read;
        private System.Windows.Forms.TextBox tb_Write_data;
        private System.Windows.Forms.TextBox tb_Write_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Read_Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_read_data;
        private System.Windows.Forms.Button bt_write_Read;
        private System.Windows.Forms.TextBox tb_Write_Read_data;
        private System.Windows.Forms.Label label7;
    }
}