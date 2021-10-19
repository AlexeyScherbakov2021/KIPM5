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
    
    public partial class StartPage : Page
    {
        //string pn = "Page_reg";

        public StartPage()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);

            // ========= убрать для защиты ===========================================================
            nav.Navigate(new Uri("MainFrame.xaml", UriKind.RelativeOrAbsolute));

            // ========= добавить для защиты =========================================================
            //string s = pn + ".xaml";
            //nav.Navigate(new Uri(s, UriKind.RelativeOrAbsolute));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string s = Page_reg.GetInf();
            //    if (s != null)
            //        pn = s;
            //}
            //catch
            //{

            //}
        }

    }
}
