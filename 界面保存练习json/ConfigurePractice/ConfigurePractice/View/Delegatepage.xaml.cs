using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ConfigurePractice.ViewModel;


namespace ConfigurePractice.View
{
    /// <summary>
    /// Delegatepage.xaml 的交互逻辑
    /// </summary>
    public partial class Delegatepage : Window
    {
        public Delegatepage(MainWindowViewModel mainvm)
        {
            InitializeComponent();
            this.DataContext=new Delegateviewmodel( mainvm);
        }
    }
}
