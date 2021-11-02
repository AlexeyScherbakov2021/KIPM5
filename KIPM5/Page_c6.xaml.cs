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


        //--------------------------------------------------------------------------------------------------
        // выполенение шагов
        //--------------------------------------------------------------------------------------------------
        void ExecuteStep()
        {
            Run run;

            switch (Step)
            {
                case 0:
                    // 
                    gridLabel.Visibility = Visibility.Visible;
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 1. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Установите все автоматические выключатели сети в положение "));
                    run = new Run("ОТКЛ.");
                    tbStepText.Inlines.Add(run);

                    //path0.Visibility = Visibility.Visible;
                    //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/a2_6_1.mp3"));
                    //Page_Frame.player.Play();
                    break;

                case 1:
                    // переход к DIN-рейке
                    //path0.Visibility = Visibility.Hidden;
                    //BeginStoryboard((Storyboard)Resources["Storyboard1"]);
                    break;

                case 2:
                    //path5.Visibility = Visibility.Visible;
                    //btNext.Visibility = Visibility.Visible;
                    break;

                case 3:
                    // выключение всех автоматов
                    gridLabel.Visibility = Visibility.Hidden;
                    //path5.Visibility = Visibility.Hidden;
                    //new clanimation(imgavto1, "автомат1 din/img", 6, 6, 50, executestep, 0, 0, enumformatfile.jpg, true);
                    break;

                case 4:
                    //new clAnimation(imageDIN, "Автомат DIN/Avtom", 21, 21, 50, ExecuteStep, 0, 0, enumFormatFile.JPG, true);
                    break;

                case 5:
                    btNext.Visibility = Visibility.Visible;
                    break;

                case 6:
                    // передвижение к модулям БП
                    //BeginStoryboard((Storyboard)Resources["Storyboard9"]);
                    btNext.Visibility = Visibility.Hidden;
                    gridLabel.Visibility = Visibility.Visible;
                    tbStepText.Inlines.Clear();
                    tbStepText.Inlines.Add(new Run("Допускается кратковременное остаточное свечение индикаторов "));
                    run = new Run("АВАРИЯ ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("на модулях НГК-БП-Евро."));
                    //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/a2_6_2.mp3"));
                    //Page_Frame.player.Play();
                    break;

                case 7:
                    btNext.Visibility = Visibility.Visible;
                    break;

                case 8:
                    btNext.Visibility = Visibility.Hidden;
                    //BeginStoryboard((Storyboard)Resources["Storyboard7"]);
                    break;

                case 9:
                    //path14.Visibility = Visibility.Visible;
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 2. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Переведите переключатель "));
                    run = new Run("АКБ БУ, ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("расположенный на передней панели мокдля управления, в положение "));
                    run = new Run("ВЫКЛ.");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/a2_6_3.mp3"));
                    //Page_Frame.player.Play();
                    break;

                case 10:
                    //path14.Visibility = Visibility.Hidden;
                    //new clAnimation(imageSwitch3, "Переключатель/Switch", 1, 6, 50, ExecuteStep, 0, 0, enumFormatFile.PNG);
                    break;

                case 11:
                    btNext.Visibility = Visibility.Visible;
                    tbStepText.Inlines.Clear();
                    run = new Run("ВНИМАНИЕ! ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Во избежание разряда аккумулторных батарей при " +
                        "транспортировании, хранении КМО или отключении сетевого электропитания более чем на 24 ч " +
                        "переключатель АКБ БУ на передней панели НГК-БУ-Евро СКЗ 1 должен находится:"));
                    tbStepText.Inlines.Add(new LineBreak());
                    tbStepText.Inlines.Add(new Run("- при наличии сетевого напряжения на модуле НГК-БУ-ЕВРО СКЗ 1 - в положение ВКЛ."));
                    tbStepText.Inlines.Add(new LineBreak());
                    tbStepText.Inlines.Add(new Run("- при отсутствии сетевого напряжения на модуле НГК-БУ-ЕВРО СКЗ 1 - в положение ВЫКЛ."));
                    //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/a2_6_4.mp3"));
                    //Page_Frame.player.Play();
                    break;

                case 12:
                    // перемещение к общему виду шкафа
                    gridLabel.Visibility = Visibility.Hidden;
                    btNext.Visibility = Visibility.Hidden;
                    //BeginStoryboard((Storyboard)Resources["Storyboard2"]);
                    break;

                case 13:
                    gridLabel.Visibility = Visibility.Visible;
                    tbStepText.Inlines.Clear();
                    run = new Run("Шаг 3. ");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    tbStepText.Inlines.Add(new Run("Установите все вводные автоматические выключатели питающих сетей в положение "));
                    run = new Run("ОТКЛ.");
                    run.FontWeight = FontWeights.Bold;
                    tbStepText.Inlines.Add(run);
                    //path1.Visibility = Visibility.Visible;
                    //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/a2_6_5.mp3"));
                    //Page_Frame.player.Play();
                    break;

                case 14:
                    // открытие нижней дверцы
                    //path1.Visibility = Visibility.Hidden;
                    //new clAnimation(imageDoor, "Дверца выключателей/door", 1, 11, 50, ExecuteStep, 0, 0, enumFormatFile.PNG);
                    break;

                case 15:
                    // переход к выключателям сети
                    //BeginStoryboard((Storyboard)Resources["Storyboard3"]);
                    //imageAvto.Visibility = Visibility.Visible;
                    break;

                case 16:
                    //path2.Visibility = Visibility.Visible;
                    break;

                case 17:
                    gridLabel.Visibility = Visibility.Hidden;
                    //path2.Visibility = Visibility.Hidden;
                    //new clAnimation(imageAvto, "Автомат/Power", 11, 11, 50, ExecuteStep, 0, 1000, enumFormatFile.JPG, true);
                    break;

                case 18:
                    //PowerLED1.Visibility = Visibility.Hidden;
                    //PowerLED2.Visibility = Visibility.Hidden;
                    //BeginStoryboard((Storyboard)Resources["Storyboard2"]);
                    break;

                case 19:
                    gridComplete.Visibility = Visibility.Visible;
                    //Page_Frame.player.Open(new Uri("pack://siteoforigin:,,,/Sound/SectionA/a2_6_6.mp3"));
                    //Page_Frame.player.Play();
                    break;

            }

            Step++;
        }

    }
}
