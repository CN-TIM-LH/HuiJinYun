using Leadshine.SMC.IDE.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.GCode.Operation
{
    /// <summary>
    /// 轴
    /// </summary>
    public class gAxis
    {
        /// <summary>
        /// x 轴
        /// </summary>
       public int xAxis { get; set; }
        /// <summary>
        /// y 轴
        /// </summary>
        public int yAxis { get; set; }
        /// <summary>
        /// z 轴
        /// </summary>
        public int zAxis { get; set; }
        /// <summary>
        ///  u 轴
        /// </summary>
        public int uAxis { get; set; }
    }
    #region 运动参数
    /// <summary>
    /// 运动参数
    /// </summary>
    public class MotionParameters
    {
        /// <summary>
        /// 运行速度
        /// </summary>
        public int runningSpeed { get; set; }
        /// <summary>
        ///加速时间
        /// </summary>
        public int accTime { get; set; }
        /// <summary>
        /// 减速时间
        /// </summary>
        public int decTime { get; set; }
        /// <summary>
        ///  运动距离
        /// </summary>
        public int movementDistance { get; set; }
        /// <summary>
        /// 回零速度
        /// </summary>
        public int returnToZeroSpeed { get; set; }
        /// <summary>
        /// 选取轴
        /// </summary>
        public ushort axis { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public ushort direction { get; set; }
    }
    #endregion
    public class GCode_RW_Data
    {
       
        static ushort _ConnectNo = 0;
        /// <summary>
        /// 读取轴当前位置
        /// </summary>
        /// <returns></returns>
        public static gAxis GCode_axisCurrentLocation()
        {
            double xAxis = 0;
            double yAxis = 0;
            double zAxis = 0;
            double uAxis = 0;
            LTSMC.smc_get_position_unit(_ConnectNo, 0, ref xAxis);
             LTSMC.smc_get_position_unit(_ConnectNo, 1, ref yAxis);
             LTSMC.smc_get_position_unit(_ConnectNo, 2, ref zAxis);
            LTSMC.smc_get_position_unit(_ConnectNo, 3, ref uAxis);
            gAxis axis = new gAxis() { uAxis =(int) uAxis, xAxis = (int)xAxis, yAxis = (int)yAxis, zAxis = (int)zAxis };
            return axis;
        }
        /// <summary>
        /// 轴当前位置计数器值
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static double GCode_axisLocation(MotionParameters mp)
        {
            double location = 0;
            LTSMC.smc_get_position_unit(_ConnectNo,mp.axis, ref location);
            return location;
        }
        /// <summary>
        /// 轴初始化
        /// </summary>
        /// <param name=""></param>
        public  static void GCode_axisInitialization()
        {
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 0, 1);                        //设置X脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 1, 1);                        //设置Y脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 2, 1);                        //设置Z脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 3, 1);                        //设置U脉冲模式
            LTSMC.smc_set_equiv(_ConnectNo, 0, 62.5);                                //设置X脉冲当量
            LTSMC.smc_set_equiv(_ConnectNo, 1, 32.89);                                //设置Y脉冲当量
            LTSMC.smc_set_equiv(_ConnectNo, 2, 2000);                                //设置Z脉冲当量
            LTSMC.smc_set_equiv(_ConnectNo, 3, 2000);                                //设置U脉冲当量
            
        }
        /// <summary>
        /// 轴回零运动
        /// </summary>
       public  static void GCode_axisReturnToZero(MotionParameters mp)
        {
            LTSMC.smc_set_home_pin_logic(_ConnectNo, 0, 0, 0);                    //设置轴原点低电平有效
            LTSMC.smc_set_homemode(_ConnectNo,mp.axis, 0, 1, 1, 0);                    //设置轴回零模式
            LTSMC.smc_set_home_profile_unit(_ConnectNo, mp.axis, 5000, mp.returnToZeroSpeed, mp.accTime, mp.decTime);    //设置X轴起始速度、起始速度、运行速度、加速时间、减速时间 
            LTSMC.smc_home_move(_ConnectNo,mp.axis);                                    //启动回零
        }
        /// <summary>
        /// 读取回零状态
        /// </summary>
        /// <returns></returns>
        public static ushort GCode_returnToZeroState(MotionParameters mp)
        {
            ushort returnToZeroState = 0;
            LTSMC.smc_get_home_result(_ConnectNo, mp.axis, ref returnToZeroState);

            return returnToZeroState;
        }
        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static short GCode_axisState(MotionParameters mp)
        {
            
            return LTSMC.smc_check_done(_ConnectNo, mp.axis);            
        }
        /// <summary>
        /// 定长运动
        /// </summary>
        /// <param name="mp"></param>
       public   static void GCode_fixedLength(MotionParameters mp)
        {
            LTSMC.smc_set_profile_unit(_ConnectNo, mp.axis, 0, mp.runningSpeed, mp.accTime, mp.decTime, 0);//设置起始速度、运行速度、停止速度、加速时间、减速时间
            LTSMC.smc_pmove_unit(_ConnectNo, mp.axis, mp.movementDistance,1);                            //定长运动
        }
        /// <summary>
        /// 指定轴停止运动
        /// </summary>
        /// <param name="mp"></param>
        public static void GCode_stop(MotionParameters mp)
        {
            LTSMC.smc_stop(_ConnectNo, mp.axis, 1);          //指定轴停止运动
        }
        /// <summary>
        /// 手动运行
        /// </summary>
        public static void GCode_manualRunning(MotionParameters mp)
        {
            LTSMC.smc_set_profile_unit(_ConnectNo, mp.axis, 0, mp.runningSpeed, mp.accTime, mp.decTime, 0);//设置起始速度、运行速度、停止速度、加速时间、减速时间
            LTSMC.smc_vmove(_ConnectNo,mp.axis,mp.direction);//连续运动
        }
        
        //LTSMC.smc_write_outbit(_ConnectNo, 0, 0);                              //控制I/O输出
        //short s = LTSMC.smc_read_outbit(_ConnectNo, 0);                        //读取I/O状态，0-开，1-关
        //if (s == 1)
        //{
        //    LTSMC.smc_write_outbit(_ConnectNo, 0, 0);
        //}
        //else
        //{
        //    LTSMC.smc_write_outbit(_ConnectNo, 0, 1);
        //}

        /// <summary>
        /// 控制I/O输出-开
        /// </summary>
        public static void GCode_IOControlOpen()
        {
            LTSMC.smc_write_outbit(_ConnectNo, 0, 0);                         //控制I/O输出
        }
        /// <summary>
        /// 控制I/O输出-关
        /// </summary>
        public static void GCode_IOControlClose()
        {
            LTSMC.smc_write_outbit(_ConnectNo, 0, 1);
        }
        ///// <summary>
        ///// 读取I/O状态
        ///// </summary>
        ///// <returns></returns>
        //public static short GCode_IOstate()
        //{
        //  return  LTSMC.smc_read_outbit(_ConnectNo, 0);
        //}

        /// <summary>
        /// 设置手轮运动模式-硬件控制
        /// </summary>
        public static void GCode_handWheel_set_mode()
        {
            LTSMC.smc_handwheel_set_mode(_ConnectNo,0,1);
        }
        /// <summary>
        /// 启动手轮
        /// </summary>
        public static void GCode_handWheel_move()
        {
            LTSMC.smc_handwheel_move(_ConnectNo,0);
        }
        /// <summary>
        /// 停止手轮
        /// </summary>
        public static void GCode_handWheel_stop()
        {
            LTSMC.smc_handwheel_stop(_ConnectNo);
        }
    }
}
