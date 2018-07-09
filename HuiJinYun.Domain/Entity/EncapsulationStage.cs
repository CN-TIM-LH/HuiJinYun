using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Enum;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Infrastructure.Watcher;
using HuiJinYun.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public delegate void SyncLMAndEnlaceHandler(object sender, SyncU3D sync);

    /// <summary>
    /// 包胶
    /// </summary>
    public class EncapsulationStage : IProductionStage
    {
        protected SwitchDevice _switch;
        protected SwitchDevice _crswitch;
        protected LongmenDevice _longmen;
        protected EnlaceDevice _enlace;
        protected WrapDevice[] _warps;
        protected Task _runningTask;

        protected bool _isRepeatUnclamped = false;
        protected bool _isRepeatclamped = false;

        public static event SyncSwitchHandler OnSync;

        public Dictionary<string, int> StationDictionary { get; set; }

        public eProductionStageState Status { get; protected set; } = eProductionStageState.Stop;

        public EncapsulationStage(SwitchDevice @switch, SwitchDevice crswitch, EnlaceDevice enlace, LongmenDevice longmen, params WrapDevice[] wraps)
        {
            _switch = @switch;
            _crswitch = crswitch;
            _longmen = longmen;
            _enlace = enlace;
            _warps = wraps;
        }

        public  IProductionStage Bypass(object args, out object result)
        {
            var context = (HuiJinYunProductionContext)args;
            result = null;
            return this;
        }
        public IProductionStage Work(object args, out object result)
        {
            result = null;
            return this;
        }


        public async Task<IProductionStage> Work(object args)
        {
            var context = (HuiJinYunProductionContext)args;
            var switchWatcher = new NotifyWatcher(_switch);
            var longmenWatcher = new NotifyWatcher(_longmen);
            var enlaceWatcher = new NotifyWatcher(_enlace);
            var crswitch = new NotifyWatcher(_crswitch);

#if DEBUG
            Logger.LogInfo($"EncapsulationStage Start");
#endif

            //(包胶周转台) 工控控制
            _switch.Operate(false); Thread.Sleep(100);
            _crswitch.Operate(false);

            _switch.EStop(true); Thread.Sleep(2000);
            _switch.EStop(false);

            _crswitch.Clamp(3, true); Thread.Sleep(2000);
            _crswitch.Clamp(3, false); Thread.Sleep(100);

            //(周转台) 输出取盘命令
            _crswitch.Clamp(1, true);

            Bit.Clr(_crswitch.Status, eSwitchState.Clamped0);
            //(缠绕六工位) 检测取盘完成
            while (!Bit.Tst(_crswitch.Status, eSwitchState.Clamped0)) Thread.Sleep(2000);

            //(周转台) 输出取盘命令  关闭
            _crswitch.Clamp(1, false);

            Task<bool> taskEnlace = null;
            for (int i = 0; i < 6; i++)
            //for (int i = 0; i <= 3; i++)
            //for (int i = 0; i < 1; i++)
            {
                int pos = i;
                //龙门包胶机操作线程
                await Task.Run(() =>
                {
                    /****************Start 龙门包胶机操作部分 *****************/
                    _enlace.Reset(true); Thread.Sleep(100);
                    _enlace.Reset(false);
                    #region Encapsulation longmen
                    if (pos < 6)
                    //if (i < 3)
                    //if (i < 1)
                    {
                        _longmen.BeginPickup(0);
                        while (!Bit.Tst(_longmen.Status, eLongMenState.InitialPickup)) Thread.Sleep(1000);

                        switch (pos)
                        {
                            case 0:
                                _switch.Clamp(0, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped0);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);
                                break;
                            case 1:
                                _switch.Clamp(1, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped1);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);
                                break;
                            case 2:
                                _switch.Clamp(2, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped2);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped2)) Thread.Sleep(1000);
                                break;
                            case 3:
                                _switch.Clamp(3, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped3);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped3)) Thread.Sleep(1000);
                                break;
                            case 4:
                                _switch.Clamp(4, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped4);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped4)) Thread.Sleep(1000);
                                break;
                            case 5:
                                _switch.Clamp(5, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped5);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped5)) Thread.Sleep(1000);
                                break;
                        }

                        _longmen.EndPickup(0);

                        while (!Bit.Tst(_longmen.Status, eLongMenState.InitialReady)) Thread.Sleep(1000);


                        //选择工位
                        int en;
                        while((en = FindWrap()) == -1) Thread.Sleep(1000);
                        
                        //_enlace.Reset(true); Thread.Sleep(100);
                        //_enlace.Reset(false);

                        //(龙门) 输出工位信号和工位等待信号（PC-O0）
                        _longmen.BeginPlace(en + 1, 1);

                        while (!Bit.Tst(_longmen.Status, eLongMenState.StationPickUp)) Thread.Sleep(1000);

                        //(包胶机) 包胶机卡盘松爪
                        _warps[en].Placing(true); Thread.Sleep(3000);

                        //(龙门) 取件完成信号（PC-O14）
                        _longmen.EndPlace(en + 1, 1); Thread.Sleep(100);

                        //(包胶机) 龙门夹件完成
                        _warps[en].Clamped(true); Thread.Sleep(5000);
                        _warps[en].Clamped(false);


                        //(龙门) 检测工位卡盘开爪（PC-I4）
                        while (!Bit.Tst(_longmen.Status, eLongMenState.StationClampOpen)) Thread.Sleep(1000);

                        //(龙门)卡盘开爪完成信号（PC-O15）
                        _longmen.EndPlace(en + 1, 2); Thread.Sleep(3000);

                        //(龙门)卡盘可以闭爪（PC-I5）
                        _warps[en].Placing(false); Thread.Sleep(2000);

                        //(龙门)卡盘闭爪完成信号（PC-O16）
                        _longmen.EndPlace(en + 1, 3);

                        while (!Bit.Tst(_longmen.Status, eLongMenState.StationReady)) Thread.Sleep(1000);

                        //(周转台) 输出气缸松开爪信号
                        switch (pos)
                        {
                            case 0:
                                _switch.Clamp(0, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped0);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);
                                break;
                            case 1:
                                _switch.Clamp(1, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped1);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);
                                break;
                            case 2:
                                _switch.Clamp(2, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped2);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped2)) Thread.Sleep(1000);
                                break;
                            case 3:
                                _switch.Clamp(3, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped3);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped3)) Thread.Sleep(1000);
                                break;
                            case 4:
                                _switch.Clamp(4, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped4);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped4)) Thread.Sleep(1000);
                                break;
                            case 5:
                                _switch.Clamp(5, true);
                                Bit.Clr(_switch.Status, eSwitchState.Unclamped5);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped5)) Thread.Sleep(1000);
                                break;
                        }

                        _longmen.BeginPlace(en + 1, 2);
                        while (!Bit.Tst(_longmen.Status, eLongMenState.StationPlace)) Thread.Sleep(1000);

                        switch (pos)
                        {
                            case 0:
                                _switch.Clamp(0, false);
                                Bit.Clr(_switch.Status, eSwitchState.Clamped0);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Clamped0)) Thread.Sleep(1000);
                                break;
                            case 1:
                                _switch.Clamp(1, false);
                                Bit.Clr(_switch.Status, eSwitchState.Clamped1);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Clamped1)) Thread.Sleep(1000);
                                break;
                            case 2:
                                _switch.Clamp(2, false);
                                Bit.Clr(_switch.Status, eSwitchState.Clamped2);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Clamped2)) Thread.Sleep(1000);
                                break;
                            case 3:
                                _switch.Clamp(3, false);
                                Bit.Clr(_switch.Status, eSwitchState.Clamped3);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Clamped3)) Thread.Sleep(1000);
                                break;
                            case 4:
                                _switch.Clamp(4, false);
                                Bit.Clr(_switch.Status, eSwitchState.Clamped4);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Clamped4)) Thread.Sleep(1000);
                                break;
                            case 5:
                                _switch.Clamp(5, false);
                                Bit.Clr(_switch.Status, eSwitchState.Clamped5);
                                while (!Bit.Tst(_switch.Status, eSwitchState.Clamped5)) Thread.Sleep(1000);
                                break;
                        }
                        _longmen.EndPlace(pos + 1, 4);

                        _warps[en].EStop(true); Thread.Sleep(1000);
                        _warps[en].EStop(false);
                        Thread.Sleep(1000);
                        //移除操作工位
                        //context.EncapsulationDevice.Remove(en);
                    }

                    while (!Bit.Tst(_longmen.Status, eLongMenState.InitialStation)) Thread.Sleep(1000);
                    #endregion
                    return true;
                    /****************End 龙门包胶机操作部分 *****************/
                });

                if (null != taskEnlace) await taskEnlace;

                if (pos <= 5)
                {
                    //(周转台) 输出气工位旋转
                    _switch.Rotate(); Thread.Sleep(10000);
                    Bit.Clr(_switch.Status, eSwitchState.Rotate);
                    while (!Bit.Tst(_switch.Status, eSwitchState.Rotate)) Thread.Sleep(1000);
                    //(周转台) 输出气工位旋转信号 关闭
                    _switch.Rotate(false);
                }


                taskEnlace = Task.Run(() =>
                {
                    /****************Start 机器人操作部分 *****************/

                    #region Enlace

                    _enlace.RevolvingDiscInPlace(); Thread.Sleep(3000);

                    //if (pos < 1)
                    //{
                    //    if (context.isStart)
                    //    {
                    //        //(缠绕机) 输出启动
                    //        _enlace.Start(); Thread.Sleep(1000);
                    //        context.isStart = false;
                    //    }
                    //}

                    //(缠绕机) 输出周转盘旋转到位 信号取消
                    _enlace.RevolvingDiscInPlace(false); Thread.Sleep(100);

                    Bit.Clr(_enlace.Status, eEnlaceState.TurntableUndone);
                    while (!Bit.Tst(_enlace.Status, eEnlaceState.TurntableUndone)) Thread.Sleep(100);

                    switch (pos)
                    {
                        case 0:
                            _switch.Clamp(0, true);
                            Bit.Clr(_switch.Status, eSwitchState.Unclamped0);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped0)) Thread.Sleep(1000);
                            break;
                        case 1:
                            _switch.Clamp(1, true);
                            Bit.Clr(_switch.Status, eSwitchState.Unclamped1);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);
                            break;
                        case 2:
                            _switch.Clamp(2, true);
                            Bit.Clr(_switch.Status, eSwitchState.Unclamped2);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped2)) Thread.Sleep(1000);
                            break;
                        case 3:
                            _switch.Clamp(3, true);
                            Bit.Clr(_switch.Status, eSwitchState.Unclamped3);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped3)) Thread.Sleep(1000);
                            break;
                        case 4:
                            _switch.Clamp(4, true);
                            Bit.Clr(_switch.Status, eSwitchState.Unclamped4);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped4)) Thread.Sleep(1000);
                            break;
                        case 5:
                            _switch.Clamp(5, true);
                            Bit.Clr(_switch.Status, eSwitchState.Unclamped5);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Unclamped5)) Thread.Sleep(1000);
                            break;
                    }

                    _enlace.UnRevolvingDisc(); Thread.Sleep(1000);

                    //(缠绕机) 检测周转盘夹紧
                    Bit.Clr(_enlace.Status, eEnlaceState.TurntableClamping);

                    while (!Bit.Tst(_enlace.Status, eEnlaceState.TurntableClamping)) Thread.Sleep(1000);

                    switch (pos)
                    {
                        case 0:
                            _switch.Clamp(0, false);
                            Bit.Clr(_switch.Status, eSwitchState.Clamped0);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped0)) Thread.Sleep(1000);
                            break;
                        case 1:
                            _switch.Clamp(1, false);
                            Bit.Clr(_switch.Status, eSwitchState.Clamped1);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped1)) Thread.Sleep(1000);
                            break;
                        case 2:
                            _switch.Clamp(2, false);
                            Bit.Clr(_switch.Status, eSwitchState.Clamped2);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped2)) Thread.Sleep(1000);
                            break;
                        case 3:
                            _switch.Clamp(3, false);
                            Bit.Clr(_switch.Status, eSwitchState.Clamped3);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped3)) Thread.Sleep(1000);
                            break;
                        case 4:
                            _switch.Clamp(4, false);
                            Bit.Clr(_switch.Status, eSwitchState.Clamped4);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped4)) Thread.Sleep(1000);
                            break;
                        case 5:
                            _switch.Clamp(5, false);
                            Bit.Clr(_switch.Status, eSwitchState.Clamped5);
                            while (!Bit.Tst(_switch.Status, eSwitchState.Clamped5)) Thread.Sleep(1000);
                            break;
                    }
                    _enlace.TurntableClampingReady();

                    //(缠绕机) 周转盘旋转信号
                    Bit.Clr(_enlace.Status, eEnlaceState.RevolvingDiskRotation);
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

                    /****************End 机器人操作部分 *****************/

                    _enlace.Reset(true); Thread.Sleep(100);
                    _enlace.Reset(false);

                    return true;
                });
            }
            if (null != taskEnlace) await taskEnlace;

            /*
            //  旋转(缠绕六工位)
            _crswitch.Clamp(0, true); Thread.Sleep(2000);

            //(缠绕六工位) 周转盘旋转信号
            while (!Bit.Tst(_crswitch.Status, eSwitchState.Unclamped0)) Thread.Sleep(100);

            //  旋转(缠绕六工位)
            _crswitch.Clamp(0, false);
            */
            Thread.Sleep(10000);

            //(周转台) 输出放盘命令
            _crswitch.Clamp(2, true);
            Bit.Clr(_crswitch.Status, eSwitchState.Unclamped1);
            Thread.Sleep(3000);
            //(缠绕六工位) 周转盘旋转信号
            while (!Bit.Tst(_crswitch.Status, eSwitchState.Unclamped1)) Thread.Sleep(1000);

            //(周转台) 输出放盘命令 关闭
            _crswitch.Clamp(2, false);

            // Encapsulation And Enlace End         
            Status = eProductionStageState.Ready;
            context.CurrentAGV.State = eHuiJinYunAGVState.Tray;
            Status = eProductionStageState.Finish;

            //result = null;
