using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterPanterWPF
{
    public class DataService
    {
        ObservableCollection<Milestone> Milestones { get; set; }

        public void SaveMilestones(ObservableCollection<Milestone> milestones)
        {
            this.Milestones = milestones;
        }

        public ObservableCollection<Milestone> LoadMilestones()
        {
            return Milestones;
        }


    }
}
