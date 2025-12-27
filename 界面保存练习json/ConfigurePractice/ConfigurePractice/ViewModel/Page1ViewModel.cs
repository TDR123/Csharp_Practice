using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ConfigurePractice.ViewModel
{
    public partial class Page1ViewModel:ObservableObject
    {
        [ObservableProperty] double progressValue = 0;
        public Page1ViewModel()
        {

        }

    }
}
