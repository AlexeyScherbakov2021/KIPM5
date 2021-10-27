using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace KIPM5
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class ItemPlayer
    {
        public string Name { get; set; }
        public string Sound;
        public Path flash;
        public Path flash2;
        public string ImageName;
        public string NavigateUri;
        public int Child { get; set; }
        public TextBlock textBlock;
        public override string ToString() { return Name; }
    }

}
