using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterPanterWPF
{
    public class DataService
    {
        public static readonly string filename = "milestones.sav";

        /// <summary>
        /// Serialize the collection of milestones
        /// </summary>
        /// <param name="milestones">The milestones to serialize.</param>
        public void SerializeMilestones(ObservableCollection<Milestone> milestones)
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(s, milestones);
            }
        }

        /// <summary>
        /// Deserialize the collection of milestones
        /// </summary>
        /// <returns>Desierialized milestons.</returns>
        public ObservableCollection<Milestone> DeserializeMilestones()
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(filename, FileMode.Open))
            {
                return (ObservableCollection<Milestone>)formatter.Deserialize(s);
            }
        }
    }
}
