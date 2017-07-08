using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RosaroterPanterWPF
{
    /// <summary>
    /// Start Viewmodel
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private Timer _Timer = new Timer();
        private string _Title;

        private Task _CurrentTask;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public Task CurrentTask
        {
            get
            {
                return _CurrentTask;
            }
            set
            {
                if (_CurrentTask != value)
                {
                    _CurrentTask = value;
                    this.OnPropertyChanged(nameof(CurrentTask));
                }
            }
        }

        /// <summary>
        /// Calls when user clicks on a Task to start working on it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TaskStartedClick(object sender, EventArgs args)
        {
           // this.CurrentTask = 
        }

        public string Title
        {
            get {
                return _Title;
            }
            set
            {
                if(_Title != value)
                {
                    _Title = value;
                }
            }
        }

        private int _TimerSeconds;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public int TimerSeconds
        {
            get
            {
                return _TimerSeconds;
            }
            set
            {
                if (_TimerSeconds != value)
                {
                    _TimerSeconds = value;
                    this.OnPropertyChanged(nameof(TimerSeconds));
                }
            }
        }


        private int _TimerMinutes;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public int TimerHour
        {
            get
            {
                return _TimerMinutes;
            }
            set
            {
                if (_TimerMinutes != value)
                {
                    _TimerMinutes = value;
                    this.OnPropertyChanged(nameof(TimerHour));
                }
            }
        }

        /// <summary>
        /// Resets timer after each Round
        /// </summary>
        public void ResetTimer()
        {

        }

        private ObservableCollection<Milestone> _Milestones;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public ObservableCollection<Milestone> Milestones
        {
            get
            {
                return _Milestones;
            }
            set
            {
                if (_Milestones != value)
                {
                    _Milestones = value;
                    this.OnPropertyChanged(nameof(Milestones));
                }
            }
        }
        /// <summary>
        /// Refreshes the Milestonelist
        /// </summary>
        public void RefreshMilestones()
        {
            Milestones = App.DataService.LoadMilestones();
        }

        /// <summary>
        /// Sets the Pomodoro Round time
        /// </summary>
        public int Seconds { get; set; }
        private int _CurrentSeconds;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public int CurrentSeconds
        {
            get
            {
                return _CurrentSeconds;
            }
            set
            {
                if (_CurrentSeconds != value)
                {
                    _CurrentSeconds = value;
                    this.OnPropertyChanged(nameof(CurrentSeconds));
                }
            }
        }

        /// <summary>
        /// Inits the Timer
        /// </summary>
        /// <param name="seconds"></param>
        public void InitTimer(int seconds)
        {
            this.Seconds = seconds;
            this._CurrentSeconds = seconds;
        }


        /// <summary>
        /// Calls when a second of the timer is elapsed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this._CurrentSeconds > 0)
            {
                this._CurrentSeconds--;
            }
            else
            {
                this._CurrentSeconds = this.Seconds;
                this._Timer.Stop();
            }
        }


    }
}
