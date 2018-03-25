using HuiJinYun.Domain.GCode;
using HuiJinYun.GCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HuiJinYun.WD
{
    public partial class GCode_Test_Automatic : Form
    {       
        public GCode_Test_Automatic()
        {
            InitializeComponent();
            //ReadTextFile(@"f:GCode.txt");
            ReadTextFile(gCodeService.GCode_fileName());
            this.lb_fileName.Text = gCodeService.GCode_fileName();
            FileParameters fp = new FileParameters()
            {
                fileName = this.lb_fileName.Text,
                fileNameControl = Encoding.UTF8.GetBytes(Path.GetFileName(lb_fileName.Text.Trim())),
                fileType = 1
            };
            gCodeService.GCode_fileSet(fp);
        }
        /// <summary>
        /// 读取GCode.txt文件
        /// </summary>
        /// <param name="filePath"></param>
        private void ReadTextFile(string filePath)
        {
            // 读入文本文件的所有行
            string[] lines = File.ReadAllLines(gCodeService.GCode_fileName());
            // 在textBox1中显示文件内容
            foreach (string line in lines)
            {
                tb_program.AppendText(line + Environment.NewLine);
                //tb_program.Text.ToUpper();
            }
        }
        private void bt_return_Click(object sender, EventArgs e)
        {
            GCode_Test State = (GCode_Test)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f1
            State.zeroState(0);
            this.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        /// <summary>
        /// 打开帮助文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_hellp_Click(object sender, EventArgs e)
        {
            GCode_Test_GCodeExplain GCode_Test_GCodeExplain = new GCode_Test_GCodeExplain();
            GCode_Test_GCodeExplain.Show();                                        // 打开帮助页面
        }

        //private void tb_program_TextChanged(object sender, EventArgs e)
        //{
        //    //string str1 = File.ReadAllText(@"d:\temp\GCode.txt");
        //    //System.Diagnostics.Process.Start("GCode.txt");                 //打开当前目录文件
        //    // string str3 = Directory.GetCurrentDirectory();
        //    //File.ReadAllText(@"f:GCode.txt");

        //}
        /// <summary>
        /// 设置文件输入格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_program_KeyPress(object sender, KeyPressEventArgs e)
        {
            //阻止从键盘输入键
            e.Handled = true;
            string[] lists = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "X","Y",  "Z",  "U", "N",  "G",  "M",  "F",  "S",  "V",  "R",  " ", "\b", "\r" };
            char d = e.KeyChar;
            string a = d.ToString();
            if (lists.Contains(a))
            {
                e.Handled = false;
                
            }
            
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_preservation_Click(object sender, EventArgs e)
        {
            //File.WriteAllText("GCode.txt", this.tb_program.Text);
            SaveFileDialog filel = new SaveFileDialog();
            filel.Filter = "G代码文件|*.g";                  //设置文本后缀过滤
            if (filel.ShowDialog() == DialogResult.OK)
            {
                string sd = filel.FileName;
                File.WriteAllText(sd,tb_program.Text);  //写入内容
                
            }
            string localFilePath = "";
            //获得文件路径
            localFilePath = filel.FileName.ToString();
            this.lb_fileName.Text = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog filel = new OpenFileDialog();
            filel.Filter = "G代码文件|*.g|文本文件|*.txt";                  //设置文本后缀过滤
            if (filel.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = File.OpenText(filel.FileName); //创建文件流，读取打开文件
                tb_program.Text = sr.ReadToEnd();
                sr.Close();                                         //关闭文件流
            }
            string localFilePath = "";
            //获得文件路径
            localFilePath = filel.FileName.ToString();
            this.lb_fileName.Text = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
        }
        /// <summary>
        /// 将当前文件写入控制器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_upload_Click(object sender, EventArgs e)
        {
            FileParameters fp = new FileParameters()
            {
                fileName = this.lb_fileName.Text,
                fileNameControl=  Encoding.UTF8.GetBytes(Path.GetFileName(lb_fileName.Text.Trim())),
                fileType=1
            };
            gCodeService.GCode_fileUpload(fp);        
            gCodeService.GCode_fileSet(fp);
        }
        /// <summary>
        /// GCode开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void bt_start_Click(object sender, EventArgs e)
        {
            signalControl();
            gCodeService.GCode_start();
            
           timer2.Start();
        }

        
        //tb_program.SelectionStart = tb_program.GetFirstCharIndexFromLine(int.Parse(gCodeService.GCode_lineNumber().ToString()));
        //tb_program.SelectionLength = 0;
        //tb_program.Focus();
        //tb_program.ScrollToCaret();

        /// <summary>
        /// GCode 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_suspend_Click(object sender, EventArgs e)
        {
            gCodeService.GCode_pause();

        }
        /// <summary>
        /// GCode 结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_end_Click(object sender, EventArgs e)
        {
            gCodeService.GCode_stop();
            gCodeService.GCode_IOControlClose();
            timer2.Stop();
        }
        /// <summary>
        /// 输出信号控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signalControl()
        {
            if (rb_automatic.Checked)
            {
                gCodeService.GCode_IOControlOpen();
                this.bt_nextStep.Enabled = false;
                this.lb_runningModel.Text = "自动运行";
                this.lb_runningModel.BackColor = Color.Green;
            }
            else
            {
                gCodeService.GCode_IOControlClose();
                this.bt_nextStep.Enabled = true;
                this.lb_runningModel.Text = "单步运行";
                this.lb_runningModel.BackColor = Color.Yellow;
            
             
            }
        }


        /// <summary>
        /// 单步控制输出信号-ON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_nextStep_MouseDown(object sender, MouseEventArgs e)
        {
            gCodeService.GCode_IOControlOpen();
        }
        /// <summary>
        /// 单步控制输出信号-OFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_nextStep_MouseUp(object sender, MouseEventArgs e)
        {
            gCodeService.GCode_IOControlClose();
        }

 

        private void timer2_Tick(object sender, EventArgs e)
        {
            //备份选区
            var start = tb_program.SelectionStart;
            var length = tb_program.SelectionLength;

            //tb_program.SelectionStart = tb_program.GetFirstCharIndexFromLine(int.Parse(gCodeService.GCode_lineNumber().ToString()));
            //当前行开始位置
            //var linestart = tb_program.GetFirstCharIndexOfCurrentLine();
            int lineNumber = (int)gCodeService.GCode_lineNumber();
            lineNumber -= (0 != lineNumber) ? 1 : 0;

            var linestart = tb_program.GetFirstCharIndexFromLine(lineNumber);
            var lineEnd = tb_program.Text.IndexOf('\n', linestart); //todo: 未处理lastline
            lineEnd = (-1 == lineEnd) ? tb_program.Text.Length - 1 : lineEnd;

            tb_program.SelectAll();
            tb_program.SelectionBackColor = Color.White;
            tb_program.Select(linestart, lineEnd - linestart);
            tb_program.SelectionBackColor = Color.Yellow;
            tb_program.Select(start, length);

/*
            //搜索当期行结束位置
            var currpos = tb_program.GetPositionFromCharIndex(start);
            var lineEnd = tb_program.GetCharIndexFromPosition(currpos);
            
            tb_program.SelectAll();
            tb_program.SelectionBackColor = Color.White;
            tb_program.Select(tb_program.SelectionStart, lineEnd- tb_program.SelectionStart);
            tb_program.SelectionBackColor = Color.Gray;
            tb_program.Select();
          */
        }

     


        //public string getStr(bool b, int n)//b：是否有复杂字符，n：生成的字符串长度

        //{

        //    string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    if (b = true)
        //    {
        //        str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";//复杂字符
        //    }
        //    StringBuilder SB = new StringBuilder();
        //    Random rd = new Random();
        //    for (int i = 0; i < n; i++)
        //    {
        //        SB.Append(str.Substring(rd.Next(0, str.Length), 1));
        //    }
        //    return SB.ToString();

        //}

    }
}
    

    
