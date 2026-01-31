using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurePractice.ViewModel
{
    partial class Sendviewmodel: ObservableObject
    {
        [ObservableProperty] string sendtext;
        public Sendviewmodel()
        {
            Sendtext = "ffss";
        }
        [RelayCommand]
        private void Clear()
        {
            Sendtext = "";
        }
    }
}
