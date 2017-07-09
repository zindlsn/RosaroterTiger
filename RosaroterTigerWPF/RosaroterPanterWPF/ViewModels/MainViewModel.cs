using RosaroterTigerWPF.AppServices;
using RosaroterTigerWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RosaroterTigerWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // Properties:
        // -Goals and Tasks
        //
        // Methods:
        // -Start (Open Pomodoro)
        // -Delete ?Edit on a Goal/Todo
        // -?New
        // -Open Review

        public MainViewModel()
        {
            RefreshGoals();
        }

        private ObservableCollection<Goal> _Goals;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public ObservableCollection<Goal> Goals
        {
            get
            {
                return _Goals;
            }
            set
            {
                if (_Goals != value)
                {
                    _Goals = value;
                    this.OnPropertyChanged(nameof(Goals));
                }
            }
        }

        private ICommand _AddGoalCommand;
        public ICommand AddGoalCommand
        {
            get
            {
                if (_AddGoalCommand == null)
                {
                    _AddGoalCommand = new RelayCommand(
                        p => true,
                        p => this.AddGoal());
                }
                return _AddGoalCommand;
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

        public void RefreshGoals()
        {
            Goals = DataService.Goals;
        }

        public void RemoveSelectedGoal()
        {
            DataService.Goals.Remove(SelectedGoal);
            RefreshGoals();
        }

        public void EditGoal()
        {
            CacheService.CurrentGoal = SelectedGoal;
        }

        
    }
}
