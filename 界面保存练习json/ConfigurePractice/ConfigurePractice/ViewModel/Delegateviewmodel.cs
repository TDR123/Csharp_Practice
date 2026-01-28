using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConfigurePractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConfigurePractice.ViewModel
{  
    //1.定义委托
    delegate (double firstValue, double secondValue) DelegateMethod(double firstValue, double secondValue);
    partial class Delegateviewmodel: ObservableObject
    {
        [ObservableProperty] double progressValue = 0;
        [ObservableProperty] DelegateModel dModel;
        [ObservableProperty] MainWindowViewModel _mainvm;
        public Func<double, double> func = (x) => x;
        public Delegateviewmodel(MainWindowViewModel mainvm)
        {
            //2.定义委托变量
            DelegateMethod method ;
            DModel = new DelegateModel();
            _mainvm = mainvm;
        }

        [RelayCommand]
        private void Delegatebutton()
        {
            DModel.FirstValue=_mainvm.FirstValue;
            DModel.SecondValue = _mainvm.SecondValue;
        }
    }
}