#if DEBUG
            Logger.LogInfo($"EncapsulationStage Finish");
#endif
            return this;
        }

        #region Update
        public async void Update(object args)
        {
            var context = (HuiJinYunProductionContext)args;
            while (true)
            {

                var status = Task.Run(() =>
                {
                    for (int i = 0; i < _warps.Length; i++)
                    {
                        try
                        {
                            if (Bit.Tst(_warps[i].Status, eWrapState.ToZero))
                            {
                                Encapsulation en = new Encapsulation() { Id = i, IsBusy = false, isOnline = _warps[i].isOnline };
                                if (context._encapsulationDevice.ToList().Where(c => c.Id == en.Id).Count() < 1)
                                {
                                    context._encapsulationDevice.Add(en);
                                }
                                Logger.LogInfo($"Encapsulation :Encapsulation, code: {i}");
                            }
                        }
                        catch (Exception ex)
                        {
#if DEBUG
                            Logger.ErrorInfo($"Main :Encapsulation", ex);
#endif
                        }
                    }

                    Thread.Sleep(1000);
                    return context._encapsulationDevice;
                });
                context._encapsulationDevice = await status;
            }
        }
        #endregion

        public int FindWrap()
        {
            int curTimestamp = int.MaxValue;
            int index = -1;
            for (int i = 0; i < _warps.Length; i++)
            {
                if (curTimestamp > _warps[i].ZeroTimestamp)
                {
                    index = i;
                    curTimestamp = _warps[i].ZeroTimestamp;
                }
            }
            return index;
        }
    }
}
