﻿using RosaroterPanterWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace RosaroterPanterWPF
{
    /// <summary>
    /// Start Viewmodel 
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private Timer _Timer = new Timer();
        private string _Title;

        public MainViewModel()
        {
            _Timer.Elapsed += Timer_Elapsed;
            this._TimerSeconds = 100;
        }

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
        public int TimerMinutes
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
                this._TimerSeconds--;
                if(this._CurrentSeconds % 60 == 0)
                {
                    this.TimerMinutes--;
                }
            }
            else
            {
                this.ResetTimer();
            }
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

        public void StartRound()
        {
            this.InitTimer(1000);
            this._Timer.Interval = 1000;
            this._Timer.Start();
        }

        private void StartTimer()
        {
            StartRound();
        }

        public bool CanStartTimerCommand = true;
    }
}
