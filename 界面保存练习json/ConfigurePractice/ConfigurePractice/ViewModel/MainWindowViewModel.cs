using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConfigurePractice.Model;
using ConfigurePractice.View;
using ConfigurePractice.View.log1;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
namespace ConfigurePractice.ViewModel
{
   
   public partial class MainWindowViewModel:ObservableObject
    {
        [ObservableProperty] MainWindowModel mainWindowModel;
        //[ObservableProperty] string ip="192.168.1.111";
        [ObservableProperty] bool isConnected = false;
        [ObservableProperty] bool flag = false;
        [ObservableProperty] bool theme = false;
        [ObservableProperty] UserControl content;
        [ObservableProperty] bool contentvisibility;
        [ObservableProperty]  Brush background;
        private TcpClient client;
        [ObservableProperty] UserControl content1;
        [ObservableProperty] UserControl content2;
        [ObservableProperty] UserControl content3;
        //时间
        [ObservableProperty] string currentTime = DateTime.Now.ToString("HH:mm:ss");
        private CancellationTokenSource? cts { get; set; }
        [ObservableProperty] double firstValue=-1;
        [ObservableProperty] double secondValue=-2;
        public MainWindowViewModel()
        {
            mainWindowModel = new MainWindowModel();
            MainWindowModel.IpAddress = "192.168.0.1";
            Content= new UserControl();
            Content1 = new Sendmodel();
            Content2 = new Logpageview();
            Content3 = new UserControl1();
            Background = Brushes.White;
            Contentvisibility= false;
            client= new TcpClient();
            //
            // 每秒刷新一次
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (_, __) => CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        //连接按钮命令
        [RelayCommand]
        private async Task ipConnection()
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2)); // 5秒超时
            try
            {
                // 模拟异步连接操作
                // 连接服务器
                Flag = true;
                if (client.Connected)
                {
                    // 1. 先关闭网络流（发送FIN包通知服务器）
                    var stream = client.GetStream();
                    stream?.Close();

                    // 2. 关闭TcpClient（释放端口）
                    client.Close();
                    IsConnected = false;
                    Flag = false;
                }
                else
                {
                    client = new TcpClient();
                    await client.ConnectAsync(MainWindowModel.IpAddress, MainWindowModel.Port, cts.Token);
                    IsConnected = true;
                    Flag = false;
                }


                 
            }catch(Exception ex)
            {
                IsConnected = false;
                Flag = false;
                MessageBox.Show(ex.Message);
            }
           
        }

        //
        [RelayCommand]
        private void showPage1()
        {
            cts = new CancellationTokenSource();
            Page1ViewModel p1vm = new Page1ViewModel();
            Content = new page1(p1vm);
            Contentvisibility = true;
            Task.Run(async () =>
            {
                for (int i = 0; i < 101; i++)
                {
                   //cts.Token.ThrowIfCancellationRequested();          // ① 检查取消信号
                    if (cts.IsCancellationRequested)
                    {

                        Dispatcher.CurrentDispatcher.Invoke(() => p1vm.ProgressValue = 0);                      
                        return;
                    }
                    Dispatcher.CurrentDispatcher.Invoke(() => p1vm.ProgressValue = i);
                    await Task.Delay(100);
                }
            },cts.Token);
           
       
        }

        [RelayCommand]
        private void cancelbutton()
        {
            Contentvisibility = false;
            if (cts != null)
            {
                cts.Cancel();
                return;
            }

            return ;
        }
        //主题切换
        [RelayCommand]
        private void ThemeChange()
        {
            if (Theme)
            {
                Background = new BrushConverter().ConvertFrom("#e0171717") as Brush
                  ?? throw new InvalidOperationException("无法转换颜色");
                // Background = Brushes.DarkGray;
            }
            else
            {
                Background = Brushes.White;
            }
        }

        //主题切换
        [RelayCommand]
        private void Delegatebutton()
        {
            Delegatepage d1 = new Delegatepage(this);
          
            
            d1.Show();
          
        }
        public (double firstValue, double secondValue) DelegateMethodvm(double firstValue, double secondValue)
        {
            return (firstValue, secondValue);
        }
        //private double m1(double x)
        //{
        //    return x;
        //}
    }
}
