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
        private Timer _Timer = new Timer();
        private string _Title;
        private static int _PomodoroTime = 25 * 60;

        private List<Task> CompletedTasksPerDay { get; set; }

        public PomodoroViewModel()
        {
            _Timer.Elapsed += Timer_Elapsed;
            this._CurrentSeconds = _PomodoroTime;
            this.Seconds = _PomodoroTime;
            RefreshMilestones();
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

        private Goal _SelectedGoal;
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
        /// 
        /// </summary>
        private void StartTimer()
        {
            this.InitTimer(1000);
            this._Timer.Interval = 1000;
            this._Timer.Start();
            this.IsIdle = false;
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
            System.TimeSpan t = System.TimeSpan.FromSeconds(seconds);
            _TimerMinutes = t.Minutes.ToString();
            _TimerSeconds = t.Seconds.ToString();
        }


        /// <summary>
        /// Refreshes the Milestonelist
        /// </summary>
        public void RefreshMilestones()
        {
            Milestones = DataService.DeserializeGoals();
        }

        private static NavigationService navigator;

        /// <summary>
        /// Navigates to the ComodoroView.
        /// </summary>
        public void StartPomodoroPage()
        {
            navigator.Navigate(typeof(HomePage));
        }

        public void AddCompletedTask(Task task)
        {
            this.CompletedTasksPerDay.Add(task);
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

        private string _StartStopButtonText;
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


        private ICommand _FinishDayCommand;
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
                return _StartTimerCommand;
            }
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

        private bool _IsIdle;
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
        private Task _SelectedTask;
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

        private ICommand _GoToHomePageCommand;
        public ICommand GotoHomepageCommand
        {
            get
            {
                if (_GoToHomePageCommand == null)
                {
                    _GoToHomePageCommand = new RelayCommand(
                        p => true,
                        p => this.GoToHomePage());
                }
                return _StartTimerCommand;
            }
        }

        /// <summary>
        /// goes back to the homepage
        /// </summary>
        private void GoToHomePage()
        {

        }
        /// <summary>
        /// Deletes the selected goal.
        /// </summary>
        public void DeleteSelectedGoal()
        {
            this._Milestones.Remove(SelectedGoal);
        }
    }
}
