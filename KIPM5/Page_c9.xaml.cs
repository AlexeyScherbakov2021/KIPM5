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
   
    public partial class Page_c9 : Page
    {
        int Step;

        public Page_c9()
        {
            InitializeComponent();
            MainFrame.Main.SetSet(MainFrame.EnSet.ALL);

            MainFrame.Main.Header1.Text = "Раздел 3.";
            MainFrame.Main.Header2.Text = "Обучение. Подключение по Bluetooth.";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        //-------------------------------------------------------------------------------------------------------
        // событие загрузки страницы
        //-------------------------------------------------------------------------------------------------------
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        //-------------------------------------------------------------------------------------------------------
        // кнопка старт
        //-------------------------------------------------------------------------------------------------------
        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.Visibility = Visibility.Hidden;
            Step = 0;

            ExecuteStep();
        }

        //--------------------------------------------------------------------------------------------------
        // щелчок мыши на индикаторе
        //--------------------------------------------------------------------------------------------------
        private void Path_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ExecuteStep();
        }

        //--------------------------------------------------------------------------------------------------
        // кнопка Далее
        //--------------------------------------------------------------------------------------------------
        private void BtNext_Click(object sender, RoutedEventArgs e)
        {
            //btNext.Visibility = Visibility.Hidden;
            ExecuteStep();

        }

        private void CallbackAnimation()
        {
            ExecuteStep();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            ExecuteStep();
        }


        //--------------------------------------------------------------------------------------------------
        // выполенение шагов
        //--------------------------------------------------------------------------------------------------
        void ExecuteStep()
        {
            Run run;

            switch (Step)
            {
                case 0:
                    canvas.Opacity = 1;
                    gridLabel.Visibility = Visibility.Visible;
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 1. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Включитье на смартфоне Bluetooth. Подключите нужное имя устройства и запустите программу " +
                        "Kip монитор. Кликните на кнопку меню."));

                    pathMenu.Visibility = Visibility.Visible;
                    break;

                case 1:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 2. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Выберите устройство КИП М."));

                    pathMenu.Visibility = Visibility.Hidden;
                    imagePO.Source = new BitmapImage(new Uri("Resources/Android/andr01.jpg", UriKind.Relative));
                    pathKIP.Visibility = Visibility.Visible;
                    break;

                case 2:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 3. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Выберите нужное устройство."));

                    imagePO.Source = new BitmapImage(new Uri("Resources/Android/andr02.jpg", UriKind.Relative));
                    pathKIP.Visibility = Visibility.Hidden;
                    pathDev.Visibility = Visibility.Visible;
                    break;

                case 3:
                    pathDev.Visibility = Visibility.Hidden;
                    imagePO.Source = new BitmapImage(new Uri("Resources/Android/andr03.jpg", UriKind.Relative));

                    gridLabel.Visibility = Visibility.Hidden;
                    gridComplete.Visibility = Visibility.Visible;
                    break;

            }

            Step++;
        }

    }
}
