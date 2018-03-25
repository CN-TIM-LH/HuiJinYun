namespace HuiJinYun.WD
{
    partial class Test
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_in_type = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_Port = new System.Windows.Forms.Label();
            this.lb_IP = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_in_Content = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_in = new System.Windows.Forms.Button();
            this.tb_in_Number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_out_Number = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_out = new System.Windows.Forms.Button();
            this.lb_out_content = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_out_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.bt_liuhuadao = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "AGV状态监测";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_in_type
            // 
            this.cmb_in_type.FormattingEnabled = true;
            this.cmb_in_type.Location = new System.Drawing.Point(70, 30);
            this.cmb_in_type.Name = "cmb_in_type";
            this.cmb_in_type.Size = new System.Drawing.Size(121, 20);
            this.cmb_in_type.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Port);
            this.groupBox1.Controls.Add(this.lb_IP);
            this.groupBox1.Controls.Add(this.tb_port);
            this.groupBox1.Controls.Add(this.tb_ip);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接初始化";
            // 
            // lb_Port
            // 
            this.lb_Port.AutoSize = true;
            this.lb_Port.Location = new System.Drawing.Point(8, 56);
            this.lb_Port.Name = "lb_Port";
            this.lb_Port.Size = new System.Drawing.Size(71, 12);
            this.lb_Port.TabIndex = 3;
            this.lb_Port.Text = "初始化Port:";
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(6, 23);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(65, 12);
            this.lb_IP.TabIndex = 2;
            this.lb_IP.Text = "初始化IP：";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(94, 49);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 1;
            this.tb_port.Text = "8010";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(94, 20);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 0;
            this.tb_ip.Text = "192.168.10.30";
            this.tb_ip.TextChanged += new System.EventHandler(this.tb_ip_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tb_in_Content);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.bt_in);
            this.groupBox2.Controls.Add(this.tb_in_Number);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmb_in_type);
            this.groupBox2.Location = new System.Drawing.Point(36, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 267);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "写入初始化";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_in_Content
            // 
            this.tb_in_Content.Location = new System.Drawing.Point(70, 89);
            this.tb_in_Content.Name = "tb_in_Content";
            this.tb_in_Content.Size = new System.Drawing.Size(100, 21);
            this.tb_in_Content.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "数据：";
            // 
            // bt_in
            // 
            this.bt_in.Location = new System.Drawing.Point(20, 178);
            this.bt_in.Name = "bt_in";
            this.bt_in.Size = new System.Drawing.Size(75, 23);
            this.bt_in.TabIndex = 5;
            this.bt_in.Text = "写入";
            this.bt_in.UseVisualStyleBackColor = true;
            this.bt_in.Click += new System.EventHandler(this.bt_in_Click);
            // 
            // tb_in_Number
            // 
            this.tb_in_Number.Location = new System.Drawing.Point(70, 57);
            this.tb_in_Number.Name = "tb_in_Number";
            this.tb_in_Number.Size = new System.Drawing.Size(100, 21);
            this.tb_in_Number.TabIndex = 4;
            this.tb_in_Number.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "数值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "类型：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_out_Number);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.bt_out);
            this.groupBox3.Controls.Add(this.lb_out_content);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmb_out_type);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(255, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 267);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读取初始化";
            // 
            // tb_out_Number
            // 
            this.tb_out_Number.Location = new System.Drawing.Point(57, 61);
            this.tb_out_Number.Name = "tb_out_Number";
            this.tb_out_Number.Size = new System.Drawing.Size(100, 21);
            this.tb_out_Number.TabIndex = 9;
            this.tb_out_Number.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "数值：";
            // 
            // bt_out
            // 
            this.bt_out.Location = new System.Drawing.Point(59, 202);
            this.bt_out.Name = "bt_out";
            this.bt_out.Size = new System.Drawing.Size(75, 23);
            this.bt_out.TabIndex = 7;
            this.bt_out.Text = "读取";
            this.bt_out.UseVisualStyleBackColor = true;
            this.bt_out.Click += new System.EventHandler(this.bt_out_Click);
            // 
            // lb_out_content
            // 
            this.lb_out_content.AutoSize = true;
            this.lb_out_content.Location = new System.Drawing.Point(61, 92);
            this.lb_out_content.Name = "lb_out_content";
            this.lb_out_content.Size = new System.Drawing.Size(0, 12);
            this.lb_out_content.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "内容";
            // 
            // cmb_out_type
            // 
            this.cmb_out_type.FormattingEnabled = true;
            this.cmb_out_type.Location = new System.Drawing.Point(57, 25);
            this.cmb_out_type.Name = "cmb_out_type";
            this.cmb_out_type.Size = new System.Drawing.Size(121, 20);
            this.cmb_out_type.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "类型:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 218);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 85);
            this.button3.TabIndex = 5;
            this.button3.Text = "单步测试";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bt_liuhuadao
            // 
            this.bt_liuhuadao.Location = new System.Drawing.Point(480, 120);
            this.bt_liuhuadao.Name = "bt_liuhuadao";
            this.bt_liuhuadao.Size = new System.Drawing.Size(81, 85);
            this.bt_liuhuadao.TabIndex = 6;
            this.bt_liuhuadao.Text = "硫化道";
            this.bt_liuhuadao.UseVisualStyleBackColor = true;
            this.bt_liuhuadao.Click += new System.EventHandler(this.bt_liuhuadao_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 438);
            this.Controls.Add(this.bt_liuhuadao);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_in_type;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_Port;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_in;
        private System.Windows.Forms.TextBox tb_in_Number;
        private System.Windows.Forms.Button bt_out;
        private System.Windows.Forms.Label lb_out_content;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_out_type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_in_Content;
        private System.Windows.Forms.TextBox tb_out_Number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bt_liuhuadao;
    }
}