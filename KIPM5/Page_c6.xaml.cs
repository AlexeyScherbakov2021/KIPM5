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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KIPM5
{

    public partial class Page_c6 : Page
    {
        int Step;

        public Page_c6()
        {
            InitializeComponent();

            MainFrame.Main.SetSet(MainFrame.EnSet.ALL);

            MainFrame.Main.Header1.Text = "Раздел 3.";
            MainFrame.Main.Header2.Text = "Обучение. Конфигурирование.";

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


        private void CbCOM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbCOM.SelectedIndex == 1)
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
                    tbStepText.Inlines.Add(new Run("Включите автоматический выключатель для подачи питания на КИП-М5."));

                    pathAvtomat.Visibility = Visibility.Visible;
                    break;

                case 1:
                    pathAvtomat.Visibility = Visibility.Hidden;
                    new clAnimation(imgAvtomat, @"/KIPM5;component/Resources/Автомат1 DIN/avtomat", 0, 5, 50, CallbackAnimation, 0, 0, enumFormatFile.JPG);
                    break;

                case 2:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 2. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Подключите кабель USB к компьютеру."));

                    PowerLED.Visibility = Visibility.Visible;
                    VULED.Visibility = Visibility.Visible;
                    PollLED.Visibility = Visibility.Visible;
                    pathUSB.Visibility = Visibility.Visible;
                    break;

                case 3:
                    pathUSB.Visibility = Visibility.Hidden;
                    BeginStoryboard((Storyboard)Resources["Storyboard1"]);
                    break;

                case 4:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 3. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Запустите на компьютере ПО «Конфигуратор НГК КИП-М»"));

                    pathComp.Visibility = Visibility.Visible;

                    break;

                case 5:
                    pathComp.Visibility = Visibility.Hidden;
                    BeginStoryboard((Storyboard)Resources["Storyboard2"]);

                    break;

                case 6:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 4. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Выберите порт COM4. (Обновить список, если кабель USB подключался после запуска программы)."));

                    cbCOM.IsEnabled = true;
                    pathCOMPort.Visibility = Visibility.Visible;

                    break;

                case 7:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 5. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Нажмите кнопку «Подключиться»."));

                    pathCOMPort.Visibility = Visibility.Hidden;
                    pathConnect.Visibility = Visibility.Visible;

                    break;

                case 8:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 6. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Нажмите кнопку «Настройки» для перехода в окно настроек."));

                    pathConnect.Visibility = Visibility.Hidden;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P02.png", UriKind.Relative)); ;
                    pathSettings.Visibility = Visibility.Visible;
                    break;

                case 9:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 7. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Установите опцию «Подключение по GSM(Modbus TCP)». При этом ниже появится " +
                        "закладка «GSM(Modbus TCP)»."));

                    pathSettings.Visibility = Visibility.Hidden;
                    pathGSMCheck.Visibility = Visibility.Visible;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P03.png", UriKind.Relative)); ;
                    break;

                case 10:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 8. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Перейдите в закладку «GSM(Modbus TCP)»."));

                    pathGSMCheck.Visibility = Visibility.Hidden;
                    pathGSMTab.Visibility = Visibility.Visible;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P04.png", UriKind.Relative)); ;

                    break;

                case 11:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 9. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Для записи основных параметров нажмите кнопку «Записать основные параметры»."));

                    pathGSMTab.Visibility = Visibility.Hidden;
                    pathSaveMain.Visibility = Visibility.Visible;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P05.png", UriKind.Relative)); ;
                    break;

                case 12:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 10. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("В консоли должны появиться две строки. Первая - команда, вторая эхо ответ от " +
                        "устройства. Если ответ не поступил, повторите запись. Далее надмите кнопку " +
                        "«Записать настройки соединения»."));

                    pathSaveMain.Visibility = Visibility.Hidden;
                    pathSaveConnection.Visibility = Visibility.Visible;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P06.png", UriKind.Relative)); ;
                    break;

                case 13:
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 11. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("В консоли должны появятся еще две строки, подтверждающие запись. Далее нажмите " +
                        "кнопку «Сохранить данные и перезагрузить устройство», чтобы КИП-М5 применил настройки."));

                    pathSaveConnection.Visibility = Visibility.Hidden;
                    pathReboot.Visibility = Visibility.Visible;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P07.png", UriKind.Relative)); ;
                    break;

                case 14:
                    pathReboot.Visibility = Visibility.Hidden;
                    imagePO.Source = new BitmapImage(new Uri("Resources/ПО/P08.png", UriKind.Relative)); ;
                    GPRSLED.Visibility = Visibility.Visible;
                    gridLabel.Visibility = Visibility.Hidden;
                    gridComplete.Visibility = Visibility.Visible;
                    break;

            }

            Step++;
        }

    }
}
