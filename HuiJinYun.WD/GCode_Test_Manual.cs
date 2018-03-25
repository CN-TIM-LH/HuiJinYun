using HuiJinYun.Domain.GCode;
using HuiJinYun.Domain.GCode.Operation;
using HuiJinYun.GCode;
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
    public partial class GCode_Test_Manual : Form
    {


       public static int state;

        public GCode_Test_Manual()
        {
            InitializeComponent();
            gCodeService.GCode_handWheel_set_mode();
            gCodeService.GCode_handWheel_move();
        }
        /// <summary>
        /// 返回主页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_return_Click(object sender, EventArgs e)
        {
            if (returnToZeroState()!=1)
            {
                MessageBox.Show("请将各轴先回零", "提示");
            }
            else if (returnToZeroState() == 1)
            {
                GCode_Test State = (GCode_Test)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f1
                State.zeroState(1);
                gCodeService.GCode_handWheel_stop();
                this.Close();
            }
          
        }
        private  int returnToZeroState()
        {
           if (this.lb_xAxisState.Text == "已回零" && this.lb_yAxisState.Text == "已回零" && this.lb_zAxisState.Text == "已回零" &&this.lb_uAxisState.Text == "已回零")
            {
             return   state= 1;
            }
            else
            {
                return state=0;
            }
           
        }
     
        #region 轴选取控制、各轴回零状态显示


        /// <summary>
        /// 轴选取控制、各轴回零状态显示
        /// </summary>
        /// <returns></returns>
        private ushort GetAxis()
        {
            ushort axis = 0;
            MotionParameters mp = new MotionParameters() { };
            if (rb_xAxis.Checked)
            {
                axis = 0;
                rb_yAxis.Enabled = false;
                rb_zAxis.Enabled = false;
                rb_uAxis.Enabled = false;
                //if (gCodeService.GCode_axisState(mp)== 1 )
                //{

                //    rb_yAxis.Enabled = true;
                //    rb_zAxis.Enabled = true;
                //    rb_uAxis.Enabled = true;
                //    if (gCodeService.GCode_returnToZeroState(mp) == 1)
                //    {
                //        lb_xAxisState.Text = "已回零";
                //        lb_xAxisState.BackColor = Color.Green;
                //    }
                //    timer3.Stop();
                //}
            }
            else if (rb_yAxis.Checked)
            {
                axis = 1;
                rb_xAxis.Enabled = false;
                rb_zAxis.Enabled = false;
                rb_uAxis.Enabled = false;
                //if (gCodeService.GCode_axisState(mp) == 1)
                //{
                //    rb_xAxis.Enabled = true;
                //    rb_zAxis.Enabled = true;
                //    rb_uAxis.Enabled = true;
                //    if (gCodeService.GCode_returnToZeroState(mp) == 1)
                //    {
                //        lb_xAxisState.Text = "已回零";
                //        lb_xAxisState.BackColor = Color.Green;
                //    }
                //    timer3.Stop();
                //}
            }
            else if (rb_zAxis.Checked)
            {
                axis = 2;
                rb_yAxis.Enabled = false;
                rb_xAxis.Enabled = false;
                rb_uAxis.Enabled = false;

                //if (gCodeService.GCode_axisState(mp) == 1)
                //{
                //    rb_xAxis.Enabled = true;
                //    rb_yAxis.Enabled = true;
                //    rb_uAxis.Enabled = true;
                //    if (gCodeService.GCode_returnToZeroState(mp) == 1)
                //    {
                //        lb_xAxisState.Text = "已回零";
                //        lb_xAxisState.BackColor = Color.Green;
                //    }
                //    timer3.Stop();
                //}
            }
            else if (rb_uAxis.Checked)
            {
                axis = 3;
                rb_yAxis.Enabled = false;
                rb_xAxis.Enabled = false;
                rb_zAxis.Enabled = false;

                //if (gCodeService.GCode_axisState(mp) == 1)
                //{
                //    rb_xAxis.Enabled = true;
                //    rb_zAxis.Enabled = true;
                //    rb_yAxis.Enabled = true;
                //    if (gCodeService.GCode_returnToZeroState(mp) == 1)
                //    {
                //        lb_xAxisState.Text = "已回零";
                //        lb_xAxisState.BackColor = Color.Green;
                //    }
                //    timer3.Stop();
                //}
            }
            return axis;
        }
#endregion
        /// <summary>
        /// 回零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_returnToZero_Click(object sender, EventArgs e)
        {
            timer3.Start();

            MotionParameters mp = new MotionParameters()
            {
                runningSpeed = (int)nud_runningSpeed.Value,
                accTime = (int)num_accTime.Value,
                decTime = (int)num_decTime.Value,
                movementDistance = (int)num_movementDistance.Value,
                returnToZeroSpeed = (int)num_returnToZeroSpeed.Value,
                axis = GetAxis()
            };
            gCodeService.GCode_axisReturnToZero(mp);
        }
        /// <summary>
        /// 定长运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_fixedLength_Click(object sender, EventArgs e)
        {
            timer3.Start();
           
            if (rb_xAxis.Checked)
            {
                this.lb_xAxisState.Text = "未回零";
                this.lb_xAxisState.BackColor = Color.White;
            }
            else if (rb_yAxis.Checked)
            {
                this.lb_yAxisState.Text = "未回零";
                this.lb_yAxisState.BackColor = Color.White;
            }
            else if (rb_zAxis.Checked)
            {
                this.lb_zAxisState.Text = "未回零";
                this.lb_zAxisState.BackColor = Color.White;
            }
            else if (rb_uAxis.Checked)
            {
                this.lb_uAxisState.Text = "未回零";
                this.lb_uAxisState.BackColor = Color.White;
            }

            MotionParameters mp = new MotionParameters()
            {
                runningSpeed = (int)nud_runningSpeed.Value,
                accTime = (int)num_accTime.Value,
                decTime = (int)num_decTime.Value,
                movementDistance = (int)num_movementDistance.Value,
                returnToZeroSpeed = (int)num_returnToZeroSpeed.Value,
                axis = GetAxis()
            };
            

            gCodeService.GCode_fixedLength(mp);
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_stop_Click(object sender, EventArgs e)
        {
            timer3.Start();
            MotionParameters mp = new MotionParameters()
            {
                runningSpeed = (int)nud_runningSpeed.Value,
                accTime = (int)num_accTime.Value,
                decTime = (int)num_decTime.Value,
                movementDistance = (int)num_movementDistance.Value,
                returnToZeroSpeed = (int)num_returnToZeroSpeed.Value,
                axis = GetAxis()
            };
            gCodeService.GCode_stop(mp);
        }
            /// <summary>
            /// 手动运行停止
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void bt_manualRunning_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Start();
            if (rb_xAxis.Checked)
            {
                this.lb_xAxisState.Text = "未回零";
                this.lb_xAxisState.BackColor = Color.White;
            }
            else if (rb_yAxis.Checked)
            {
                this.lb_yAxisState.Text = "未回零";
                this.lb_yAxisState.BackColor = Color.White;
            }
            else if (rb_zAxis.Checked)
            {
                this.lb_zAxisState.Text = "未回零";
                this.lb_zAxisState.BackColor = Color.White;
            }
            else if (rb_uAxis.Checked)
            {
                this.lb_uAxisState.Text = "未回零";
                this.lb_uAxisState.BackColor = Color.White;
            }
           
            MotionParameters mp = new MotionParameters()
            {
                runningSpeed = (int)nud_runningSpeed.Value,
                accTime = (int)num_accTime.Value,
                decTime = (int)num_decTime.Value,
                movementDistance = (int)num_movementDistance.Value,
                returnToZeroSpeed = (int)num_returnToZeroSpeed.Value,
                axis = GetAxis()
            };
            gCodeService.GCode_stop(mp);
        }
        /// <summary>
        /// 手动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_manualRunning_MouseDown(object sender, MouseEventArgs e)
        {
            timer3.Start();
            MotionParameters mp = new MotionParameters()
            {
                runningSpeed = (int)nud_runningSpeed.Value,
                accTime = (int)num_accTime.Value,
                decTime = (int)num_decTime.Value,
                movementDistance = (int)num_movementDistance.Value,
                returnToZeroSpeed = (int)num_returnToZeroSpeed.Value,
                axis = GetAxis(),
                direction= GetDirection()
            };
            gCodeService.GCode_manualRunning(mp);
        }
        /// <summary>
        /// 方向选择
        /// </summary>
        /// <returns></returns>
        private ushort GetDirection()
        {
            ushort direction = 1;
            if (rb_positive.Checked)
            {
                direction = 1;
            }
            else 
            {
                direction = 0;
            }
            return direction;
        }

        private void GCode_Test_Manual_Load(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //GetAxis();
            MotionParameters mp = new MotionParameters() { axis = GetAxis() };
            if (rb_xAxis.Checked)
            {


                if (gCodeService.GCode_axisState(mp) == 1)
                {

                    rb_yAxis.Enabled = true;
                    rb_zAxis.Enabled = true;
                    rb_uAxis.Enabled = true;
                    if ((gCodeService.GCode_returnToZeroState(mp) == 1)&& (gCodeService.GCode_axisLocation(mp)==0))
                    {
                        lb_xAxisState.Text = "已回零";
                        lb_xAxisState.BackColor = Color.Green;
                    }
                    timer3.Stop();
                }
            }
            else if (rb_yAxis.Checked)
            {


                if (gCodeService.GCode_axisState(mp) == 1)
                {
                    rb_xAxis.Enabled = true;
                    rb_zAxis.Enabled = true;
                    rb_uAxis.Enabled = true;
                    if (gCodeService.GCode_returnToZeroState(mp) == 1 && (gCodeService.GCode_axisLocation(mp) == 0))
                    {
                        lb_yAxisState.Text = "已回零";
                        lb_yAxisState.BackColor = Color.Green;
                    }
                    timer3.Stop();
                }
            }
            else if (rb_zAxis.Checked)
            {

                if (gCodeService.GCode_axisState(mp) == 1)
                {
                    rb_xAxis.Enabled = true;
                    rb_yAxis.Enabled = true;
                    rb_uAxis.Enabled = true;
                    if (gCodeService.GCode_returnToZeroState(mp) == 1 && (gCodeService.GCode_axisLocation(mp) == 0))
                    {
                        lb_zAxisState.Text = "已回零";
                        lb_zAxisState.BackColor = Color.Green;
                    }
                    timer3.Stop();
                }
            }
            else if (rb_uAxis.Checked)
            {

                if (gCodeService.GCode_axisState(mp) == 1)
                {
                    rb_xAxis.Enabled = true;
                    rb_zAxis.Enabled = true;
                    rb_yAxis.Enabled = true;
                    if (gCodeService.GCode_returnToZeroState(mp) == 1 && (gCodeService.GCode_axisLocation(mp) == 0))
                    {
                        lb_uAxisState.Text = "已回零";
                        lb_uAxisState.BackColor = Color.Green;
                    }
                    timer3.Stop();
                }
            }
        }

 
    }
}
