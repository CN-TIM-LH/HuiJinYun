using HuiJinYun.Domain.Entity.AGV;
using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Entity.PLC;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuiJinYun.WD
{
    public partial class agv_test : Form
    {
        TcpClient _client;
        protected IPort _port;
        protected ISerialize _serialize;
        IPort port;
        public agv_test()
        {
            InitializeComponent();
            port = new TcpPort(this.tb_ip.Text.ToString().Trim() + ":8000");
        }

        /// <summary>
        /// 前进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_agv_qinjing_Click(object sender, EventArgs e)
        {
            try
            {
                //_serialize = new ProtoClass();
                //UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
                //_device.SetMotionControl_qianjing();
                TcpClient ds = new TcpClient("",55111);
                Logger.LogInfo("dgdfdfhdf");
            }
            catch(Exception ex)
            {
                Logger.ErrorInfo("", ex);
            }
        }

        /// <summary>
        /// 左转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_agv_left_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            _device.SetMotionControl_left();

        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_agv_stop_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            _device.SetMotionControl_stop();

        }

        /// <summary>
        ///  右转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_agv_right_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            _device.SetMotionControl_right();

        }

        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_agv_houtui_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            _device.SetMotionControl_houtui();
        }

        private void bt_Output_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            byte carnumber = byte.Parse(this.tb_carnumber.Text.ToString().Trim());
            _device.SetOutput_Open(carnumber);
        }

        private void bt_Output_close_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            byte carnumber = byte.Parse(this.tb_carnumber.Text.ToString().Trim());
            _device.SetOutput_close(carnumber);

        }

        private void agv_test_Load(object sender, EventArgs e)
        {

        }

        private void bt_Output_fan_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            byte carnumber = byte.Parse(this.tb_carnumber.Text.ToString().Trim());
            _device.SetOutput_fan_Open(carnumber);

        }

        private void bt_Output_fan_close_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            byte carnumber = byte.Parse(this.tb_carnumber.Text.ToString().Trim());
            _device.SetOutput_fan_close(carnumber);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            UwantAgvDevice _device = new UwantAgvDevice(port, _serialize);
            _device.SetMonitor();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_Write_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            LongmenDevice longmen = new LongmenDevice(port, _serialize);
            //longmen.DoWrite(int.Parse(this.tb_Write_Port.Text.ToString().Trim()),byte.Parse(this.tb_Write_data.Text.ToString().Trim()));
        }
        

        private void bt_Read_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            LongmenDevice longmen = new LongmenDevice(port, _serialize);
            byte data = 0x0000; ;
           // longmen.DiRead(int.Parse(this.tb_Read_Port.Text.ToString().Trim()),out data);
            this.tb_read_data.Text = null;
            this.tb_read_data.Text = data.ToString();
        }

        private void bt_write_Read_Click(object sender, EventArgs e)
        {
            _serialize = new ProtoClass();
            LongmenDevice longmen = new LongmenDevice(port, _serialize);
            byte data = 0x000; ;
           // longmen.DoRead(int.Parse(this.tb_Write_Port.Text.ToString().Trim()), out data);
            this.tb_Write_Read_data.Text = null;
            this.tb_Write_Read_data.Text = data.ToString();
        }
    }
}
