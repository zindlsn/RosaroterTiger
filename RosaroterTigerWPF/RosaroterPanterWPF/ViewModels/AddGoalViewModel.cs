using RosaroterTigerWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RosaroterTigerWPF.ViewModels
{
    public class AddGoalViewModel : BaseViewModel
    {
        private string _GoalTitle;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public string GoalTitle
        {
            get
            {
                return _GoalTitle;
            }
            set
            {
                if (_GoalTitle != value)
                {
                    _GoalTitle = value;
                    this.OnPropertyChanged(nameof(GoalTitle));
                }
            }
        }

        private ICommand _SaveGoalCommand;
        public ICommand SaveGoalCommand
        {
            get
            {
                if (_SaveGoalCommand == null)
                {
                    _SaveGoalCommand = new RelayCommand(
                        p => true,
                        p => this.SaveGoal());
                }
                return _SaveGoalCommand;
            }
        }

        public void SaveGoal()
        {
            DataService.Goals.Add(new Goal()
            {
                Name = this.GoalTitle
            });
        }
    }
}
