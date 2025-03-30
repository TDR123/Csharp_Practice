using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace serialport.ViewModel
{
    public partial class Datacontext : ObservableObject
    {

        public static SerialPort SerialPort = null;

        // 使用ObservableProperty特性声明可观察属性
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private int _age;

        [ObservableProperty]
        private string _byt = "7";
        [ObservableProperty]
        private string comName = "COM3";
        [ObservableProperty]
        private int baud = 9600;

       

        //public void OpenClosePort()
        //{
        //    //串口未打开
        //    if (SerialPort == null || !SerialPort.IsOpen)
        //    {
        //        SerialPort = new SerialPort();
        //        //串口名称
        //        SerialPort.PortName = comName;
        //        //波特率
        //        SerialPort.BaudRate = baud;
        //        //数据位
        //        SerialPort.DataBits = 8;
        //        //停止位
        //        SerialPort.StopBits = StopBits.One;
        //        //校验位
        //        SerialPort.Parity = Parity.None;
        //        //打开串口
        //        SerialPort.Open();
        //        //串口数据接收事件实现
        //        SerialPort.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);

        //        return SerialPort;
        //    }
        //    //串口已经打开
        //    else
        //    {
        //        SerialPort.Close();
        //        return SerialPort;
        //    }
        //}

    }
}
