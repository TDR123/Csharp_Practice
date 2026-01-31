using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurePractice.ViewModel
{
    partial class Logpageviewmodel : ObservableObject
    {
        [ObservableProperty] string logtext = "1321041";

        public ObservableCollection<Student> Loglines { get; set; }
        public Logpageviewmodel()
        {
            Loglines = new ObservableCollection<Student>
        {
                new Student { Id = 1, Name = "张三", Age = 18, Grade = "一年级" },
            new Student { Id = 2, Name = "李四", Age = 19, Grade = "二年级" },
            new Student { Id = 3, Name = "王五", Age = 20, Grade = "三年级" }
        }
            ;
            //Logtext = "log";
        }



    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
    }
}
