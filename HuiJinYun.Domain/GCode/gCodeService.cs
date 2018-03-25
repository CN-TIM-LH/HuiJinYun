using HuiJinYun.Domain.GCode.Operation;
using HuiJinYun.GCode;
using Leadshine.SMC.IDE.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuiJinYun.Domain.GCode
{
    public class gCodeService
    {
        private static ushort _ConnectNo = 0;
        /// <summary>
        /// 链接
        /// </summary>
        /// <returns></returns>
        public static bool GCode_link()
        {
            try
            {
                short res = LTSMC.smc_board_init(_ConnectNo, 2, "192.168.5.11", 115200);//连接控制器
                if (res != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 轴初始化
        /// </summary>
        public static void GCode_axisInitialization()
        {
            GCode_RW_Data.GCode_axisInitialization();
        }
        /// <summary>
        /// 读取轴当前状态
        /// </summary>
        /// <returns></returns>
        public static gAxis GCode_axisCurrentLocation()
        {
            return GCode_RW_Data.GCode_axisCurrentLocation();
        }
        /// <summary>
        /// 轴当前位置计数器值
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static double    GCode_axisLocation(MotionParameters mp)
        {
            return GCode_RW_Data.GCode_axisLocation(mp);
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="mp"></param>
        public static void GCode_axisReturnToZero(MotionParameters mp)
        {
            GCode_RW_Data.GCode_axisReturnToZero(mp);
        }
        /// <summary>
        /// 读取回零状态
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static ushort GCode_returnToZeroState(MotionParameters mp)
        {
            return (GCode_RW_Data.GCode_returnToZeroState(mp));
        }
        /// <summary>
        /// 定长运动
        /// </summary>
        /// <param name="mp"></param>
        public static void GCode_fixedLength(MotionParameters mp)
        {
            GCode_RW_Data.GCode_fixedLength(mp);
        }
        /// <summary>
        /// 指定轴停止运动
        /// </summary>
        /// <param name="mp"></param>
        public static void GCode_stop(MotionParameters mp)
        {
            GCode_RW_Data.GCode_stop(mp);
        }
        /// <summary>
        /// 手动运行
        /// </summary>
        /// <param name="mp"></param>
        public static void GCode_manualRunning(MotionParameters mp)
        {
            GCode_RW_Data.GCode_manualRunning(mp);
        }
        /// <summary>
        /// 轴状态
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
       public static short GCode_axisState(MotionParameters mp)
        {
           return GCode_RW_Data.GCode_axisState(mp);
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="fp"></param>
        public static void GCode_fileUpload(FileParameters fp)
        {
            GCode_fileOperation.GCode_fileUpload( fp);
        }
        /// <summary>
        /// 读取GCode文件名称 
        /// </summary>
        /// <returns></returns>
        public static string GCode_fileName()
        {
           return GCode_fileOperation.GCode_fileName();
        }
        /// <summary>
        /// GCode 开始
        /// </summary>
        public static void GCode_start()
        {
            GCode_fileOperation.GCode_start();
        }
        /// <summary>
        /// GCode 暂停
        /// </summary>
        public static void GCode_pause()
        {
            GCode_fileOperation.GCode_pause();
        }
        /// <summary>
        /// GCode 停止
        /// </summary>
        public static void GCode_stop()
        {
            GCode_fileOperation.GCode_stop();
        }
        /// <summary>
        /// I/O输出控制--开
        /// </summary>
        public static void GCode_IOControlOpen()
        {
            GCode_RW_Data.GCode_IOControlOpen();
        }
        /// <summary>
        /// I/O输出控制—-关
        /// </summary>
        public static void GCode_IOControlClose()
        {
            GCode_RW_Data.GCode_IOControlClose();
        }
        /// <summary>
        /// 读取I/O状态
        /// </summary>
        /// <returns></returns>
        //public static short GCode_IOState()
        //{
        //    return GCode_RW_Data.GCode_IOstate();
        //}

        /// <summary>
        /// 读取GCode运行状态
        /// </summary>
        /// <returns></returns>
        public static ushort GCode_runningState()
        {
            return GCode_fileOperation.GCode_runningState();
        }
        /// <summary>
        /// 读取GCode运行行号
        /// </summary>
        /// <returns></returns>
        public static uint GCode_lineNumber()
        {
            return GCode_fileOperation.GCode_lineNumber();
        }
        //public static int GCode_lineLength()
        //{
        //    return GCode_fileOperation.GCode_lineLength();
        //}
        /// <summary>
        /// 设置GCode文件
        /// </summary>
        /// <param name="fp"></param>
        public static void GCode_fileSet(FileParameters fp)
        {
            GCode_fileOperation.GCode_fileSet(fp);
        }
        /// <summary>
        /// 设置手轮运动模式-硬件控制
        /// </summary>
        public static void GCode_handWheel_set_mode()
        {
            GCode_RW_Data.GCode_handWheel_set_mode();
        }
        /// <summary>
        /// 启动手轮
        /// </summary>
        public static void GCode_handWheel_move()
        {
            GCode_RW_Data.GCode_handWheel_move();
        }
        /// <summary>
        /// 停止手轮
        /// </summary>
        public static void GCode_handWheel_stop()
        {
            GCode_RW_Data.GCode_handWheel_stop();
        }
    }
}
