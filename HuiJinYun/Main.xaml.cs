using HuiJinYun.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HuiJinYun
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        U3DPlayer _u3d;
        HuiJinYunProductionLine _line;
        TcpClient _client;

        public Main()
        {
            InitializeComponent();
        }
        protected void InitializeU3D()
        {
            _u3d = new U3DPlayer();
            _u3d.Src = @"resource\Demo.exe";
            _u3d.Dock = DockStyle.Fill;
            _u3d.OnReceiveMessage += _u3d_OnReceiveMessage;
            FormClosed += _u3d.Form1_FormClosed;
            this.Controls.Add(_u3d);
        }

    }
}
