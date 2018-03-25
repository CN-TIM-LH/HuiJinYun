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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuiJinYun.WD
{
    public partial class Test : Form
    {
        protected ISerialize _serialize;
        protected IPort _port;
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Test_Load(object sender, EventArgs e)
        {
            cmb_in_type.DataSource = GetDataTable();
            cmb_in_type.DisplayMember = "Name";
            cmb_in_type.ValueMember = "Value";

            cmb_out_type.DataSource = GetDataTable();
            cmb_out_type.DisplayMember = "Name";
            cmb_out_type.ValueMember = "Value";

        }


        private static DataTable GetDataTable()
        {
            Type enumType = typeof(eElementCode); // 获取类型对象  
            FieldInfo[] enumFields = enumType.GetFields();    //获取字段信息对象集合  
            DataTable table = new DataTable();
            table.Columns.Add("Name", Type.GetType("System.String"));
            table.Columns.Add("Value", Type.GetType("System.String"));
            //遍历集合  
            foreach (FieldInfo field in enumFields)
            {
                if (!field.IsSpecialName)
                {
                    DataRow row = table.NewRow();
                    row[0] = field.Name;   // 获取字段文本值  
                    row[1] = Convert.ToString(field.GetRawConstantValue());        // 获取int数值  
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        private void bt_in_Click(object sender, EventArgs e)
        {
            IPort port = new TcpPort(""+this.tb_ip.Text.ToString().Trim()+":"+this.tb_port.Text.ToString().Trim()+"");
            _serialize = new ProtoClass();
            TestDevice _device = new TestDevice(port, _serialize);
            eElementCode testenum = (eElementCode)Enum.Parse(typeof(eElementCode), cmb_in_type.SelectedValue.ToString(), false);
            //ushort content = ushort.Parse(this.tb_in_Content.ToString().Trim());
            // _device.Write( eElementCode.D,uint.Parse("204"),ushort.Parse("100"));
           // _device.Write(eElementCode.M, uint.Parse("0"), ushort.Parse("0"));
            //_device.Write(eElementCode.M, uint.Parse("8"), ushort.Parse("1"));
            _device.Write(eElementCode.Y, uint.Parse("20"), ushort.Parse("1"));

        }

        private void bt_out_Click(object sender, EventArgs e)
        {
            IPort port = new TcpPort("" + this.tb_ip.Text.ToString().Trim() + ":" + this.tb_port.Text.ToString().Trim() + "");
            _serialize = new ProtoClass();
            TestDevice _device = new TestDevice(port, _serialize);
            eElementCode testenum = (eElementCode)Enum.Parse(typeof(eElementCode), cmb_in_type.SelectedValue.ToString(), false);
            //this.lb_out_content.Text =  _device.Read(testenum, uint.Parse(this.tb_out_Number.Text.ToString().Trim())).ToString().Trim();
            this.lb_out_content.Text = _device.Read( eElementCode.M, 10).ToString().Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPort port = new TcpPort("" + this.tb_ip.Text.ToString().Trim() + ":" + this.tb_port.Text.ToString().Trim() + "");
            _serialize = new ProtoClass();
            TestDevice _device = new TestDevice(port, _serialize);
            eElementCode testenum = (eElementCode)Enum.Parse(typeof(eElementCode), cmb_in_type.SelectedValue.ToString(), false);
            //ushort content = ushort.Parse(this.tb_in_Content.ToString().Trim());
            while (true)
            {
                if ("0" == _device.Read(eElementCode.Y, uint.Parse("1")).ToString().Trim())
                {

                    Thread.Sleep(100);
                    _device.Write(eElementCode.Y, uint.Parse("1"), ushort.Parse("1"));
                }

                Thread.Sleep(100);
                if ("1" == _device.Read(eElementCode.M, uint.Parse("1")).ToString().Trim())
                {
                    _device.Write(eElementCode.Y, uint.Parse("1"), ushort.Parse("0"));
                    Thread.Sleep(100);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPort port = new TcpPort("" + this.tb_ip.Text.ToString().Trim() + ":" + this.tb_port.Text.ToString().Trim() + "");
            _serialize = new ProtoClass();
            WrapDevice _device = new WrapDevice(port, _serialize);
            //_device.Picking();
            Thread.Sleep(10000);
           // _device.Placing();

        }

        private void tb_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_liuhuadao_Click(object sender, EventArgs e)
        {
            IPort portMain = new TcpPort("192.168.10.25:8005");
            IPort portVice = new TcpPort("192.168.10.26:8006");
            IPort portagv = new TcpPort("192.168.10.43:8000");
            _serialize = new ProtoClass();

            VulcanizeDevice Vulcanize = new VulcanizeDevice(portMain, _serialize);
            VulcanizeViceDevice VulcanizeVice = new VulcanizeViceDevice(portVice, _serialize);
            UwantAgvDevice agv = new UwantAgvDevice(portagv, _serialize);
            Work(Vulcanize, VulcanizeVice, agv);
            //Update(Vulcanize, VulcanizeVice);
        }

        protected void Work(VulcanizeDevice Vulcanize, VulcanizeViceDevice VulcanizeVice, UwantAgvDevice agv)
        {
           /* bool isBreak = true;
            while (isBreak)
            {
                int data;
                agv.NodesTate(out data);
                if (data == 6)
                {
                    Vulcanize.AGVExitWaiting();
                   bool isAGVCollectDisc = true;
                    while (isAGVCollectDisc)
                    {
                        switch (Vulcanize.AGVCollectDisc)
                        {
                            case eVulcanizeWorkState.Y:
                                agv.GoTo(0);
                                Logger.LogInfo("节点 6输出参数2" + "------" + "开启");
                                isAGVCollectDisc = false;
                                break;
                            case eVulcanizeWorkState.N:
                                break;
                        }
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(100);
                    isBreak = false;
                }
            }
            Thread.Sleep(100);
            agv.GoTo(1);
            Logger.LogInfo("节点 6输出参数2" + "------"+ "关闭");*/

        }


        protected async void Update(VulcanizeDevice _vulcanize, VulcanizeViceDevice _vulcanizeVice)
        {
            /*while (true)
            {
                await Task.Run(() =>
                {
                        #region 主--->从

                        switch (_vulcanize.GoOutDiscReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.OutDisc(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.VulcanizationDoorUp)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.VulcanizationDoorUpWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.CoolerDoorUp)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.CoolerDoorUpWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.CoolingTransmissionFixedPulse)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.CoolingTransmissionFixedPulseWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.VulcanizationDoorUp)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.VulcanizationDoorUpWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.VulcanizationDoorDown)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.VulcanizationDoorDownWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.CoolerDoorDown)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.CoolerDoorDownWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }


                        switch (_vulcanize.ManualCoolingTransmissionDrive)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.ManualCoolingTransmissionDriveWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.CoolingTransmission)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.CoolingTransmissionWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanize.VulcanizeDoorToZero)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanizeVice.VulcanizeDoorToZero(); break;
                            case eVulcanizeWorkState.N: break;
                        }
                        #endregion

                        #region  从--->主
                        switch (_vulcanizeVice.VulcanizationDoorUpReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.VulcanizationDoorUpReady(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanizeVice.CoolerDoorUpReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.CoolerDoorUpReady(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanizeVice.GoOutDiscReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.OutDiscReady(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanizeVice.VulcanizationDoorDownReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.VulcanizationDoorDownReadyWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanizeVice.CoolerDoorDownReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.CoolerDoorDownReadyWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        //switch (_vulcanizeVice.CoolingTransmissionReady)
                        //{
                        //    case eVulcanizeWorkState.Y:
                        //        _vulcanize.CoolingTransmissionWrite(); break;
                        //    case eVulcanizeWorkState.N: break;
                        //}

                        switch (_vulcanizeVice.CoolingTransmissionReady)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.ExportationTestOfRubberPlate(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanizeVice.CoolingTransmissionFixedPulse)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.CoolingTransmissionFixedPulseWrite(); break;
                            case eVulcanizeWorkState.N: break;
                        }

                        switch (_vulcanizeVice.ExportationTestOfRubberPlate)
                        {
                            case eVulcanizeWorkState.Y:
                                _vulcanize.ExportationTestOfRubberPlate(); break;
                            case eVulcanizeWorkState.N: break;
                        }
                        #endregion
                        Thread.Sleep(50);
                   // }
                });
           }*/
        }
    }
}
