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
    
    public partial class Page_a5 : Page
    {
        //public string ImageName;
        //bool AutoPlay;

        public List<ItemPlayer> listItemPlayer = new List<ItemPlayer>()
        {
            new ItemPlayer() { Name = "Разъем USB для подключения ПК", Sound = "" },
            new ItemPlayer() { Name = "Слот установки SD карты", Sound = "" },
            new ItemPlayer() { Name = "Индикатор работы", Sound = "" },
            new ItemPlayer() { Name = "Разъем подключения к сети Ethernet"},
            new ItemPlayer() { Name = "Разъем подключения GSM антенны" },
            new ItemPlayer() { Name = "Слот для SIM карты" },
        };



        public Page_a5()
        {
            InitializeComponent();
            MainFrame.Main.SetSet(MainFrame.EnSet.ALL);

            MainFrame.Main.Header1.Text = "Раздел 1.";
            MainFrame.Main.Header2.Text = "Общий вид";

            lbItems.ItemsSource = listItemPlayer;
            lbItems.DisplayMemberPath = "Name";

            for (int i = 0; i < listItemPlayer.Count; i++)
                listItemPlayer[i].flash = grid.Children.OfType<Path>().FirstOrDefault(ps => ps.Name.Equals("path" + i));

            // подписка на кнопку Повторить
            MainFrame.Main.btReplay.Click += BtReplay_Click;


        }

        //-------------------------------------------------------------------------------------------------------
        // кнопка Повторить
        //-------------------------------------------------------------------------------------------------------
        private void BtReplay_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
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

        //-------------------------------------------------------------------------------------------------------
        // событие окончания проигрывания звука
        //-------------------------------------------------------------------------------------------------------
        //private void Player_MediaEnded(object sender, EventArgs e)
        //{
        //    if (AutoPlay)
        //    {
        //        lbItems.Focus();
        //        lbItems.SelectedIndex++;

        //        if (lbItems.SelectedIndex >= lbItems.Items.Count - 1)
        //        {
        //            AutoPlay = false;
        //        }
        //    }
        //}

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
                ip.flash.Stroke.Opacity = 0;

            p.flash.Stroke.Opacity = 1;

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

            for (int i = 0; i <  listItemPlayer.Count; i++)
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
