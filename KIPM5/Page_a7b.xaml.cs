﻿using System;
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
    
    public partial class Page_a7b : Page
    {

        public List<ItemPlayer> listItemPlayer = new List<ItemPlayer>()
        {
            new ItemPlayer() { Name = "1. DIN-рейка", Sound = "" },
            new ItemPlayer() { Name = "2. Клеммы для подключения питающей сети ~230 В", Sound = "" },
            new ItemPlayer() { Name = "3. Вводной автоматический выключатель питающей сети", Sound = "" },
            new ItemPlayer() { Name = "4. Клемма заземления"},
            new ItemPlayer() { Name = "5. НГК-КИП-М-256.4"},
            new ItemPlayer() { Name = "6. НГК-УЗИП КИП-М" },
            new ItemPlayer() { Name = "7. Клеммы параметры СКЗ" },
            new ItemPlayer() { Name = "8. Клеммы контроль потенциала" },
            new ItemPlayer() { Name = "9. Клеммы контроля вскрытия" },
            new ItemPlayer() { Name = "10. ИБП СКАТ-1200Б" },
        };


        public Page_a7b()
        {
            InitializeComponent();
            MainFrame.Main.SetSet(MainFrame.EnSet.ALL);

            MainFrame.Main.Header1.Text = "Раздел 2.";
            MainFrame.Main.Header2.Text = "Подключение кабелей НГК-КИПМ-5.2";

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
