using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KIPM5
{
    /// <summary>
    /// Логика взаимодействия для Page_c3.xaml
    /// </summary>
    public partial class Page_c3 : Page
    {
        public Page_c3()
        {
            InitializeComponent();
            MainFrame.Main.SetSet(MainFrame.EnSet.ALL);

            MainFrame.Main.Header1.Text = "Раздел 3.";
            MainFrame.Main.Header2.Text = "Консервация и хранение";
        }
    }
}
