namespace HuiJinYun.WD
{
    partial class GCode_Test_Automatic
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_runningModel = new System.Windows.Forms.Label();
            this.bt_nextStep = new System.Windows.Forms.Button();
            this.bt_upload = new System.Windows.Forms.Button();
            this.bt_preservation = new System.Windows.Forms.Button();
            this.bt_end = new System.Windows.Forms.Button();
            this.bt_suspend = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_return = new System.Windows.Forms.Button();
            this.bt_hellp = new System.Windows.Forms.Button();
            this.bt_open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lb_fileName = new System.Windows.Forms.Label();
            this.rb_singleStep = new System.Windows.Forms.RadioButton();
            this.rb_automatic = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tb_program = new System.Windows.Forms.RichTextBox();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "程序";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(456, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "运行模式";
            // 
            // lb_runningModel
            // 
            this.lb_runningModel.AutoSize = true;
            this.lb_runningModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_runningModel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_runningModel.Location = new System.Drawing.Point(547, 42);
            this.lb_runningModel.Name = "lb_runningModel";
            this.lb_runningModel.Size = new System.Drawing.Size(2, 23);
            this.lb_runningModel.TabIndex = 4;
            // 
            // bt_nextStep
            // 
            this.bt_nextStep.AutoSize = true;
            this.bt_nextStep.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_nextStep.Location = new System.Drawing.Point(660, 100);
            this.bt_nextStep.Name = "bt_nextStep";
            this.bt_nextStep.Size = new System.Drawing.Size(83, 45);
            this.bt_nextStep.TabIndex = 6;
            this.bt_nextStep.Text = "下一步";
            this.bt_nextStep.UseVisualStyleBackColor = true;
            this.bt_nextStep.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_nextStep_MouseDown);
            this.bt_nextStep.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_nextStep_MouseUp);
            // 
            // bt_upload
            // 
            this.bt_upload.AutoSize = true;
            this.bt_upload.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_upload.Location = new System.Drawing.Point(660, 175);
            this.bt_upload.Name = "bt_upload";
            this.bt_upload.Size = new System.Drawing.Size(76, 45);
            this.bt_upload.TabIndex = 12;
            this.bt_upload.Text = "写入";
            this.bt_upload.UseVisualStyleBackColor = true;
            this.bt_upload.Click += new System.EventHandler(this.bt_upload_Click);
            // 
            // bt_preservation
            // 
            this.bt_preservation.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_preservation.Location = new System.Drawing.Point(560, 175);
            this.bt_preservation.Name = "bt_preservation";
            this.bt_preservation.Size = new System.Drawing.Size(69, 45);
            this.bt_preservation.TabIndex = 11;
            this.bt_preservation.Text = "保存";
            this.bt_preservation.UseVisualStyleBackColor = true;
            this.bt_preservation.Click += new System.EventHandler(this.bt_preservation_Click);
            // 
            // bt_end
            // 
            this.bt_end.AutoSize = true;
            this.bt_end.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_end.Location = new System.Drawing.Point(660, 250);
            this.bt_end.Name = "bt_end";
            this.bt_end.Size = new System.Drawing.Size(76, 45);
            this.bt_end.TabIndex = 15;
            this.bt_end.Text = "结束";
            this.bt_end.UseVisualStyleBackColor = true;
            this.bt_end.Click += new System.EventHandler(this.bt_end_Click);
            // 
            // bt_suspend
            // 
            this.bt_suspend.AutoSize = true;
            this.bt_suspend.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_suspend.Location = new System.Drawing.Point(560, 250);
            this.bt_suspend.Name = "bt_suspend";
            this.bt_suspend.Size = new System.Drawing.Size(69, 45);
            this.bt_suspend.TabIndex = 14;
            this.bt_suspend.Text = "暂停";
            this.bt_suspend.UseVisualStyleBackColor = true;
            this.bt_suspend.Click += new System.EventHandler(this.bt_suspend_Click);
            // 
            // bt_start
            // 
            this.bt_start.AutoSize = true;
            this.bt_start.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_start.Location = new System.Drawing.Point(460, 250);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(69, 45);
            this.bt_start.TabIndex = 13;
            this.bt_start.Text = "开始";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_return
            // 
            this.bt_return.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_return.Location = new System.Drawing.Point(547, 339);
            this.bt_return.Name = "bt_return";
            this.bt_return.Size = new System.Drawing.Size(92, 51);
            this.bt_return.TabIndex = 16;
            this.bt_return.Text = "返回";
            this.bt_return.UseVisualStyleBackColor = true;
            this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
            // 
            // bt_hellp
            // 
            this.bt_hellp.AutoSize = true;
            this.bt_hellp.Location = new System.Drawing.Point(643, 5);
            this.bt_hellp.Name = "bt_hellp";
            this.bt_hellp.Size = new System.Drawing.Size(93, 32);
            this.bt_hellp.TabIndex = 17;
            this.bt_hellp.Text = "G代码编写规范";
            this.bt_hellp.UseVisualStyleBackColor = true;
            this.bt_hellp.Click += new System.EventHandler(this.bt_hellp_Click);
            // 
            // bt_open
            // 
            this.bt_open.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_open.Location = new System.Drawing.Point(460, 175);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(69, 45);
            this.bt_open.TabIndex = 18;
            this.bt_open.Text = "打开";
            this.bt_open.UseVisualStyleBackColor = true;
            this.bt_open.Click += new System.EventHandler(this.bt_open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lb_fileName
            // 
            this.lb_fileName.AutoSize = true;
            this.lb_fileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_fileName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_fileName.Location = new System.Drawing.Point(82, 9);
            this.lb_fileName.Name = "lb_fileName";
            this.lb_fileName.Size = new System.Drawing.Size(2, 21);
            this.lb_fileName.TabIndex = 19;
            // 
            // rb_singleStep
            // 
            this.rb_singleStep.AutoSize = true;
            this.rb_singleStep.Location = new System.Drawing.Point(91, 29);
            this.rb_singleStep.Name = "rb_singleStep";
            this.rb_singleStep.Size = new System.Drawing.Size(70, 25);
            this.rb_singleStep.TabIndex = 0;
            this.rb_singleStep.Text = "单步";
            this.rb_singleStep.UseVisualStyleBackColor = true;
            // 
            // rb_automatic
            // 
            this.rb_automatic.AutoSize = true;
            this.rb_automatic.Checked = true;
            this.rb_automatic.Location = new System.Drawing.Point(15, 29);
            this.rb_automatic.Name = "rb_automatic";
            this.rb_automatic.Size = new System.Drawing.Size(70, 25);
            this.rb_automatic.TabIndex = 0;
            this.rb_automatic.TabStop = true;
            this.rb_automatic.Text = "自动";
            this.rb_automatic.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb_singleStep);
            this.groupBox4.Controls.Add(this.rb_automatic);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(456, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 64);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "运行模式";
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tb_program
            // 
            this.tb_program.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_program.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_program.Location = new System.Drawing.Point(33, 33);
            this.tb_program.Name = "tb_program";
            this.tb_program.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.tb_program.Size = new System.Drawing.Size(417, 367);
            this.tb_program.TabIndex = 21;
            this.tb_program.Text = "";
            this.tb_program.WordWrap = false;
            this.tb_program.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_program_KeyPress);
            // 
            // GCode_Test_Automatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 412);
            this.ControlBox = false;
            this.Controls.Add(this.tb_program);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lb_fileName);
            this.Controls.Add(this.bt_open);
            this.Controls.Add(this.bt_hellp);
            this.Controls.Add(this.bt_return);
            this.Controls.Add(this.bt_end);
            this.Controls.Add(this.bt_suspend);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.bt_upload);
            this.Controls.Add(this.bt_preservation);
            this.Controls.Add(this.bt_nextStep);
            this.Controls.Add(this.lb_runningModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GCode_Test_Automatic";
            this.Text = "自动页面";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_runningModel;
        private System.Windows.Forms.Button bt_nextStep;
        private System.Windows.Forms.Button bt_upload;
        private System.Windows.Forms.Button bt_preservation;
        private System.Windows.Forms.Button bt_end;
        private System.Windows.Forms.Button bt_suspend;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_return;
        private System.Windows.Forms.Button bt_hellp;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lb_fileName;
        private System.Windows.Forms.RadioButton rb_singleStep;
        private System.Windows.Forms.RadioButton rb_automatic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.RichTextBox tb_program;
    }
}