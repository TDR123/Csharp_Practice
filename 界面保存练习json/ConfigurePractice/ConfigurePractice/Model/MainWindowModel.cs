using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ConfigurePractice.Model
{
   public partial class MainWindowModel:ObservableObject
    {
        [ObservableProperty] string ipAddress ="192.168.1.100";
    }
}
