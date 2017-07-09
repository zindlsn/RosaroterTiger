using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ObservableCollection<Goal> Goals
        {
            get
            {
                return DataService.Goals;
            }
            set
            {
                DataService.Goals = value;
            }
        }
    }
}
