using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RosaroterTigerWPF
{
    public static class DataService
    {
        /// <summary>
        /// Filename to I/O to
        /// </summary>
        public static readonly string filename = "milestones.sav";

        /// <summary>
        /// Serialize the collection of milestones
        /// </summary>
        /// <param name="milestones">The milestones to serialize.</param>
        public static void SerializeMilestones(ObservableCollection<Milestone> milestones)
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
        public static ObservableCollection<Milestone> DeserializeMilestones()
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(filename, FileMode.Open))
            {
                return (ObservableCollection<Milestone>)formatter.Deserialize(s);
            }
        }
    }
}
