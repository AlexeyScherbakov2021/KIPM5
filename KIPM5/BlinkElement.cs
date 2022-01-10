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
        private int[] _program;
        private int curProg;

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

        //private int _count;
        private DispatcherTimer timer;

        //private int _frequence;

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
            if (curProg >= _program.Length)
            {
                Stop();
                return;
            }

            timer.Stop();
            status = !status;
            timer.Interval = new TimeSpan(0,0,0,0, _program[curProg]);
            curProg++;
            timer.Start();


        }


        //--------------------------------------------------------------------------------
        // установка статуса элемента
        //--------------------------------------------------------------------------------
        public void SetStatus(bool end_stat, bool start_stat, int[] prog)
        {
            _end_status = end_stat;
            _program = prog;
            curProg = 1;
            status = start_stat;
            //_frequence = freq;
            //_count = count * 2;

            if (_program.Length > 1)
            {
                timer.Interval = new TimeSpan(0,0,0,0, _program[0]);
                timer.Start();
            }
            else
                status = _end_status;
        }

        //--------------------------------------------------------------------------------
        // остановка программы мигания
        //--------------------------------------------------------------------------------
        public void Stop()
        {
            timer.Stop();
            status = _end_status;
        }
    }
}
