using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConfigurePractice.Model;
using ConfigurePractice.View;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ObservableProperty]  Brush background;
        
        //时间
        [ObservableProperty] string currentTime = DateTime.Now.ToString("HH:mm:ss");
        private CancellationTokenSource? cts { get; set; }  
        public MainWindowViewModel()
        {
            mainWindowModel = new MainWindowModel();
            MainWindowModel.IpAddress = "192.168.0.1";
            Content= new UserControl();
            Background = Brushes.White;
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
            // 模拟异步连接操作
             Flag= true;
            await Task.Delay(3000);
            IsConnected= !IsConnected;
            Flag = false;
        }

        //
        [RelayCommand]
        private void showPage1()
        {
            cts = new CancellationTokenSource();
            Page1ViewModel p1vm = new Page1ViewModel();
            Content = new page1(p1vm);
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


    }
}
