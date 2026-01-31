using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ConfigurePractice.Model
{
    partial class Logpage:ObservableObject
    {
        [ObservableProperty] string logtext;
    }
}
