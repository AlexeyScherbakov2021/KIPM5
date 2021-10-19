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

    partial class MainFrame : Page
    {
        public enum EnSet { START, ALL, BASIS, SOUND, REPLAY, HELP };

        public static MainFrame Main;
        static public NavigationService nav;
        static public MediaPlayer player;

        public MainFrame()
        {
            InitializeComponent();
            Main = this;
            ShowsNavigationUI = false;
            player = new MediaPlayer();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
//            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            nav = NavigationService.GetNavigationService(frame.Content as MainPage);
        }

        //---------------------------------------------------------------------------------------------------------
        // Событие загрузки главного Фрейма
        //---------------------------------------------------------------------------------------------------------
        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {

            //MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            player = new MediaPlayer();
            nav.RemoveBackEntry();

        }

        //---------------------------------------------------------------------------------------------------------
        // событие навигации
        //---------------------------------------------------------------------------------------------------------
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (nav != null)
            {
                btBack.Visibility = nav.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
                btHome.Visibility = btBack.Visibility;
            }
        }


        //-------------------------------------------------------------------------------------------------------
        // кнопка отключения звука
        //-------------------------------------------------------------------------------------------------------
        private void BtSound_Click(object sender, RoutedEventArgs e)
        {

            if (btSound.IsChecked == true)
                player.Volume = 0;
            else
                player.Volume = 1;
        }

        //---------------------------------------------------------------------------------------------------------
        // кнопка Назад
        //---------------------------------------------------------------------------------------------------------
        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            if (nav != null && nav.CanGoBack)
            {
                player.Stop();
                nav.GoBack();
            }

        }

        //---------------------------------------------------------------------------------------------------------
        // кнопка Выход из программы
        //---------------------------------------------------------------------------------------------------------
        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();

            //(Application.Current.MainWindow as KMOWindow).Close();
        }

        //---------------------------------------------------------------------------------------------------------
        // кнопка Домой на первую страницу
        //---------------------------------------------------------------------------------------------------------
        private void BtHome_Click(object sender, RoutedEventArgs e)
        {
            nav.Navigate(new Uri("MainPage.xaml", UriKind.RelativeOrAbsolute));

            while (nav.CanGoBack)
                nav.RemoveBackEntry();

            player.Stop();
        }

        public void BtReplay_Click(object sender, RoutedEventArgs e)
        {
            frame.Refresh();
        }

        private void BtHelp_Click(object sender, RoutedEventArgs e)
        {
            nav.Navigate(new Uri("Page_help.xaml", UriKind.RelativeOrAbsolute));
        }

        //-------------------------------------------------------------------------
        // установка видимиости кнопок внизу
        //-------------------------------------------------------------------------
        public void SetSet(EnSet s)
        {
            btBack.Visibility = Visibility.Visible;
            btHome.Visibility = Visibility.Visible;
            btExit.Visibility = Visibility.Visible;
            btHelp.Visibility = Visibility.Visible;
            btSound.Visibility = Visibility.Collapsed;
            btReplay.Visibility = Visibility.Collapsed;

            switch (s)
            {
                case EnSet.ALL:
                    btReplay.Visibility = Visibility.Visible;
                    btSound.Visibility = Visibility.Visible;
                    break;

                case EnSet.BASIS:
                    btSound.Visibility = Visibility.Collapsed;
                    btReplay.Visibility = Visibility.Collapsed;
                    break;

                case EnSet.REPLAY:
                    btReplay.Visibility = Visibility.Visible;
                    break;

                case EnSet.SOUND:
                    btSound.Visibility = Visibility.Visible;
                    break;

                case EnSet.START:
                    btBack.Visibility = Visibility.Collapsed;
                    btHome.Visibility = Visibility.Collapsed;
                    btSound.Visibility = Visibility.Collapsed;
                    btReplay.Visibility = Visibility.Collapsed;
                    break;

                case EnSet.HELP:
                    btHelp.Visibility = Visibility.Collapsed;
                    btHome.Visibility = Visibility.Collapsed;
                    btExit.Visibility = Visibility.Collapsed;
                    break;
            }

        }

    }
}
