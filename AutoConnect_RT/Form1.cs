using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace AutoConnect_RT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Load += Form1_Load;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_RESTORE = 9;
        public string PortName = "";
        private async Task AlexDev()
        {
            List<GClass1> list = GClass1.alexdev_0();
            string text = "";
            foreach (GClass1 gclass in list)
            {
                string string_ = gclass.String_1;
                bool flag = string_.IndexOf("FTDIBUS\\VID_0403+PID_6001+B5") > -1;
                if (flag)
                {
                    this.PortName = gclass.String_0;
                    text = (Conversion.Val(Class118.alexdev_0(string_.Substring(30, 3))) * 2.0).ToString();
                    Application.DoEvents();
                    break;
                }
                bool flag2 = string_.IndexOf("USB\\VID_0403+PID_6001+B5") > -1;
                if (flag2)
                {
                    this.PortName = gclass.String_0;
                    text = (Conversion.Val(Class118.alexdev_0(string_.Substring(30, 3))) * 2.0).ToString();
                    break;
                }
                bool flag3 = string_.IndexOf("FTDIBUS\\VID_0403+PID_6001+A5") > -1;
                if (flag3)
                {
                    this.PortName = gclass.String_0;
                    text = (Conversion.Val(Class118.alexdev_0(string_.Substring(30, 3))) * 2.0).ToString();
                    break;
                }
                bool flag4 = string_.IndexOf("USB\\VID_0403+PID_6001+A5") > -1;
                if (flag4)
                {
                    this.PortName = gclass.String_0;
                    text = (Conversion.Val(Class118.alexdev_0(string_.Substring(30, 3))) * 2.0).ToString();
                    break;
                }
                bool flag5 = string_.IndexOf("USB\\VID_0403+PID_6001") > -1;
                if (flag5)
                {
                    this.PortName = gclass.String_0;
                    text = (Conversion.Val(Class118.alexdev_0(string_.Substring(30, 3))) * 2.0).ToString();
                    break;
                }
                bool flag6 = string_.IndexOf("FTDIBUS\\VID_0403+PID_6001") > -1;
                if (flag6)
                {
                    this.PortName = gclass.String_0;
                    text = (Conversion.Val(Class118.alexdev_0(string_.Substring(30, 3))) * 2.0).ToString();
                    break;
                }
            }
            bool flag7 = text.Length > 1;
            if (flag7)
            {
                await Task.Delay(1000);
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await this.AlexDev();
            byte[] array = new byte[] { 254, 4, 114, 140 };
            byte[] array2 = new byte[] { 114, 5, 0, 240, 153 };

            try
            {
                SerialPort1.PortName = PortName;
                if (!SerialPort1.IsOpen)
                    SerialPort1.Open();
                
                SerialPort1.BaudRate = 10400;
                SerialPort1.BreakState = false;

                Thread.Sleep(100);
                SerialPort1.BreakState = true;
                Thread.Sleep(70);
                SerialPort1.BreakState = false;
                Thread.Sleep(5);
                Thread.Sleep(145);

                SerialPort1.Write(array, 0, array.Length);
                Thread.Sleep(30);

                SerialPort1.Write(array2, 0, array2.Length);
                Thread.Sleep(30);

                SerialPort1.DiscardOutBuffer();
                SerialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serial Error: " + ex.Message);
            }

            Thread.Sleep(100);

            FocusTunerProAndCtrlF4();
        }

        private void FocusTunerProAndCtrlF4()
        {
            Process[] ps = Process.GetProcessesByName("TunerPro");
            if (ps.Length == 0)
            {
                MessageBox.Show("ไม่พบ TunerPro.exe");
                return;
            }

            Process tuner = ps[0];

            // รอ window handle พร้อมจริง ๆ
            for (int i = 0; i < 20 && tuner.MainWindowHandle == IntPtr.Zero; i++)
            {
                Thread.Sleep(100);
                tuner.Refresh();
            }

            IntPtr hwnd = tuner.MainWindowHandle;
            if (hwnd == IntPtr.Zero)
            {
                MessageBox.Show("ดึงหน้าต่าง TunerPro ไม่ได้");
                return;
            }

            // Restore + Foreground (ต้องมีจังหวะ)
            ShowWindow(hwnd, SW_RESTORE);
            Thread.Sleep(200);
            SetForegroundWindow(hwnd);
            Thread.Sleep(400);   // 🔥 สำคัญมาก

            // เคลียร์โฟกัส control ภายใน
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(100);

            // Ctrl + F4
            SendKeys.SendWait("^({F4})");
            Environment.Exit(0);
        }

    }

}
