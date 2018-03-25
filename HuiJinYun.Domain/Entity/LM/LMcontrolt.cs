using Automation.BDaq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity.LM
{
    public class LMcontrolt
    {
        static DeviceInformation _device = new DeviceInformation("PCI-1756,BID#0");
        static InstantDiCtrl instantDiCtrl = new InstantDiCtrl();
        static InstantDoCtrl instantDoCtrl = new InstantDoCtrl();

        public LMcontrolt()
        {
            //instantDiCtrl.Interrupt += new EventHandler<DiSnapEventArgs>(instantDiCtrl_Interrupt);
            instantDiCtrl.SelectedDevice = _device;
            instantDoCtrl.SelectedDevice = _device;
        }
        public static ErrorCode DiRead(int port, out byte data)
        {
            instantDiCtrl.SelectedDevice = _device;
            instantDoCtrl.SelectedDevice = _device;
            data = 0;
            byte[] datas = new byte[] { 0 };
            return instantDiCtrl.Read(0, 1, datas);
        }

        public static ErrorCode DiReadBit(int portStart, int portCount, byte[] data)
        {
            return instantDiCtrl.Read(portStart, portCount, data);
        }

        public static ErrorCode DiSnapStart()
        {
            return instantDiCtrl.SnapStart();
        }
        public static ErrorCode DiSnapStop()
        {
            return instantDiCtrl.SnapStop();
        }
        public static ErrorCode DoWrite(int port, byte data)
        {
            return instantDoCtrl.Write(port, data);
        }

        public static ErrorCode DoWriteBit(int port, int bit, byte data)

        {
            return instantDoCtrl.WriteBit(port, bit, data);
        }

        public static ErrorCode DoRead(int port, out byte data)
        {
            return instantDoCtrl.Read(port, out data);
        }

        public static ErrorCode DoReadBit(int portStart, int portCount, byte[] data)
        {
            return instantDoCtrl.Read(portStart, portCount, data);
        }



        public void test()
        {

            if (!instantDiCtrl.Features.DiintSupported)
            {
                Console.WriteLine("The device can not support DI interrupt function.");
                return;
            }



            int portStart = 0;
            int portCount = 2;
            byte[] data = new byte[2];
            instantDiCtrl.Read(portStart, portCount, data);


            // 2. Using DiintChannels to get all the channels which support DI Interrupt.
            DiintChannel[] interruptChans = instantDiCtrl.DiintChannels;

            // 3. Choose one channel from those channels and enable the channel for running DI Interrupt.
            interruptChans[0].Enabled = true;

            // 4. Start the function.
            instantDiCtrl.SnapStart();
            instantDiCtrl.SnapStop();
        }
        static void instantDiCtrl_Interrupt(object sender, DiSnapEventArgs e)
        {
            Console.WriteLine(" DI channel {0} interrupt occurred!", e.SrcNum);
        }
    }
}