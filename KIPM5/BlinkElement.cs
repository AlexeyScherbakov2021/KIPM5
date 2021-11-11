using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace KIPM5
{
    //enum Status { On, Off/*, BlinkOn, BlinkOff*/ };

    internal class BlinkElement
    {
        private UIElement _element;
        private bool _end_status;


        private bool _status = false;
        public bool status
        {
            get => _status;
            set
            {
                _status = value;
                if(_element != null)
                {
                    if (_status)
                        _element.Visibility = Visibility.Visible;
                    else
                        _element.Visibility = Visibility.Hidden;
                }
            }
        }

        private int _count;
        private DispatcherTimer timer;

        private int _frequence;

        public BlinkElement(UIElement element)
        {
            _element = element;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
        }

        //--------------------------------------------------------------------------------
        // событие таймера
        //--------------------------------------------------------------------------------
        private void Timer_Tick(object sender, EventArgs e)
        {
            status = !status;

            if (--_count <= 0)
            {
                Stop();
                //timer.Stop();
                //status = _end_status;
            }

        }


        //--------------------------------------------------------------------------------
        // установка статуса элемента
        //--------------------------------------------------------------------------------
        public void SetStatus(bool stat, int count = 0, int freq = 500)
        {
            _end_status = stat;
            _frequence = freq;
            _count = count * 2;

            if (count > 0)
            {
                timer.Interval = new TimeSpan(0,0,0,0, freq);
                timer.Start();
            }
            else
                status = _end_status;
        }

        public void Stop()
        {
            timer.Stop();
            status = _end_status;
        }
    }
}
