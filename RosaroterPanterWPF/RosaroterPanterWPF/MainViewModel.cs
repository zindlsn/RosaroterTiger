using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RosaroterPanterWPF
{
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

        public void TaskStartedClick(object sender, EventArgs args)
        {

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

        public void FillMilstones()
        {
            Milestones = App.DataService.LoadMilestones();
        }


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


        public void SetTimerPerRound(int seconds)
        {
            this.Seconds = seconds;
            this._CurrentSeconds = seconds;
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
                this._Timer.Stop();
            }
        }


    }
}
