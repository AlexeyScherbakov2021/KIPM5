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
    
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainFrame.Main.SetSet(MainFrame.EnSet.START);


            MainFrame.Main.rowHeader.Height = new GridLength(0);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Main.rowHeader.Height = new GridLength(83);
        }
    }
}
