using RosaroterTigerWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RosaroterTigerWPF.ViewModels
{
    /// <summary>
    /// Start Viewmodel 
    /// </summary>
    public class PomodoroViewModel : BaseViewModel
    {
        public bool CanStartTimerCommand = true;

        private static int _PomodoroTime = 25 * 60;

        private string _Title;
        private string _StartStopButtonText = "Start";
        
        private ObservableCollection<Goal> _Goals;

        private Timer _Timer = new Timer();
        private string _TimerSeconds;
        private string _TimerMinutes;

        /// <summary>
        /// Started Task
        /// </summary>
        private Task _CurrentTask;
        private List<Task> CompletedTasksPerDay { get; set; }
        private Task _SelectedTask;
        private Goal _SelectedGoal;

        private ICommand _StartTimerCommand;
        private ICommand _FinishDayCommand;
        private ICommand _GoToHomePageCommand;

        private bool _IsIdle = true;

        /// <summary>
        /// Sets the Pomodoro Round time
        /// </summary>
        private int _CurrentSeconds;


        public PomodoroViewModel()
        {
            _Timer.Elapsed += Timer_Elapsed;
            this._CurrentSeconds = _PomodoroTime;
            UpdateTimerView(_CurrentSeconds);
            RefreshMilestones();
        }
        /// <summary>
        /// Title of the Window.
        /// </summary>


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
        /// Seconds of the timer as a string.
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

        /// <summary>
        /// Minutes of the timer as a string
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
        /// Goals
        /// </summary>
        public ObservableCollection<Goal> Milestones
        {
            // todo rename to Goals
            get
            {
                return _Goals;
                //return DataService.Goals;
            }
            set
            {
                if (_Goals != value)
                {
                    _Goals = value;
                    //DataService.Goals = value;
                    this.OnPropertyChanged(nameof(Milestones));
                }
            }
        }

        /// <summary>
        /// Current seconds.
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

        public ICommand StartTimerCommand
        {
            get
            {
                if (_StartTimerCommand == null)
                {
                    _StartTimerCommand = new RelayCommand(
                        p => CanStartTimerCommand,
                        p => this.StartTimer());
                }
                return _StartTimerCommand;
            }
        }

        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public Goal SelectedGoal
        {
            get
            {
                return _SelectedGoal;
            }
            set
            {
                if (_SelectedGoal != value)
                {
                    _SelectedGoal = value;
                    this.OnPropertyChanged(nameof(SelectedGoal));
                }
            }
        }
        
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public string StartStopButtonText
        {
            get
            {
                return _StartStopButtonText;
            }
            set
            {
                if (_StartStopButtonText != value)
                {
                    _StartStopButtonText = value;
                    this.OnPropertyChanged(nameof(StartStopButtonText));
                }
            }
        }

        public ICommand FinishDayCommand
        {
            get
            {
                if (_FinishDayCommand == null)
                {
                    _FinishDayCommand = new RelayCommand(
                        p => CanFinishDay,
                        p => this.FinishDay());
                }
                return _FinishDayCommand;
            }
        }

        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public bool IsIdle
        {
            get
            {
                return _IsIdle;
            }
            set
            {
                if (_IsIdle != value)
                {
                    _IsIdle = value;
                    this.OnPropertyChanged(nameof(IsIdle));
                }
            }
        }

        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public Task SelectedTask
        {
            get
            {
                return _SelectedTask;
            }
            set
            {
                if (_SelectedTask != value)
                {
                    _SelectedTask = value;
                    this.OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }

        public bool CanFinishDay { get; private set; }


        /// <summary>
        /// Inits the Timer
        /// </summary>
        /// <param name="seconds"></param>
        public void InitTimer(int seconds)
        {
            _PomodoroTime = seconds;
            this.CurrentSeconds = seconds;
        }

        /// <summary>
        /// Pause the recent Timer.
        /// </summary>
        public void PauseTimer()
        {
            this._Timer.Stop();
            ChangeStartButtonText();
        }

        /// <summary>
        /// Closes the work day:
        /// </summary>
        public void FinishDay()
        {

            this._Timer.Dispose();
        }

        /// <summary>
        /// Refreshes the Milestonelist
        /// </summary>
        public void RefreshMilestones()
        {
            Milestones = DataService.Goals;
        }

        public void AddCompletedTask(Task task)
        {
            this.CompletedTasksPerDay.Add(task);
        }

        /// <summary>
        /// Change the startButtonText
        /// </summary>
        public void ChangeStartButtonText()
        {
            if (!_IsIdle)
            {
                StartStopButtonText = "Pause";
            }
            else
            {
                StartStopButtonText = "Start";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartTimer()
        {
            if (_IsIdle)
            {
                this._Timer.Interval = 1000;
                this._Timer.Start();
                this.IsIdle = false;
            }
            else
            {
                this.IsIdle = true;
                this.PauseTimer();
            }
            ChangeStartButtonText();
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
            TimerMinutes = ((seconds % 3600) / 60).ToString();
            TimerMinutes = (int.Parse(TimerMinutes)).ToString("00");
            TimerSeconds = (seconds % 60).ToString();
            TimerSeconds = (int.Parse(TimerSeconds)).ToString("00");
        }

        /// <summary>
        /// Resets timer after each Round
        /// </summary>
        public void ResetTimer()
        {
            this._CurrentSeconds = _PomodoroTime;
            this._Timer.Stop();
        }

        /// <summary>
        /// Deletes the selected goal.
        /// </summary>
        public void DeleteSelectedGoal()
        {
            this._Goals.Remove(SelectedGoal);
        }
    }
}
