using RosaroterTigerWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace RosaroterTigerWPF
{
    /// <summary>
    /// Start Viewmodel 
    /// </summary>
    public class PomodoroViewModel : BaseViewModel
    {
        private Timer _Timer = new Timer();
        private string _Title;
        private static int _PomodoroTime = 25 * 60;

        public PomodoroViewModel()
        {
            _Timer.Elapsed += Timer_Elapsed;
            this._CurrentSeconds = _PomodoroTime;
            this.Seconds = _PomodoroTime;
        }
        /// <summary>
        /// Title of the Window.
        /// </summary>

        public bool CanStartTimerCommand = true;


        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                }
            }
        }

        /// <summary>
        /// Started Task
        /// </summary>
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

        private string _TimerSeconds;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public string TimerSeconds
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

        private string _TimerMinutes;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public string TimerMinutes
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
                    this.OnPropertyChanged(nameof(TimerMinutes));
                }
            }
        }

        /// <summary>
        /// Resets timer after each Round
        /// </summary>
        public void ResetTimer()
        {
            this._CurrentSeconds = this.Seconds;
            this._Timer.Stop();
        }

        private ObservableCollection<Goal> _Milestones;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public ObservableCollection<Goal> Milestones
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


        private ICommand _StartTimerCommand;
        public ICommand StartTimerCommand
        {
            get
            {
                if (_StartTimerCommand == null)
                {
                    _StartTimerCommand = new RelayCommand(
                        p => true,
                        p => this.StartTimer());
                }
                return _StartTimerCommand;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void StartTimer()
        {
            this.InitTimer(1000);
            this._Timer.Interval = 1000;
            this._Timer.Start();
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
                this.UpdateTimerView(_CurrentSeconds);
            }
            else
            {
                this.ResetTimer();
            }
        }

        /// <summary>
        /// Updates the Timer for the View.
        /// </summary>
        /// <param name="seconds"></param>
        public void UpdateTimerView(int seconds)
        {
            System.TimeSpan t = System.TimeSpan.FromSeconds(seconds);
            _TimerMinutes = t.Minutes.ToString();
            _TimerSeconds = t.Seconds.ToString();
        }


        /// <summary>
        /// Refreshes the Milestonelist
        /// </summary>
        public void RefreshMilestones()
        {
            Milestones = DataService.DeserializeMilestones();
        }

        /// <summary>
        /// Navigates to the ComodoroView.
        /// </summary>
        public void StartComodoroView()
        {

        }

        /// <summary>
        /// Pause the recent Timer.
        /// </summary>
        public void PauseTimer()
        {
            this._Timer.Stop();
        }
        /// <summary>
        /// Closes the word day:
        /// 
        /// </summary>
        public void FinishDay()
        {
            this._Timer.Dispose();
        }
    }
}
