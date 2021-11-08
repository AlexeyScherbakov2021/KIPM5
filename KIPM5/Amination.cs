using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace KIPM5
{
    public delegate void CallBackEndAnim();
    public enum enumFormatFile : int {PNG = 0, JPG = 1, BMP = 2};

    public class clAnimation
    {
        DispatcherTimer timer = new DispatcherTimer();
        string[] FormatFiles = {".png",".jpg",".bmp"};

        string AnimName;
        int CountImages;
        int StartNumImage;
        Image imgAnim;
        bool bRev;
        bool TimerDisabled;
        public CallBackEndAnim EndAnim;
        int BeginPause;
        int EndPause;
        int mSec;
        BitmapImage[] bmp;

        public clAnimation(Image img, string ImageBeginName, int startNum, int CntImages, int mSec,
            CallBackEndAnim func, int pause1, int pause2, enumFormatFile frmtFile,  bool Reverse = false)
        {
            EndAnim = func;
            AnimName = ImageBeginName;
            StartNumImage = startNum;
            CountImages = CntImages;
            imgAnim = img;
            bRev = Reverse;
            BeginPause = pause1;
            EndPause = pause2;
            this.mSec = mSec;
            string CurrFormat = FormatFiles[(int)frmtFile];

            bmp = new BitmapImage[CntImages];
            int Step = Reverse ? -1 : 1;
            int i = 0;
            while(i < CntImages)
            {
                bmp[i] = new BitmapImage(new Uri(AnimName + StartNumImage + CurrFormat, UriKind.Relative));
                i++;
                StartNumImage += Step;
            }

            StartNumImage = 1;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, mSec);
            TimerDisabled = false;

            imgAnim.Source = bmp[0];
            timer.Start();
        }

        //--------------------------------------------------------------------------------------------------
        // событие таймера
        //--------------------------------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            if (BeginPause > 0)
            {
                timer.Interval = new TimeSpan(0, 0, 0, 0, BeginPause);
                BeginPause = 0;
                timer.Start();
                return;
            }

            if (TimerDisabled)
                return;

            if (--CountImages <= 0)
            {
                if (EndPause > 0)
                {
                    timer.Interval = new TimeSpan(0, 0, 0, 0, EndPause);
                    EndPause = 0;
                    timer.Start();
                    return;
                }

                TimerDisabled = true;
                timer.IsEnabled = false;
                if (EndAnim != null)
                    EndAnim();
                return;
            }

            imgAnim.Source = bmp[StartNumImage];
            StartNumImage++;

            timer.Interval = new TimeSpan(0, 0, 0, 0, mSec);
            timer.Start();
        }

    }
}
