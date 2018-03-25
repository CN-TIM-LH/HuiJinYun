using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Entity.LM;
using Automation.BDaq;
using HuiJinYun.Domain.Log;
using System.Threading;

namespace HuiJinYun.Domain.Entity.Device
{
    public enum eLongMenState : UInt32
    {
        Null,

        /// <summary>
        /// 初始位置
        /// </summary>
        InitialStation = 1 << 0,
        InitialPickup = 1 << 1,
        InitialReady = 1 << 2,

        /// <summary>
        /// 工位
        /// </summary>
        StationPickUp = 1 << 3,
        StationClampOpen = 1 << 4,
        StationClampClose = 1 << 5,
        StationReady = 1 << 6,
        StationPlace = 1 << 7,

        Next = 1 << 8,
    }

    public enum eLongMenOption : UInt32
    {
        Null,
        InitialBeginPickup = 1 << 0,
        InitialEndPickup = 1 << 1,
        Station1 = 1 << 2,
        Station2 = 1 << 3,
        Station3 = 1 << 4,
        Station4 = 1 << 5,
        Station5 = 1 << 6,
        Station6 = 1 << 7,
        Station7 = 1 << 8,
        Station8 = 1 << 9,
        Station9 = 1 << 10,
        Station10 = 1 << 11,
        Station11 = 1 << 12,
        Station12 = 1 << 13,

        //StationOption
        PickupEnd = 1 << 14,
        ClampOpen = 1 << 15,

        WaitStation = 1 << 16,
        StationBeginPlace = 1 << 17,
        StationEndPlace = 1 << 18,
    }
    public class LongmenDevice : PlcDeviceBase
    {
        protected DeviceInformation _device;
        protected InstantDoCtrl _instantDoCtrl;
        protected InstantDiCtrl _instantDiCtrl;

        protected eLongMenOption _option = default(eLongMenOption);
        protected eLongMenState _status = default(eLongMenState);
        public eLongMenOption Option
        {
            get
            {
                return _option;
            }
            protected set
            {
                lock (_instantDoCtrl)
                {
                    if (_option != value)
                    {
                        _option = value;
                        var data = BitConverter.GetBytes((UInt32)_option);
                        _instantDoCtrl.Write(0, data.Length, data);
                    }
                }
            }
        }
        public eLongMenState Status
        {
            get
            {
                lock (_instantDiCtrl)
                {
                    byte[] data = new byte[4];
                    _instantDiCtrl.Read(0, data.Length, data);
                    _status = (eLongMenState)BitConverter.ToUInt32(data, 0);
                }
                return _status;
            }
            protected set
            {
                if (_status != value)
                {
                    var changed = _status ^ value;
                    _status = value;
                    StateChanged(new DeviceStateChangeEventArgs(changed));
                }
            }
        }

        public LongmenDevice(IPort port, ISerialize serialize) :
            base(port, serialize)
        {
            _device = new DeviceInformation(((PortBase)port).Port);
            _instantDoCtrl = new InstantDoCtrl();
            _instantDoCtrl.SelectedDevice = _device;
            _instantDiCtrl = new InstantDiCtrl();
            _instantDiCtrl.SelectedDevice = _device;

            byte[] data = new byte[4];
            _instantDoCtrl.Write(0, data.Length, data);
            _option = default(eLongMenOption);
            _instantDiCtrl.Read(0, data.Length, data);
            Status = (eLongMenState)BitConverter.ToUInt32(data, 0);
        }

        /// <summary>
        ///  开始取件
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IDevice BeginPickup(int position)
        {
            Option = eLongMenOption.Null;
            if (0 == position)
            {
                //Initial Pickup
                while (!Bit.Tst(Status, eLongMenState.InitialStation)) Thread.Sleep(1000);
                Option = Bit.Set(Option, eLongMenOption.InitialBeginPickup);
            }
            else
            {
                //Station Pickup

            }
            return this;
        }
        /// <summary>
        ///  结束取件
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IDevice EndPickup(int position)
        {
            Option = eLongMenOption.Null;
            if (0 == position)
            {
                //InitialStation Pickup
                while (!Bit.Tst(Status, eLongMenState.InitialPickup)) Thread.Sleep(1000);
                Option = Bit.Set(Option, eLongMenOption.InitialEndPickup);
            }
            else
            {
                //Station Pickup

            }
            return this;
        }

        /// <summary>
        /// 开始放件
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        //public IDevice BeginPlace(int position) 
        public IDevice BeginPlace(int position,int opertion)
        {
            Option = eLongMenOption.Null;
            if (0 == position)
            {

            }
            else if(position >= 1 && position <= 12)
            {
                //Station Place

                //检测工位选择信号（PC-I2）
                //while (!Bit.Tst(Status, eLongMenState.InitialReady)) Thread.Sleep(1000);
                //输出对应的工位信号
                //Option = Bit.Set(Option, (eLongMenOption)(1 << (position + 0x00000001)));
                //输出对应工位信号（PC-O16）
                //Option = Bit.Set(Option, eLongMenOption.WaitStation);

                switch (opertion)
                {
                    case 1:
                        //检测工位选择信号（PC-I2）
                        while (!Bit.Tst(Status, eLongMenState.InitialReady)) Thread.Sleep(1000);
                        //输出对应的工位信号
                        Option = Bit.Set(Option, (eLongMenOption)(1 << (position + 0x00000001)));
                        //输出对应工位信号（PC-O16）
                        Option = Bit.Set(Option, eLongMenOption.WaitStation);

                        break;
                    case 2:
                        //检测可放件信号（PC-I6）
                        while (!Bit.Tst(Status, eLongMenState.StationReady)) Thread.Sleep(1000);
                        //输出可放件信号（PC-O17）
                        Option = Bit.Set(Option, eLongMenOption.StationBeginPlace);
                        break;
                }
            }
            return this;
        }

      
        /// <summary>
        /// 结束放件
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IDevice EndPlace(int position, int opertion)
        {
            Option = eLongMenOption.Null;
            if (0 == position)
            {

            }
            else if (position >= 1 && position <= 12)
            {
                //Station Place

                switch (opertion)
                {
                    case 1:
                        //检测工位取件信号（PC-I3）
                        while (!Bit.Tst(Status, eLongMenState.StationPickUp)) Thread.Sleep(1000);
                        //输出取件完成信号（PC-O14）
                        Option = Bit.Set(Option, eLongMenOption.PickupEnd);
                        break;
                    case 2:              
                        //检测卡盘开爪信号（PC-I4）  
                        while (!Bit.Tst(Status, eLongMenState.StationClampOpen)) Thread.Sleep(1000);
                        //输出卡盘开爪完成信号（PC-O15）
                        Option = Bit.Set(Option, eLongMenOption.ClampOpen);

                        break;
                    case 3:
                        //检测卡盘可以闭爪 （PC-I5）
                        while (!Bit.Tst(Status, eLongMenState.StationClampClose)) Thread.Sleep(1000);
                        //输出盘闭爪完成（PC-O16）
                        Option = Bit.Set(Option, eLongMenOption.WaitStation);
                        break;
                    case 4:
                        //检测卡盘可以闭爪 （PC-I5）
                        while (!Bit.Tst(Status, eLongMenState.StationPlace)) Thread.Sleep(1000);
                        //输出盘闭爪完成（PC-O16）
                        Option = Bit.Set(Option, eLongMenOption.StationEndPlace);
                        break;
                }

            }
            return this;
        }

        
        public override void Reset(bool force = false)
        {
            throw new NotImplementedException();
        }
    }
}
