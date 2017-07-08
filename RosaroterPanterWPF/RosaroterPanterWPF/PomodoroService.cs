using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace RosaroterPanterWPF
{
    public class PomodoroService
    {
        private Timer _Timer = new Timer();
        //private EventArgs 
        public int Seconds { get; set; }
        private int _CurrentSeconds { get; set; }

        public PomodoroService()
        {

        }

        public void SetTimerPerRound(int seconds)
        {
            this.Seconds = seconds;
            this._CurrentSeconds = seconds;
        }

        public void StartTask(Task task)
        {
            _Timer.Interval = 1000;
            _Timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this._CurrentSeconds > 0)
            {
                this._CurrentSeconds--;
            }
            else
            {
                this._CurrentSeconds = this.Seconds;
            }
        }

    }
}
