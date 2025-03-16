using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SerialPort.ViewModel
{
    internal partial class datacontext : ObservableObject
    {

        // 使用ObservableProperty特性声明可观察属性
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private int _age;

    }
}
