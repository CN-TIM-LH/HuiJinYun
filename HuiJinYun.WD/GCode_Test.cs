using HuiJinYun.Domain.GCode;
using HuiJinYun.Domain.GCode.Operation;
using HuiJinYun.GCode;
using Leadshine.SMC.IDE.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuiJinYun.WD
{

    public partial class GCode_Test : Form
    {
        private Timer timer;
        int RTZstate=0;
        public int zeroState(int state)
        {
            
            RTZstate = state;
            return RTZstate;
        }
        public GCode_Test()
        {
            InitializeComponent();
        }
       
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label6.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 时间显示、链接状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCode_Test_Load(object sender, EventArgs e)
        {
            this.label6.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //gAxis gaxis = gCodeService.GCode_axisCurrentLocation();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            
            if (gCodeService.GCode_link())
            {
                this.lb_linkState.Text = "已连接";
                this.lb_linkState.BackColor = Color.Green;
                MotionParameters mp = new MotionParameters() { };
                gCodeService.GCode_axisInitialization();            //轴初始化
                this.timer1.Start();
                
            }
            else
            {
                this.lb_linkState.Text = "未连接";
                this.lb_linkState.BackColor = Color.Red;
                this.timer1.Stop();
            }
           
        }

    
        
      

        /// <summary>
        /// 打开手动页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_manual_Click(object sender, EventArgs e)
        {
            GCode_Test_Manual GCode_Test_Manual = new GCode_Test_Manual();
            if ((gCodeService.GCode_runningState() == 1) || (gCodeService.GCode_runningState() == 2))
            {
                MessageBox.Show("正在自动运行", "提示");
            }
            //GCode_Test_Manual.Show();                                        // 打开手动页面
            else if (gCodeService.GCode_runningState() == 3)
            {
                /*GCode_Test_Manual.Show();  */                                      // 打开手动页面
                GCode_Test_Manual.ShowDialog(this);
            }

          


        }
        /// <summary>
        /// 打开自动页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_automatic_Click(object sender, EventArgs e)
        {
            GCode_Test_Automatic GCode_Test_Automatic = new GCode_Test_Automatic();
            if (RTZstate == 1)
            {
                /* GCode_Test_Automatic.Show();   */                                     // 打开自动页面
               GCode_Test_Automatic.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("请将各轴先回零", "提示");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //gAxis gaxis = gCodeService.GCode_axisCurrentLocation();
            this.lb_xAxisLocation.Text =gCodeService.GCode_axisCurrentLocation().xAxis.ToString();
            this.lb_yAxisLocation.Text = gCodeService.GCode_axisCurrentLocation().yAxis.ToString();
            this.lb_zAxisLocation.Text = gCodeService.GCode_axisCurrentLocation().zAxis.ToString();
            this.lb_uAxisLocation.Text = gCodeService.GCode_axisCurrentLocation().uAxis.ToString();
            runningState();
        }
        private void runningState()
        {
            if ((gCodeService.GCode_runningState()==1)|| (gCodeService.GCode_runningState() == 2))
            {
                this.lb_runningState.Text = "自动运行";
                this.lb_runningState.BackColor = Color.Green;
            }
            else
            {
                this.lb_runningState.Text = "手动运行";
                this.lb_runningState.BackColor = Color.Yellow;
            }
        }
   
    }
}
