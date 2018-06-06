using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO.Pipes;

namespace HuiJinYun.WD
{
    public class U3DPlayerReceiveMessageEventArgs : EventArgs
    {
        public object Data { get; }

        public U3DPlayerReceiveMessageEventArgs(object data)
        {
            Data = data;
        }
    }

    public delegate void U3DPlayerReceiveMessageHandler(object sender, U3DPlayerReceiveMessageEventArgs args);
    public partial class U3DPlayer : UserControl
    {
        internal delegate bool WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);

        private TcpClient _client;
        private NamedPipeServerStream _namedPipeServer;
        public event U3DPlayerReceiveMessageHandler OnReceiveMessage;
        private bool isWhile = true;
        public string Src { get; set; }
        public U3DPlayer()
        {
            NamedPipeListenServer svr = new NamedPipeListenServer("HuiJinYunUnity");
            svr.Run();
            if (null == _namedPipeServer)
                _namedPipeServer = new NamedPipeServerStream("HuiJinYunUnity", PipeDirection.InOut);
            //InitializeComponent();
        }

        private void U3DPlayer_Load(object sender, EventArgs e)
        {
            try
            {
              process = new Process();
                //process.StartInfo.FileName = Application.StartupPath + @"\UnityApp\Child.exe";
                process.StartInfo.FileName = Src;
                process.StartInfo.Arguments = "-parentHWND " + Handle.ToInt32() + " " + Environment.CommandLine;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                process.WaitForInputIdle();
                // Doesn't work for some reason ?!
                //unityHWND = process.MainWindowHandle;
                EnumChildWindows(Handle, (hwnd, lparam) =>
                {
                    unityHWND = hwnd;
                    return true;
                }, IntPtr.Zero);

                if (null == _client)
                    _client = new TcpClient();
                _client.Connect("127.0.0.1", 8060);
                new Thread(ReceiveThread).Start();
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
        }

        protected async void ReceiveThread()
        {
            var buffer = new byte[1024];
            while (!_client.Connected) Thread.Sleep(1000);
            var stream = _client.GetStream();
            while (isWhile)
            {
                if (!_client.Connected)
                {
                    if (null != OnReceiveMessage)
                    {
                        int length = stream.Read(buffer, 0, buffer.Length);
                        //string data = Encoding.ASCII.GetString(buffer, 0, length);
                        string data = Encoding.Unicode.GetString(buffer, 0, length);
                        OnReceiveMessage(this, new U3DPlayerReceiveMessageEventArgs(JsonConvert.DeserializeObject(data)));
                    }
                }
                else {

                }
            }
        }

        public void SendMessage(object data) => SendMessage(JsonConvert.SerializeObject(data));
      
        public void SendMessage(string data)
        {
            try
            {
                if (null != _client)
                {
                    while (!_client.Connected)
                    {
                        if (null == _client)
                            _client = new TcpClient();
                        _client.Connect("127.0.0.1", 8060);
                        new Thread(ReceiveThread).Start();
                    }
                    var stream = _client.GetStream();

                    //byte[] d = Encoding.ASCII.GetBytes(data);
                    byte[] d = Encoding.Unicode.GetBytes(data);
                    stream.Write(d, 0, d.Length);
                }
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;

            }
        }

        private void U3DPlayer_Resize(object sender, EventArgs e)
        {
            MoveWindow(unityHWND, 0, 0, Width, Height, true);
            //ActivateWindow();
        }

        internal void ActivateWindow()
        {
            int result = SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
        }

        internal void DeactivateWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
        }



        // Close Unity application
        internal void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                process.CloseMainWindow();
                isWhile = false;
                Thread.Sleep(1000);
                while (process.HasExited == false)
                    process.Kill();
            }
            catch (Exception)
            {

            }
        }

        internal void Form1_Activated()
        {
            ActivateWindow();
        }

        internal void Form1_Deactivate()
        {
            DeactivateWindow();
        }
    }
}
