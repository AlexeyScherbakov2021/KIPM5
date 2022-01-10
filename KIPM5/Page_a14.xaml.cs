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

    public partial class Page_a14 : Page
    {
        public List<ItemPlayer> listItemPlayer = new List<ItemPlayer>()
        {
            new ItemPlayer() { Name = "«Pwr» Светится постоянно на включенном устройстве", Sound = "" },
            new ItemPlayer() { Name = "«Опрос» Светится во время опроса каналов АЦП и подключенной переферии", Sound = "" },
            new ItemPlayer() { Name = "«GPRS» Светится при регистрации в сети GSM и наличии связи GPRS" },
            new ItemPlayer() { Name = "«ВУ» Светится во время передачи данных в систему верхнего уровня" },
        };

        BlinkElement blinkPwr;
        BlinkElement blinkPoll;
        BlinkElement blinkGPRS;
        BlinkElement blinkExtCtrl;

        public Page_a14()
        {
            InitializeComponent();

            MainFrame.Main.SetSet(MainFrame.EnSet.ALL);

            MainFrame.Main.Header1.Text = "Раздел 1.";
            MainFrame.Main.Header2.Text = "Светодиодная индикация";

            blinkPwr = new BlinkElement(path0);
            blinkPoll = new BlinkElement(path1);
            blinkGPRS = new BlinkElement(path2);
            blinkExtCtrl = new BlinkElement(path3);

            blinkPwr.SetStatus(true, false, new int[]      { 600, 150, 150, 150, 150, 150, 150, 150, 150, 150, 150 });
            blinkPoll.SetStatus(false, false, new int[]    { 600, 150, 150, 150, 150, 150, 150, 150, 150, 150, 150,
                50, 800,  50, 50,  50, 800,  50, 50, 50, 50});
            blinkGPRS.SetStatus(true, false, new int[]    { 600, 150, 150, 150, 150, 150, 150, 150, 150, 150, 3500,
                });
            blinkExtCtrl.SetStatus(false, false, new int[] { 600, 150, 150, 150, 150, 150, 150, 150, 150, 150, 1500,
                50,50, 50,50, 50,1000,  500 });


            lbItems.ItemsSource = listItemPlayer;
            lbItems.DisplayMemberPath = "Name";

            for (int i = 0; i < listItemPlayer.Count; i++)
                listItemPlayer[i].flash = grid.Children.OfType<Path>().FirstOrDefault(ps => ps.Name.Equals("path" + i));

        }

        //-------------------------------------------------------------------------------------------------------
        // событие загрузеи страницы
        //-------------------------------------------------------------------------------------------------------
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lbItems.SelectedIndex = -1;
            //AutoPlay = true;
            //Page_Frame.player.Open(new Uri(@"pack://siteoforigin:,,,/Sound/SectionA/a1_5_2.mp3", UriKind.Absolute));
            //Page_Frame.player.Play();

        }

        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        private void LbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbItems.SelectedIndex < 0)
                return;

            //if (Page_Frame.player.Position < Page_Frame.player.NaturalDuration)
            //    AutoPlay = false;

            //Page_Frame.player.Stop();


            ItemPlayer p = lbItems.SelectedItem as ItemPlayer;

            foreach (ItemPlayer ip in listItemPlayer)
                ip.flash.Visibility = Visibility.Hidden;

            p.flash.Visibility = Visibility.Visible;

            //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/" + p.Sound, UriKind.Absolute));
            //Page_Frame.player.Play();

        }

        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //Page_Frame.player.MediaEnded -= Player_MediaEnded;
            //Page_Frame.mainPage.btReplay.Click -= BtReplay_Click;

        }

        private void Path0_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Path selPath = sender as Path;

            for (int i = 0; i < listItemPlayer.Count; i++)
            {
                if (listItemPlayer[i].flash == selPath)
                {
                    lbItems.SelectedIndex = i;
                    break;
                }
            }
        }

    }
}
