using RosaroterTigerWPF.AppServices;
using RosaroterTigerWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RosaroterTigerWPF.ViewModels
{
    public class EditGoalViewModel : BaseViewModel
    {
        public EditGoalViewModel()
        {

        }
        public string GoalTitle { get; set; }

        internal void UpdateGoal()
        {
            CacheService.CurrentGoal.Name = this.GoalTitle;
        }

    }
}
