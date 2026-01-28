using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
namespace ConfigurePractice.Model
{
    partial class DelegateModel:ObservableObject
    {
        [ObservableProperty] double firstValue;
        [ObservableProperty] double secondValue;
      
        public DelegateModel()
        {
            FirstValue = 1;
            SecondValue = 2;
        }
        partial void OnFirstValueChanged(double value)
        {
            (FirstValue, SecondValue) = DelegateMethod(value, SecondValue);
        }
        public (double firstValue, double secondValue) DelegateMethod(double firstValue, double secondValue)
        {
            return (firstValue, secondValue);
        }
    }
}
