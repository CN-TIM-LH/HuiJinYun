using HuiJinYun.Domain.Entity;
using HuiJinYun.Domain.Entity.AGV;
using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Enum;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Infrastructure.Watcher;
using HuiJinYun.Domain.Log;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuiJinYun.WD
{
    public partial class Main : Form
    {
        //U3DPlayer _u3d;
        TcpToU3D _u3d;
        HuiJinYunProductionLine _line;
        TcpClient _client;
        protected bool _isPass = true;
        protected bool _isFinish = true;
        protected int _pieceNumber = 0;
        protected IPort _port;
        protected ISerialize _serialize;
        public Main()
        {
            InitializeComponent();
            _u3d = new TcpToU3D();
            _u3d.OnReceiveMessage += _u3d_OnReceiveMessage;
            PeptizationStage.OnSync += this.Sync;
            EncapsulationStage.OnSync += this.Sync;
            VulcanizationStage.OnSync += this.Sync;
            UWantAGV<eHuiJinYunAGVState, eHuiJinYunStagePosition>.OnSync += this.Sync;
        }

        private void _u3d_OnReceiveMessage(object sender, U3DPlayerReceiveMessageEventArgs args)
        {
            object fdfd = args.Data;
        }

        protected void InitializeLine()
        {
            try
            {
                _line = new HuiJinYunProductionLine();
                _line.LoadConfig(@"LineConfig.json.txt");
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Start_Click", ex);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.bt_automaticStart.BackColor = Color.Red;
            this.bt_automaticStart.Enabled = false;
            this.cmb_speed.SelectedIndex = 0;
            /*this.Width = 1920;
            this.Height = 1080;*/
        }

        #region  SyncU3D
        public void Sync(object sender, SyncU3D sync)
        {
            try
            {
                switch (sync.type)
                {
                    case eSyncU3D.AGV:
                        switch (sync.Position)
                        {
                            case 1:
                                if (_isPass)
                                {
                                    if (sync.Operate) { _u3d.SendMessage("{Type:avg,id:" + sync.number + ",pointid:" + sync.Position + ",isMove:true,isReset:false}"); }
                                }
                                else
                                {
                                    if (sync.Operate) { _u3d.SendMessage("{Type:agv_reset,isReset:true}"); }
                                }

                                break;
                            case 2:
                                if (sync.Operate) { _u3d.SendMessage("{Type:avg,id:" + sync.number + ",pointid:" + sync.Position + ",isMove:true,isReset:false}"); }
                                break;
                            case 3:
                                if (sync.Operate) { _u3d.SendMessage("{Type:avg,id:" + sync.number + ",pointid:" + sync.Position + ",isMove:true,isReset:false}"); }
                                break;
                            case 4:
                                if (sync.Operate) { _u3d.SendMessage("{Type:avg,id:" + sync.number + ",pointid:" + sync.Position + ",isMove:true,isReset:false}"); }
                                break;
                            case 5:
                                if (sync.Operate) { _u3d.SendMessage("{Type:agv_reset,isReset:true}"); }
                                break;
                        }
                        break;
                    case eSyncU3D.Longmen:
                        switch (sync.Position)
                        {
                            case 1:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:0}"); }
                                break;
                            case 2:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:1}"); }
                                break;
                            case 3:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:2}"); }
                                break;
                            case 4:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:3}"); }
                                break;
                            case 5:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:4}"); }
                                break;
                            case 6:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:5}"); }
                                break;
                            case 7:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:6}"); }
                                break;
                            case 8:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:7}"); }
                                break;
                            case 9:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:8}"); }
                                break;
                            case 10:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:9}"); }
                                break;
                            case 11:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:10}"); }
                                break;
                            case 12:
                                if (sync.Operate) { _u3d.SendMessage("{ Type:long,isMove:true,id:11}"); }
                                break;
                        }
                        break;
                    case eSyncU3D.Switch:
                        switch (sync.number)
                        {
                            case 1:
                                if (sync.Operate) { _u3d.SendMessage("{Type:change,isMove:true,id:1}"); }
                                break;
                            case 2:
                                if (sync.Operate) { _u3d.SendMessage("{Type:change,isMove:true,id:2}"); }
                                break;
                        }
                        break;
                    case eSyncU3D.Vulcanize:
                        switch (sync.number)
                        {
                            case 1:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:1}"); }
                                break;
                            case 2:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:2}"); }
                                break;
                            case 3:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:3}"); }
                                break;
                            case 4:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:4}"); }
                                break;
                            case 5:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:5}"); }
                                break;
                            case 6:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:6}"); }
                                break;
                            case 7:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:7}"); }
                                break;
                            case 8:
                                if (sync.Operate) { _u3d.SendMessage("{Type:Door,isMove:true,id:8}"); }
                                break;
                        }
                        break;
                    case eSyncU3D.Enlace:
                        if (sync.Operate) { _u3d.SendMessage("{Type:robot,isMove:true}"); }
                        break;
                    case eSyncU3D.Rotate:
                        if (sync.Operate) { _u3d.SendMessage("{Type:rotatelp,isMove:true}"); }
                        break;
                    case eSyncU3D.Product:
                        if (sync.Operate) { _u3d.SendMessage("{ Type:js,isMove:true,id:" + sync.number + "}"); }
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("Sync", ex);
            }
        }
        #endregion


        private void bt_automaticStart_Click(object sender, EventArgs e)
        {

            try
            {
                this.bt_automaticStart.BackColor = Color.Red;
                this.bt_automaticStart.Enabled = false;
                if (this.rb_automatic.Checked && (false == this.bt_automaticStart.Enabled))
                {
                    _line.Program(async c =>
                    {
                        var context = (HuiJinYunProductionContext)c;
                        bool stageDone;
                        stageDone = false;


                        #region Vulcanization Stage Exit
                        if (_isPass)
                        {
                            while (context.Position != eHuiJinYunStagePosition.Initial) Thread.Sleep(1000);
                            (_line.Devices["liuhuadaoMain"] as VulcanizeDevice).AGVExitWaiting();

                            Thread.Sleep(1000);

                            Bit.Clr((_line.Devices["liuhuadaoMain"] as VulcanizeDevice).Status, eVulcanizeState.AGVGetTray);

                            context.CurrentAGV.Export(eHuiJinYunStagePosition.Initial, 2, true);

                            while (!Bit.Tst((_line.Devices["liuhuadaoMain"] as VulcanizeDevice).Status, eVulcanizeState.AGVGetTray))Thread.Sleep(1000) ;

                            (_line.Devices["liuhuadaoMain"] as VulcanizeDevice).AGVExitWaiting(false);

                            //Thread.Sleep(1000);
                            //context.CurrentAGV.Export(eHuiJinYunStagePosition.Initial, 2, true);

                            Thread.Sleep(40000);
                            (_line.Devices["liuhuadaoVice"] as VulcanizeViceDevice).OutToAGV(false);
                            Thread.Sleep(1000);
                            (_line.Devices["liuhuadaoVice"] as VulcanizeViceDevice).StopOutToAGV(true);

                            //Thread.Sleep(1000);
                            //while (!Bit.Tst((_line.Devices["liuhuadaoMain"] as VulcanizeDevice).Status, eVulcanizeState.AGVOutLeave)) ;

                            Thread.Sleep(10000);
                            (_line.Devices["liuhuadaoVice"] as VulcanizeViceDevice).StopOutToAGV(false);

                            Thread.Sleep(12000);
                            context.CurrentAGV.Export(eHuiJinYunStagePosition.Initial, 2, false);

                            context.CurrentAGV.State = eHuiJinYunAGVState.Product;
                        }
                        else
                        {
                            _isPass = true;

#if DEBUG
                            Logger.LogInfo($"Vulcanization :Exit, code: by pass");
#endif
                        }
                        #endregion

                        #region  Peptization Stage
                        //add await
                        await context.NextStage();
                        //Peptization Start

                        //await context.Work();

                        //Peptization End
                        #endregion

                        #region Encapsulation Stage
                        stageDone = false;
                        //add await
                        MessageBoxButtons messButton = MessageBoxButtons.YesNo;
                        DialogResult dr = MessageBox.Show("是否已经完成手动解胶操作？", "解胶工序操作提示", messButton);
                        if (dr == DialogResult.Yes)//如果点击“确定”按钮
                        {
                            await context.NextStage();
                        }
                        else
                        {
                            MessageBox.Show("终止执行该工序程序");
                            return true;
                        }

                        // Encapsulation And Enlace Begin

                        //龙门工序
                        await context.Work();

                        _pieceNumber = _pieceNumber * 6;
                        _u3d.SendMessage("{ Type:js,Number:" + _pieceNumber + "}");

                        // Encapsulation And Enlace End
                        #endregion

                        #region  Enlace Stage By Pass
                        stageDone = false;
                        //add await
                        await context.NextStage();
                        //Enlace Stage 缠绕
                        //await context.Work();
                        #endregion

                        #region Vulcanization Stage
                        stageDone = false;
                        //add await
                        await context.NextStage();
                        //Vulcanization Start


                        (_line.Devices["liuhuadaoMain"] as VulcanizeDevice).AGVInWaiting();

                        Bit.Clr((_line.Devices["liuhuadaoMain"] as VulcanizeDevice).Status, eVulcanizeState.AGVSendTray);

                        while (!Bit.Tst((_line.Devices["liuhuadaoMain"] as VulcanizeDevice).Status, eVulcanizeState.AGVSendTray))Thread.Sleep(1000);
                        context.CurrentAGV.Export(eHuiJinYunStagePosition.Initial, 1, true);
                        Thread.Sleep(2000);
                        await context.Work();

                        //Vulcanization End
                        #endregion

                        return true;
                    });
                    if (null != _line)
                    {
                        _line.Start();
                    }
                }
                this.bt_automaticStart.BackColor = Color.DarkGreen;
                this.bt_automaticStart.Enabled = true;

            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Start_Click", ex);
            }
        } 



        private void bt_Initialization_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeLine();
                this.bt_Initialization.BackColor = Color.Red;
                this.bt_Initialization.Enabled = false;
                //this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Initialization_Click", ex);
            }
        }

        private void rb_automatic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_automatic.Checked)
            {
                this.bt_Vulcanization_in.BackColor = Color.Red;
                this.bt_Vulcanization_in.Enabled = false;
                this.bt_Vulcanization_out.BackColor = Color.Red;
                this.bt_Vulcanization_out.Enabled = false;
                this.bt_Enlace.BackColor = Color.Red;
                this.bt_Enlace.Enabled = false;

                this.bt_automaticStart.BackColor = Color.DarkGreen;
                this.bt_automaticStart.Enabled = true;

                this.bt_FrontLine.BackColor = Color.Red;
                this.bt_FrontLine.Enabled = false;
                this.bt_Output_zheng_open.BackColor = Color.Red;
                this.bt_Output_zheng_open.Enabled = false;

                this.bt_Output_zheng_close.BackColor = Color.Red;
                this.bt_Output_zheng_close.Enabled = false;

                this.bt_Output_fan_open.BackColor = Color.Red;
                this.bt_Output_fan_open.Enabled = false;

                this.bt_Output_fan_close.BackColor = Color.Red;
                this.bt_Output_fan_close.Enabled = false;

            }
        }

        private void rb_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Manual.Checked)
            {
                this.bt_automaticStart.BackColor = Color.Red;
                this.bt_automaticStart.Enabled = false;

                this.bt_Vulcanization_in.BackColor = Color.DarkGreen;
                this.bt_Vulcanization_in.Enabled = true;
                this.bt_Vulcanization_out.BackColor = Color.DarkGreen;
                this.bt_Vulcanization_out.Enabled = true;
                this.bt_Enlace.BackColor = Color.DarkGreen;
                this.bt_Enlace.Enabled = true;
                this.bt_FrontLine.BackColor = Color.DarkGreen;
                this.bt_FrontLine.Enabled = true;

                this.bt_Output_zheng_open.BackColor = Color.DarkGreen;
                this.bt_Output_zheng_open.Enabled = true;

                this.bt_Output_zheng_close.BackColor = Color.DarkGreen;
                this.bt_Output_zheng_close.Enabled = true;

                this.bt_Output_fan_open.BackColor = Color.DarkGreen;
                this.bt_Output_fan_open.Enabled = true;

                this.bt_Output_fan_close.BackColor = Color.DarkGreen;
                this.bt_Output_fan_close.Enabled = true;
            }
        }

        private async void bt_Vulcanization_out_Click(object sender, EventArgs e)
        {
            try
            {
                this.bt_Vulcanization_out.BackColor = Color.Red;
                this.bt_Vulcanization_out.Enabled = false;
                if (rb_Manual.Checked && (false == this.bt_Vulcanization_out.Enabled))
                {
                    await Task.Run(() =>
                    {
                        #region Vulcanization Stage Exit

                        var vulDevive = (_line.Devices["liuhuadaoMain"] as VulcanizeDevice);
                        var vulDeviveVice = (_line.Devices["liuhuadaoVice"] as VulcanizeViceDevice);
                        vulDevive.AGVExitWaiting();
                        Thread.Sleep(1000);

                        Bit.Clr(vulDevive.Status, eVulcanizeState.AGVGetTray);
                        while (!Bit.Tst(vulDevive.Status, eVulcanizeState.AGVGetTray)) Thread.Sleep(1000);

                        vulDevive.AGVExitWaiting(false);
                        MessageBoxButtons messButton = MessageBoxButtons.YesNo;
                        DialogResult dr = MessageBox.Show("AGV小车是否已经完成接盘？", "AGV送盘操作提示", messButton);
                        if (dr == DialogResult.Yes)//如果点击“确定”按钮
                        {
                           // Thread.Sleep(40000);
                            vulDeviveVice.StopOutToAGV(true);

                            //Thread.Sleep(1000);
                            //while (!Bit.Tst((_line.Devices["liuhuadaoMain"] as VulcanizeDevice).Status, eVulcanizeState.AGVOutLeave)) ;

                            Thread.Sleep(10000);
                            vulDeviveVice.StopOutToAGV(false);
                            //Thread.Sleep(12000);
                        }
                        else
                        {
                            MessageBox.Show("终止执行改工序程序");
                        }
                        #endregion
                    });
                }
                this.bt_Vulcanization_out.BackColor = Color.DarkGreen;
                this.bt_Vulcanization_out.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Vulcanization_out_Click", ex);
                this.bt_Vulcanization_out.BackColor = Color.DarkGreen;
                this.bt_Vulcanization_out.Enabled = true;
            }
        }

        private async void bt_Enlace_Click(object sender, EventArgs e)
        {
            try
            {
                this.bt_Enlace.BackColor = Color.Red;
                this.bt_Enlace.Enabled = false;
                if (this.rb_Manual.Checked && (false == this.bt_Enlace.Enabled))
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            #region Encapsulation Stage


                            // Encapsulation And Enlace Begin
                            var _switch = (_line.Devices["bjswitch"] as SwitchDevice);
                            var _longmen = (_line.Devices["longmen"] as LongmenDevice);
                            var _enlace = (_line.Devices["chanrao"] as EnlaceDevice);
                            var _crswitch = (_line.Devices["crswitch"] as SwitchDevice);

                            var switchWatcher = new NotifyWatcher(_switch);
                            var longmenWatcher = new NotifyWatcher(_longmen);
                            var enlaceWatcher = new NotifyWatcher(_enlace);
                            var crswitch = new NotifyWatcher(_crswitch);

                            //(包胶周转台) 工控控制
                            _switch.Operate(false); Thread.Sleep(1000);
                            _crswitch.Operate(false);

                            _switch.EStop(true); Thread.Sleep(2000);
                            _switch.EStop(false);

                            _crswitch.Clamp(3, true); Thread.Sleep(2000);
                            _crswitch.Clamp(3, false); Thread.Sleep(100);

                            //(周转台) 输出取盘命令
                            _crswitch.Clamp(1, true);

                            //(缠绕六工位) 检测取盘完成
                            Bit.Clr(_crswitch.Status, eSwitchState.Clamped0);

                            while (!Bit.Tst(_crswitch.Status, eSwitchState.Clamped0)) Thread.Sleep(1000);

                            //(周转台) 输出取盘命令  关闭
                            _crswitch.Clamp(1, false);

                            for (int i = 0; i < 6; i++)
                            //for (int i = 0; i <= 3; i++)
                            //for (int i = 0; i < 1; i++)
                            {
                                _enlace.Reset(true); Thread.Sleep(1000);
                                _enlace.Reset(false);
                                #region Encapsulation longmen
                                if (i < 6)
                                //if (i < 3)
                                //if (i < 1)
                                {
                                    _longmen.BeginPickup(0);

                                    while (!Bit.Tst(_longmen.Status, eLongMenState.InitialPickup)) Thread.Sleep(1000);

                                    _switch.Clamp(i, true);

                                    switch (i)
                                    {
                                        case 0:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped0);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);
                                            break;
                                        case 1:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped1);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);
                                            break;
                                        case 2:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped2);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped2)) Thread.Sleep(1000);
                                            break;
                                        case 3:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped3);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped3)) Thread.Sleep(1000);
                                            break;
                                        case 4:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped4);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped4)) Thread.Sleep(1000);
                                            break;
                                        case 5:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped5);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped5)) Thread.Sleep(1000);
                                            break;
                                    }

                                    _longmen.EndPickup(0);

                                    while (!Bit.Tst(_longmen.Status, eLongMenState.InitialReady)) Thread.Sleep(1000);

                                    //(龙门) 输出工位信号和工位等待信号（PC-O0）
                                    _longmen.BeginPlace(i + 1, 1);

                                    while (!Bit.Tst(_longmen.Status, eLongMenState.StationPickUp)) Thread.Sleep(1000);

                                    //(包胶机) 包胶机卡盘松爪
                                    (_line.Devices[$"bjj{i + 1}"] as WrapDevice).Placing(true); Thread.Sleep(3000);

                                    //(龙门) 取件完成信号（PC-O14）
                                    _longmen.EndPlace(i + 1, 1); Thread.Sleep(100);

                                    //(包胶机) 龙门夹件完成
                                    (_line.Devices[$"bjj{i + 1}"] as WrapDevice).Clamped(true); Thread.Sleep(100);

                                    //(龙门) 检测工位卡盘开爪（PC-I4）
                                    while (!Bit.Tst(_longmen.Status, eLongMenState.StationClampOpen)) Thread.Sleep(1000);

                                    //(龙门)卡盘开爪完成信号（PC-O15）
                                    _longmen.EndPlace(i + 1, 2); Thread.Sleep(3000);

                                    //(龙门)卡盘可以闭爪（PC-I5）
                                    (_line.Devices[$"bjj{i + 1}"] as WrapDevice).Placing(false); Thread.Sleep(2000);

                                    //(龙门)卡盘闭爪完成信号（PC-O16）
                                    _longmen.EndPlace(i + 1, 3);

                                    while (!Bit.Tst(_longmen.Status, eLongMenState.StationReady)) Thread.Sleep(1000);
                                    //(周转台) 输出气缸松开爪信号
                                    _switch.Clamp(i, true);

                                    switch (i)
                                    {
                                        case 0:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped0);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);
                                            break;
                                        case 1:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped1);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);
                                            break;
                                        case 2:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped2);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped2)) Thread.Sleep(1000);
                                            break;
                                        case 3:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped3);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped3)) Thread.Sleep(1000);
                                            break;
                                        case 4:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped4);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped4)) Thread.Sleep(1000);
                                            break;
                                        case 5:
                                            Bit.Clr(_switch.Status, eSwitchState.Unclamped5);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped5)) Thread.Sleep(1000);
                                            break;
                                    }

                                    _longmen.BeginPlace(i + 1, 2);

                                    while (!Bit.Tst(_longmen.Status, eLongMenState.StationPlace)) Thread.Sleep(100);

                                    _switch.Clamp(i, false);

                                    switch (i)
                                    {
                                        case 0:
                                            Bit.Clr(_switch.Status, eSwitchState.Clamped0);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped0)) Thread.Sleep(1000);
                                            break;
                                        case 1:
                                            Bit.Clr(_switch.Status, eSwitchState.Clamped1);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped1)) Thread.Sleep(1000);
                                            break;
                                        case 2:
                                            Bit.Clr(_switch.Status, eSwitchState.Clamped2);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped2)) Thread.Sleep(1000);
                                            break;
                                        case 3:
                                            Bit.Clr(_switch.Status, eSwitchState.Clamped3);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped3)) Thread.Sleep(1000);
                                            break;
                                        case 4:
                                            Bit.Clr(_switch.Status, eSwitchState.Clamped4);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped4)) Thread.Sleep(1000);
                                            break;
                                        case 5:
                                            Bit.Clr(_switch.Status, eSwitchState.Clamped5);
                                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped5)) Thread.Sleep(1000);
                                            break;
                                    }

                                    _longmen.EndPlace(i + 1, 4);

                                    (_line.Devices[$"bjj{i + 1}"] as WrapDevice).EStop(true); Thread.Sleep(100);

                                    (_line.Devices[$"bjj{i + 1}"] as WrapDevice).EStop(false);
                                }

                                while (!Bit.Tst(_longmen.Status, eLongMenState.InitialStation)) Thread.Sleep(1000);
                                #endregion

                                if (i <= 5)
                                {
                                    //(周转台) 输出气工位旋转
                                    _switch.Rotate();Thread.Sleep(10000);

                                    Bit.Clr(_switch.Status, eSwitchState.Rotate);
                                    while (!Bit.Tst(_switch.Status, eSwitchState.Rotate)) Thread.Sleep(1000);
                                }

                                //(周转台) 输出气工位旋转信号 关闭
                                _switch.Rotate(false);

                                #region Enlace

                                _enlace.RevolvingDiscInPlace(); Thread.Sleep(3000);

                                //if (i < 1)
                                //{
                                //    //(缠绕机) 输出启动
                                //    _enlace.Start(); Thread.Sleep(1000);
                                //}

                                //(缠绕机) 输出周转盘旋转到位 信号取消
                                _enlace.RevolvingDiscInPlace(false); Thread.Sleep(100);

                                Bit.Clr(_enlace.Status, eEnlaceState.TurntableUndone);
                                while (!Bit.Tst(_enlace.Status, eEnlaceState.TurntableUndone)) Thread.Sleep(100);

                                //(周转台) 输出气缸松开爪信号
                                _switch.Clamp(i, true);

                                switch (i)
                                {
                                    case 0:
                                        Bit.Clr(_switch.Status, eSwitchState.Unclamped0);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);
                                        break;
                                    case 1:
                                        Bit.Clr(_switch.Status, eSwitchState.Unclamped1);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);
                                        break;
                                    case 2:
                                        Bit.Clr(_switch.Status, eSwitchState.Unclamped2);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped2)) Thread.Sleep(1000);
                                        break;
                                    case 3:
                                        Bit.Clr(_switch.Status, eSwitchState.Unclamped3);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped3)) Thread.Sleep(1000);
                                        break;
                                    case 4:
                                        Bit.Clr(_switch.Status, eSwitchState.Unclamped4);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped4)) Thread.Sleep(1000);
                                        break;
                                    case 5:
                                        Bit.Clr(_switch.Status, eSwitchState.Unclamped5);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped5)) Thread.Sleep(1000);
                                        break;
                                }

                                _enlace.UnRevolvingDisc(); Thread.Sleep(1000);

                                //(缠绕机) 检测周转盘夹紧
                                Bit.Clr(_enlace.Status, eEnlaceState.TurntableClamping);

                                while (!Bit.Tst(_enlace.Status, eEnlaceState.TurntableClamping)) Thread.Sleep(1000);
                          
                                //(缠绕机) 输出周转盘夹紧
                                _switch.Clamp(i, false);
                                switch (i)
                                {
                                    case 0:
                                        Bit.Clr(_switch.Status, eSwitchState.Clamped0);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Clamped0)) Thread.Sleep(1000);
                                        break;
                                    case 1:
                                        Bit.Clr(_switch.Status, eSwitchState.Clamped1);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Clamped1)) Thread.Sleep(1000);
                                        break;
                                    case 2:
                                        Bit.Clr(_switch.Status, eSwitchState.Clamped2);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Clamped2)) Thread.Sleep(1000);
                                        break;
                                    case 3:
                                        Bit.Clr(_switch.Status, eSwitchState.Clamped3);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Clamped3)) Thread.Sleep(1000);
                                        break;
                                    case 4:
                                        Bit.Clr(_switch.Status, eSwitchState.Clamped4);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Clamped4)) Thread.Sleep(1000);
                                        break;
                                    case 5:
                                        Bit.Clr(_switch.Status, eSwitchState.Clamped5);
                                        while (!Bit.Tst(_switch.Status, eSwitchState.Clamped5)) Thread.Sleep(1000);
                                        break;
                                }

                                _enlace.TurntableClampingReady();

                                Bit.Clr(_enlace.Status, eEnlaceState.RevolvingDiskRotation);

                                //(缠绕机) 周转盘旋转信号
                                while (!Bit.Tst(_enlace.Status, eEnlaceState.RevolvingDiskRotation)) Thread.Sleep(1000);

                                //  旋转(缠绕六工位)
                                _crswitch.Clamp(0, true); Thread.Sleep(2000);

                                //(缠绕六工位) 周转盘旋转信号
                                Bit.Clr(_crswitch.Status, eSwitchState.Unclamped0);
                                Thread.Sleep(3000);
                                while (!Bit.Tst(_crswitch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);

                                //  旋转(缠绕六工位)
                                _crswitch.Clamp(0, false);
                                #endregion

                                _enlace.Reset(true); Thread.Sleep(100);
                                _enlace.Reset(false);
                            }

                            /*
                            var task1 = Task.Run(() =>
                            {
                                Logger.LogInfo($"右 周转盘 开始执行");

                                //三个芯子
                                //for (int i = 3; i > 0; i--)
                                //五个芯子

                                for (int i = 5; i > 0; i--)
                                {
                                    //龙门交换台旋转
                                    _switch.Rotate();
                                    Logger.LogInfo($"右 下发旋转命令 次数 ---{i}");
                                    Thread.Sleep(1000);
                                    while (!Bit.Tst(_switch.Status, eSwitchState.Rotate)) Thread.Sleep(100);
                                    Logger.LogInfo($"右 监测到旋转到位信号 次数 ---{i}");
                                    //(周转台) 输出气工位旋转信号 关闭
                                    _switch.Rotate(false);
                                }
                            });

                            var task2 = Task.Run(() =>
                            {
                                Logger.LogInfo($"左 周转盘 开始执行");
                                //三个芯子
                                //for (int i = 3; i > 0; i--)
                                //一个芯子
                                for (int i = 6; i > 0; i--)
                                {
                                    //  旋转(缠绕六工位)
                                    _crswitch.Clamp(0, true); Thread.Sleep(3000);
                                    Logger.LogInfo($"左 下发旋转命令 次数 ---{i}");
                                    //(缠绕六工位) 周转盘旋转信号
                                    while (!Bit.Tst(_crswitch.Status, eSwitchState.Unclamped0)) Thread.Sleep(100);

                                    Logger.LogInfo($"左 监测到旋转到位信号 次数 ---{i}");
                                    _crswitch.Clamp(4, true); Thread.Sleep(2000);
                                    _crswitch.Clamp(4, false);

                                    //  旋转(缠绕六工位)
                                    _crswitch.Clamp(0, false);
                                }
                            });

                            Task.WaitAll(task1, task2);

                            */

                            /*
                            //  旋转(缠绕六工位)
                            _crswitch.Clamp(0, true); Thread.Sleep(2000);

                            //(缠绕六工位) 周转盘旋转信号
                            while (!Bit.Tst(_crswitch.Status, eSwitchState.Unclamped0)) Thread.Sleep(100);

                            //  旋转(缠绕六工位)
                            _crswitch.Clamp(0, false);
                            */

                            Thread.Sleep(3000);

                            //(周转台) 输出放盘命令
                            _crswitch.Clamp(2, true);

                            Bit.Clr(_crswitch.Status, eSwitchState.Unclamped1);
                            Thread.Sleep(3000);
                            //(缠绕六工位) 周转盘旋转信号
                            while (!Bit.Tst(_crswitch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);

                            //(周转台) 输出放盘命令 关闭
                            _crswitch.Clamp(2, false);

                            _pieceNumber = _pieceNumber * 6;
                            _u3d.SendMessage("{ Type:js,Number:" + _pieceNumber + "}");

                            // Encapsulation And Enlace End
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            Logger.ErrorInfo("bt_Enlace_Click  ^", ex);
                        }
                    });

                    this.bt_Enlace.BackColor = Color.DarkGreen;
                    this.bt_Enlace.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Enlace_Click", ex);
                this.bt_Enlace.BackColor = Color.DarkGreen;
                this.bt_Enlace.Enabled = true;
            }
        }


        private async void bt_Vulcanization_in_Click(object sender, EventArgs e)
        {
            try
            {
                this.bt_Vulcanization_in.BackColor = Color.Red;
                this.bt_Vulcanization_in.Enabled = false;
                if (rb_Manual.Checked && (false == this.bt_Vulcanization_in.Enabled))
                {
                    await Task.Run(() =>
                    {
                        #region Vulcanization Stage
                        //Vulcanization Start
                        var vulDevive = (_line.Devices["liuhuadaoMain"] as VulcanizeDevice);

                        vulDevive.AGVInWaiting();
                        /*
                        while (!Bit.Tst(vulDevive.Status, eVulcanizeState.AGVSendTray))  Thread.Sleep(1000);
                        //context.CurrentAGV.Export(eHuiJinYunStagePosition.Initial, 1, true);
                        MessageBoxButtons messButton = MessageBoxButtons.YesNo;
                        DialogResult dr = MessageBox.Show("是否已经完成手动启动AGV接盘滚轮转动？", "AGV送盘操作提示", messButton);
                        if (dr == DialogResult.Yes)
                        {
                            new NotifyWatcher(vulDevive).WaitOne((s, a) => Bit.Tst((s as VulcanizeDevice).Status, eVulcanizeState.AGVInLeave), 1000);
                            Thread.Sleep(1000);
                            (_line.Devices["liuhuadaoMain"] as VulcanizeDevice).AGVInWaiting(false);
                        }
                        else
                        {
                            MessageBox.Show("终止执行该工序程序");
                        }
                        */
                        //Vulcanization End
                        #endregion
                    });
                }
                this.bt_Vulcanization_in.BackColor = Color.DarkGreen;
                this.bt_Vulcanization_in.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Vulcanization_in_Click", ex);
                this.bt_Vulcanization_in.BackColor = Color.DarkGreen;
                this.bt_Vulcanization_in.Enabled = true;
            }
        }

        private  void bt_FrontLine_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rb_agv_03.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.43:8000"), _serialize);
                    byte carnumber = byte.Parse("3");
                    _device.FrontPatrol(carnumber, this.cmb_speed.SelectedItem.ToString());
                }
                if (this.rb_agv_04.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.44:8000"), _serialize);
                    byte carnumber = byte.Parse("4");
                    _device.FrontPatrol(carnumber, this.cmb_speed.SelectedItem.ToString());
                }
                if (this.rb_agv_06.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.46:8000"), _serialize);
                    byte carnumber = byte.Parse("6");
                    _device.FrontPatrol(carnumber, this.cmb_speed.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Output_zheng_open_Click", ex);
            }
        }

        private void bt_Output_zheng_open_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rb_agv_03.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.43:8000"), _serialize);
                    byte carnumber = byte.Parse("3");
                    _device.SetOutput_Open(carnumber);
                }
                if (this.rb_agv_04.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.44:8000"), _serialize);
                    byte carnumber = byte.Parse("4");
                    _device.SetOutput_Open(carnumber);
                }
                if (this.rb_agv_06.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.46:8000"), _serialize);
                    byte carnumber = byte.Parse("6");
                    _device.SetOutput_Open(carnumber);
                }
            }
            catch (Exception ex){
                Logger.ErrorInfo("bt_Output_zheng_open_Click", ex);
            }
        }

        private void bt_Output_zheng_close_Click(object sender, EventArgs e)
        {try
            {
                if (this.rb_agv_03.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.43:8000"), _serialize);
                    byte carnumber = byte.Parse("3");
                    _device.SetOutput_close(carnumber);
                }
                if (this.rb_agv_04.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.44:8000"), _serialize);
                    byte carnumber = byte.Parse("4");
                    _device.SetOutput_close(carnumber);
                }
                if (this.rb_agv_06.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.46:8000"), _serialize);
                    byte carnumber = byte.Parse("6");
                    _device.SetOutput_close(carnumber);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Output_zheng_close_Click", ex);
            }
        }

        private void bt_Output_fan_open_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rb_agv_03.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.43:8000"), _serialize);
                    byte carnumber = byte.Parse("3");
                    _device.SetOutput_fan_Open(carnumber);
                }
                if (this.rb_agv_04.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.44:8000"), _serialize);
                    byte carnumber = byte.Parse("4");
                    _device.SetOutput_fan_Open(carnumber);
                }
                if (this.rb_agv_06.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.46:8000"), _serialize);
                    byte carnumber = byte.Parse("6");
                    _device.SetOutput_fan_Open(carnumber);
                }
            }
            catch (Exception ex){
                Logger.ErrorInfo("bt_Output_fan_open_Click", ex);
            }
        }

        private void bt_Output_fan_close_Click(object sender, EventArgs e)
        {
            try {
                if (this.rb_agv_03.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.43:8000"), _serialize);
                    byte carnumber = byte.Parse("3");
                    _device.SetOutput_fan_close(carnumber);
                }
                if (this.rb_agv_04.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.44:8000"), _serialize);
                    byte carnumber = byte.Parse("4");
                    _device.SetOutput_fan_close(carnumber);
                }
                if (this.rb_agv_06.Checked)
                {
                    _serialize = new ProtoClass();
                    UwantAgvDevice _device = new UwantAgvDevice(new TcpPort("192.168.10.46:8000"), _serialize);
                    byte carnumber = byte.Parse("6");
                    _device.SetOutput_fan_close(carnumber);
                }
            } catch (Exception ex)
            {
                Logger.ErrorInfo("bt_Output_fan_close_Click", ex);
            }
        }
    }
}