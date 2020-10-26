using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Pomodoro
{
    public partial class TimerToolWindowControl : UserControl
    {
        private TimeSpan _time;
        private DispatcherTimer _timer;
        public TimerToolWindowControl()
        {
            InitializeComponent();
            _time = TimeSpan.FromMinutes(20);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                lblTime.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    SystemSounds.Beep.Play();
                }

                _time = _time.Add(TimeSpan.FromSeconds(-1));

            }, Application.Current.Dispatcher);

            _timer.IsEnabled = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (_timer.IsEnabled)
            {
                _timer.Stop();
                btnStartStop.Content = "Start";
            }
            else
            {
                _timer.Start();
                btnStartStop.Content = "Stop";
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _time = TimeSpan.FromMinutes(20);
            lblTime.Content = _time.ToString("c");
            _timer.Stop();
        }
    }
}