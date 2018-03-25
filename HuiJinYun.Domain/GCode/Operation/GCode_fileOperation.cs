using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leadshine.SMC.IDE.Motion;

namespace HuiJinYun.GCode
{
    public class FileParameters
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { set; get; }
        /// <summary>
        /// 控制器文件名称
        /// </summary>
        public byte[] fileNameControl { set; get; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public ushort fileType { set; get; }

    }
    /// <summary>
    /// GCode 文件操作
    /// </summary>
    class GCode_fileOperation
    {
        static ushort _ConnectNo = 0;
        
          
        /// <summary>
        /// 文件下载
        /// </summary>
        public static void GCode_fileUpload(FileParameters fp)
        {
            LTSMC.smc_download_file(_ConnectNo, fp.fileName, fp.fileNameControl, fp.fileType);
        }
        /// <summary>
        /// 读取当前文件名
        /// </summary>
        /// <returns></returns>
        public static string GCode_fileName()
        {
            //string pFileNames = @"f:GCode.txt";
            byte[] pFileName = BitConverter.GetBytes(0);
            short fileid = 0;
            LTSMC.smc_gcode_get_current_file(_ConnectNo,pFileName,ref fileid);
            string pFileNames = Encoding.Default.GetString(pFileName);
           
            return pFileNames;
        }
        /// <summary>
        /// GCode 开始
        /// </summary>
        public static void GCode_start()
        {
            LTSMC.smc_gcode_start(_ConnectNo);
        }
        /// <summary>
        /// GCode 暂停
        /// </summary>
        public static void GCode_pause()
        {
            LTSMC.smc_gcode_pause(_ConnectNo);
        }
        /// <summary>
        /// GCode 停止
        /// </summary>
        public static void GCode_stop()
        {
            LTSMC.smc_gcode_stop(_ConnectNo);
        }
        /// <summary>
        /// 读取GCode运行状态
        /// </summary>
        /// <returns></returns>
        public static ushort GCode_runningState()
        {
            ushort state = 0;
             LTSMC.smc_gcode_state(_ConnectNo,ref state);
            return state;
        }
        /// <summary>
        /// 读取GCode运行行号
        /// </summary>
        /// <returns></returns>
        public static uint GCode_lineNumber()
        {
            uint line = 0;
            byte[] pCurLine= BitConverter.GetBytes(0);
            //LTSMC.smc_gcode_current_line(_ConnectNo, ref line, pCurLine);
            LTSMC.smc_gcode_get_current_line(_ConnectNo, ref line, pCurLine);
            string pCurLine1 = Encoding.Default.GetString(pCurLine);
            //int length = pCurLine1.Length;
            return line ;
        }
        //public static int GCode_lineLength()
        //{
        //    uint line = 0;
        //    byte[] pCurLine = BitConverter.GetBytes(0);
        //    LTSMC.smc_gcode_current_line(_ConnectNo, ref line, pCurLine);
        //    string pCurLine1 = Encoding.Default.GetString(pCurLine);
        //    int length = pCurLine1.Length;
        //    return length;
        //}
        /// <summary>
        /// 设置GCode文件
        /// </summary>
        public static void GCode_fileSet(FileParameters fp)
        {
            LTSMC.smc_gcode_set_current_file(_ConnectNo,fp.fileNameControl);
        }
    }
}
