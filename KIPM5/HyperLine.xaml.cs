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
    public partial class HyperLine : UserControl
    {
        public static List<string> UsedUrl = new List<string>();

        public static List<HyperLine> listLink = new List<HyperLine>();

        public static DependencyProperty TextProperty;
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static DependencyProperty ColorArrowProperty;
        public Brush ColorArrow
        {
            get { return (Brush)GetValue(ColorArrowProperty); }
            set { SetValue(ColorArrowProperty, value); }
        }

        public static DependencyProperty NavigateUriProperty;
        public String NavigateUri
        {
            get { return (String) GetValue(NavigateUriProperty); }
            set { SetValue(NavigateUriProperty, value); }
        }

        public static DependencyProperty VisibleImageProperty;
        public bool VisibleImage
        {
            get { return (bool)GetValue(VisibleImageProperty); }
            set { SetValue(VisibleImageProperty, value); SetVisibleImage(value); }
        }

        public static readonly RoutedEvent OnNavigateEvent =
                EventManager.RegisterRoutedEvent("OnNavigate", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(HyperLine));


        public event RoutedEventHandler OnNavigate
        {
            add { AddHandler(OnNavigateEvent, value); }
            remove { RemoveHandler(OnNavigateEvent, value); }
        }

        Brush InitBrush;

        public HyperLine()
        {
            InitializeComponent();
        }

        static HyperLine()
        {

            TextProperty = DependencyProperty.Register("Text", typeof(String), typeof(HyperLine),
                new FrameworkPropertyMetadata("New Text"));

            ColorArrowProperty = DependencyProperty.Register("ColorArrow", typeof(Brush), typeof(HyperLine),
                new FrameworkPropertyMetadata(Brushes.Black));

            NavigateUriProperty = DependencyProperty.Register("NavigateUri", typeof(String), typeof(HyperLine),
                new FrameworkPropertyMetadata(""));

            VisibleImageProperty = DependencyProperty.Register("VisibleImage", typeof(bool), typeof(HyperLine),
                new FrameworkPropertyMetadata(false));


        }


        private void SetVisibleImage(bool State)
        {
            Part_path.Visibility = State ? Visibility.Visible : Visibility.Hidden;
        }

        //-----------------------------------------------------------------------------------------------------
        // событие отжимания левой кнопки мыши
        //-----------------------------------------------------------------------------------------------------
        private void Tb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (NavigateUri == "")
                return;

            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(OnNavigateEvent);
            RaiseEvent(args);

            if (!args.Handled)
            {
                NavigationService nav;
                nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri(NavigateUri, UriKind.RelativeOrAbsolute));
                if(!UsedUrl.Contains(NavigateUri))
                    UsedUrl.Add(NavigateUri);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        // событие входа курсора мыши
        //-----------------------------------------------------------------------------------------------------
        private void Tb_MouseEnter(object sender, MouseEventArgs e)
        {
            if (NavigateUri == "")
                return;

            InitBrush = Foreground;
            Foreground = Brushes.DarkOrange;
            Cursor = Cursors.Hand;
        }

        //-----------------------------------------------------------------------------------------------------
        // событие покидания курсора мыши
        //-----------------------------------------------------------------------------------------------------
        private void Tb_MouseLeave(object sender, MouseEventArgs e)
        {
            if (NavigateUri == "")
                return;

            Foreground = InitBrush;
            Cursor = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (UsedUrl.Contains(NavigateUri))
            {
                tb.Opacity = 0.6;
                Part_path.Opacity = 0.3;
            }
        }
    }
}
