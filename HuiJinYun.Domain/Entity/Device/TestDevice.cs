using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Entity.PLC;
using HuiJinYun.Domain.Log;
using System.Threading;

namespace HuiJinYun.Domain.Entity.Device
{
    public class TestDevice : PlcDeviceBase
    {
        public TestDevice(IPort port, ISerialize serialize) :
            base(port, serialize)
        {

        }

        public void Write(eElementCode type,uint number,ushort data)
        {
            byte[] result;
            WriteRandomCommand cmd = new WriteRandomCommand(type, number, data);
            //while (true)
           // {
               // WriteRandomCommand cmd = new WriteRandomCommand(eElementCode.D, 0, 100);      //byzyj

                _port.Write(_serialize.Serialize<WriteRandomCommand>(cmd))
                    .Read(out result);
                if (null != result)
                {
                    var res = _serialize.Deserialize<WriteRandomResult>(result);
                    if (res.Code == ePlcResultCode.OK)
                    {
                        Logger.LogInfo(res.ToString());
                    }
                }

               // break;

                //Thread.Sleep(800);
                //WriteRandomCommand cmd1 = new WriteRandomCommand(eElementCode.D, 00, 0x0000);      //byzyj

                //_port.Write(_serialize.Serialize<WriteRandomCommand>(cmd1))
                //    .Read(out result);
                //if (null != result)
                //{
                //    var res = _serialize.Deserialize<WriteRandomResult>(result);
                //    if (res.Code == ePlcResultCode.OK)
                //    {
                //        Logger.LogInfo(res.ToString());
                //    }
                //}


            //}
        }

        public ushort Read(eElementCode type, uint number)
        {
            byte[] result;
            var cmd = new ReadRandomCommand(type, number);
                _port.Write(_serialize.Serialize<ReadRandomCommand>(cmd))
                    .Read(out result);
            if (null != result)
            {
                var res = _serialize.Deserialize<ReadRandomResult>(result);
                if (res.Code == ePlcResultCode.OK)
                {
                    Logger.LogInfo(res.WordData.ToString());
                    return res.WordData;
                }
                else {
                    return 0;
                }
            }
            else
            { return 0;
            }
        }

        public override void Reset(bool force = false)
        {
            throw new NotImplementedException();
        }
    }
}
