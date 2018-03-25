namespace HuiJinYun.WD
{
    partial class GCode_Test_Manual
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.num_returnToZeroSpeed = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.num_decTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.num_accTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num_movementDistance = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_runningSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_uAxis = new System.Windows.Forms.RadioButton();
            this.rb_zAxis = new System.Windows.Forms.RadioButton();
            this.rb_yAxis = new System.Windows.Forms.RadioButton();
            this.rb_xAxis = new System.Windows.Forms.RadioButton();
            this.bt_returnToZero = new System.Windows.Forms.Button();
            this.bt_fixedLength = new System.Windows.Forms.Button();
            this.bt_manualRunning = new System.Windows.Forms.Button();
            this.bt_return = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_uAxisState = new System.Windows.Forms.Label();
            this.lb_zAxisState = new System.Windows.Forms.Label();
            this.lb_yAxisState = new System.Windows.Forms.Label();
            this.lb_xAxisState = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_reverse = new System.Windows.Forms.RadioButton();
            this.rb_positive = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_returnToZeroSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_decTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_accTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_movementDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_runningSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.num_returnToZeroSpeed);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.num_decTime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.num_accTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.num_movementDistance);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nud_runningSpeed);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(367, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 233);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动参数";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(274, 202);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 19);
            this.label17.TabIndex = 10;
            this.label17.Text = "mm/s";
            // 
            // num_returnToZeroSpeed
            // 
            this.num_returnToZeroSpeed.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_returnToZeroSpeed.Location = new System.Drawing.Point(187, 198);
            this.num_returnToZeroSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_returnToZeroSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_returnToZeroSpeed.Name = "num_returnToZeroSpeed";
            this.num_returnToZeroSpeed.Size = new System.Drawing.Size(81, 31);
            this.num_returnToZeroSpeed.TabIndex = 9;
            this.num_returnToZeroSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(62, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 21);
            this.label18.TabIndex = 8;
            this.label18.Text = "回零速度:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(274, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 19);
            this.label16.TabIndex = 7;
            this.label16.Text = "mm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(274, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 19);
            this.label15.TabIndex = 6;
            this.label15.Text = "s";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(274, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 19);
            this.label14.TabIndex = 5;
            this.label14.Text = "s";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(274, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 19);
            this.label12.TabIndex = 3;
            this.label12.Text = "mm/s";
            // 
            // num_decTime
            // 
            this.num_decTime.DecimalPlaces = 2;
            this.num_decTime.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_decTime.Location = new System.Drawing.Point(187, 118);
            this.num_decTime.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_decTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.num_decTime.Name = "num_decTime";
            this.num_decTime.Size = new System.Drawing.Size(81, 31);
            this.num_decTime.TabIndex = 1;
            this.num_decTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(62, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "减速时间:";
            // 
            // num_accTime
            // 
            this.num_accTime.DecimalPlaces = 2;
            this.num_accTime.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_accTime.Location = new System.Drawing.Point(187, 78);
            this.num_accTime.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_accTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.num_accTime.Name = "num_accTime";
            this.num_accTime.Size = new System.Drawing.Size(81, 31);
            this.num_accTime.TabIndex = 1;
            this.num_accTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(62, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "加速时间:";
            // 
            // num_movementDistance
            // 
            this.num_movementDistance.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_movementDistance.Location = new System.Drawing.Point(187, 158);
            this.num_movementDistance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num_movementDistance.Name = "num_movementDistance";
            this.num_movementDistance.Size = new System.Drawing.Size(81, 31);
            this.num_movementDistance.TabIndex = 1;
            this.num_movementDistance.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(62, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "运动距离:";
            // 
            // nud_runningSpeed
            // 
            this.nud_runningSpeed.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_runningSpeed.Location = new System.Drawing.Point(187, 38);
            this.nud_runningSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_runningSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_runningSpeed.Name = "nud_runningSpeed";
            this.nud_runningSpeed.Size = new System.Drawing.Size(81, 31);
            this.nud_runningSpeed.TabIndex = 1;
            this.nud_runningSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(62, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "运行速度:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_uAxis);
            this.groupBox1.Controls.Add(this.rb_zAxis);
            this.groupBox1.Controls.Add(this.rb_yAxis);
            this.groupBox1.Controls.Add(this.rb_xAxis);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(92, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 158);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运动轴";
            // 
            // rb_uAxis
            // 
            this.rb_uAxis.AutoSize = true;
            this.rb_uAxis.Location = new System.Drawing.Point(122, 102);
            this.rb_uAxis.Name = "rb_uAxis";
            this.rb_uAxis.Size = new System.Drawing.Size(64, 28);
            this.rb_uAxis.TabIndex = 0;
            this.rb_uAxis.Text = "U轴";
            this.rb_uAxis.UseVisualStyleBackColor = true;
            // 
            // rb_zAxis
            // 
            this.rb_zAxis.AutoSize = true;
            this.rb_zAxis.Location = new System.Drawing.Point(15, 102);
            this.rb_zAxis.Name = "rb_zAxis";
            this.rb_zAxis.Size = new System.Drawing.Size(64, 28);
            this.rb_zAxis.TabIndex = 0;
            this.rb_zAxis.Text = "Z轴";
            this.rb_zAxis.UseVisualStyleBackColor = true;
            // 
            // rb_yAxis
            // 
            this.rb_yAxis.AutoSize = true;
            this.rb_yAxis.Location = new System.Drawing.Point(122, 51);
            this.rb_yAxis.Name = "rb_yAxis";
            this.rb_yAxis.Size = new System.Drawing.Size(64, 28);
            this.rb_yAxis.TabIndex = 0;
            this.rb_yAxis.Text = "Y轴";
            this.rb_yAxis.UseVisualStyleBackColor = true;
            // 
            // rb_xAxis
            // 
            this.rb_xAxis.AutoSize = true;
            this.rb_xAxis.Checked = true;
            this.rb_xAxis.Location = new System.Drawing.Point(15, 51);
            this.rb_xAxis.Name = "rb_xAxis";
            this.rb_xAxis.Size = new System.Drawing.Size(64, 28);
            this.rb_xAxis.TabIndex = 0;
            this.rb_xAxis.TabStop = true;
            this.rb_xAxis.Text = "X轴";
            this.rb_xAxis.UseVisualStyleBackColor = true;
            // 
            // bt_returnToZero
            // 
            this.bt_returnToZero.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_returnToZero.Location = new System.Drawing.Point(68, 349);
            this.bt_returnToZero.Name = "bt_returnToZero";
            this.bt_returnToZero.Size = new System.Drawing.Size(92, 51);
            this.bt_returnToZero.TabIndex = 9;
            this.bt_returnToZero.Text = "回零";
            this.bt_returnToZero.UseVisualStyleBackColor = true;
            this.bt_returnToZero.Click += new System.EventHandler(this.bt_returnToZero_Click);
            // 
            // bt_fixedLength
            // 
            this.bt_fixedLength.AutoSize = true;
            this.bt_fixedLength.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_fixedLength.Location = new System.Drawing.Point(183, 349);
            this.bt_fixedLength.Name = "bt_fixedLength";
            this.bt_fixedLength.Size = new System.Drawing.Size(104, 51);
            this.bt_fixedLength.TabIndex = 10;
            this.bt_fixedLength.Text = "定长运行";
            this.bt_fixedLength.UseVisualStyleBackColor = true;
            this.bt_fixedLength.Click += new System.EventHandler(this.bt_fixedLength_Click);
            // 
            // bt_manualRunning
            // 
            this.bt_manualRunning.AutoSize = true;
            this.bt_manualRunning.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_manualRunning.Location = new System.Drawing.Point(433, 349);
            this.bt_manualRunning.Name = "bt_manualRunning";
            this.bt_manualRunning.Size = new System.Drawing.Size(104, 51);
            this.bt_manualRunning.TabIndex = 11;
            this.bt_manualRunning.Text = "手动运行";
            this.bt_manualRunning.UseVisualStyleBackColor = true;
            this.bt_manualRunning.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_manualRunning_MouseDown);
            this.bt_manualRunning.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_manualRunning_MouseUp);
            // 
            // bt_return
            // 
            this.bt_return.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_return.Location = new System.Drawing.Point(558, 349);
            this.bt_return.Name = "bt_return";
            this.bt_return.Size = new System.Drawing.Size(92, 51);
            this.bt_return.TabIndex = 12;
            this.bt_return.Text = "返回";
            this.bt_return.UseVisualStyleBackColor = true;
            this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.AutoSize = true;
            this.bt_stop.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_stop.Location = new System.Drawing.Point(308, 349);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(104, 51);
            this.bt_stop.TabIndex = 13;
            this.bt_stop.Text = "停止";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lb_uAxisState);
            this.groupBox3.Controls.Add(this.lb_zAxisState);
            this.groupBox3.Controls.Add(this.lb_yAxisState);
            this.groupBox3.Controls.Add(this.lb_xAxisState);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(92, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 158);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "回零状态";
            // 
            // lb_uAxisState
            // 
            this.lb_uAxisState.AutoSize = true;
            this.lb_uAxisState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_uAxisState.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_uAxisState.Location = new System.Drawing.Point(90, 126);
            this.lb_uAxisState.Name = "lb_uAxisState";
            this.lb_uAxisState.Size = new System.Drawing.Size(71, 22);
            this.lb_uAxisState.TabIndex = 21;
            this.lb_uAxisState.Text = "未回零";
            // 
            // lb_zAxisState
            // 
            this.lb_zAxisState.AutoSize = true;
            this.lb_zAxisState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_zAxisState.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_zAxisState.Location = new System.Drawing.Point(90, 96);
            this.lb_zAxisState.Name = "lb_zAxisState";
            this.lb_zAxisState.Size = new System.Drawing.Size(71, 22);
            this.lb_zAxisState.TabIndex = 20;
            this.lb_zAxisState.Text = "未回零";
            // 
            // lb_yAxisState
            // 
            this.lb_yAxisState.AutoSize = true;
            this.lb_yAxisState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_yAxisState.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_yAxisState.Location = new System.Drawing.Point(90, 66);
            this.lb_yAxisState.Name = "lb_yAxisState";
            this.lb_yAxisState.Size = new System.Drawing.Size(71, 22);
            this.lb_yAxisState.TabIndex = 19;
            this.lb_yAxisState.Text = "未回零";
            // 
            // lb_xAxisState
            // 
            this.lb_xAxisState.AutoSize = true;
            this.lb_xAxisState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_xAxisState.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_xAxisState.Location = new System.Drawing.Point(90, 36);
            this.lb_xAxisState.Name = "lb_xAxisState";
            this.lb_xAxisState.Size = new System.Drawing.Size(71, 22);
            this.lb_xAxisState.TabIndex = 15;
            this.lb_xAxisState.Text = "未回零";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(28, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 18;
            this.label10.Text = "U轴";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(28, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "Z轴";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(28, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Y轴";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "X轴";
            // 
            // rb_reverse
            // 
            this.rb_reverse.AutoSize = true;
            this.rb_reverse.Location = new System.Drawing.Point(198, 29);
            this.rb_reverse.Name = "rb_reverse";
            this.rb_reverse.Size = new System.Drawing.Size(70, 25);
            this.rb_reverse.TabIndex = 0;
            this.rb_reverse.Text = "反向";
            this.rb_reverse.UseVisualStyleBackColor = true;
            // 
            // rb_positive
            // 
            this.rb_positive.AutoSize = true;
            this.rb_positive.Checked = true;
            this.rb_positive.Location = new System.Drawing.Point(66, 27);
            this.rb_positive.Name = "rb_positive";
            this.rb_positive.Size = new System.Drawing.Size(70, 25);
            this.rb_positive.TabIndex = 0;
            this.rb_positive.TabStop = true;
            this.rb_positive.Text = "正向";
            this.rb_positive.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb_reverse);
            this.groupBox4.Controls.Add(this.rb_positive);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(367, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(347, 64);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "手动运动方向";
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // GCode_Test_Manual
            // 
            this.ClientSize = new System.Drawing.Size(744, 412);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_return);
            this.Controls.Add(this.bt_manualRunning);
            this.Controls.Add(this.bt_fixedLength);
            this.Controls.Add(this.bt_returnToZero);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GCode_Test_Manual";
            this.Text = "手动页面";
            this.Load += new System.EventHandler(this.GCode_Test_Manual_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_returnToZeroSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_decTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_accTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_movementDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_runningSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown num_decTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_accTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_movementDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_runningSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_uAxis;
        private System.Windows.Forms.RadioButton rb_zAxis;
        private System.Windows.Forms.RadioButton rb_yAxis;
        private System.Windows.Forms.RadioButton rb_xAxis;
        private System.Windows.Forms.Button bt_returnToZero;
        private System.Windows.Forms.Button bt_fixedLength;
        private System.Windows.Forms.Button bt_manualRunning;
        private System.Windows.Forms.Button bt_return;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown num_returnToZeroSpeed;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rb_reverse;
        private System.Windows.Forms.RadioButton rb_positive;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lb_xAxisState;
        private System.Windows.Forms.Label lb_uAxisState;
        private System.Windows.Forms.Label lb_zAxisState;
        private System.Windows.Forms.Label lb_yAxisState;
        private System.Windows.Forms.Timer timer3;
    }
}