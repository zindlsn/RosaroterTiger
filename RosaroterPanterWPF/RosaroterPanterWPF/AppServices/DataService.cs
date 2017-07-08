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
#if DEBUG && TESTDATA
            return TestData();
#else
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(filename, FileMode.Open))
            {
                return (ObservableCollection<Milestone>)formatter.Deserialize(s);
            }
#endif
        }

#if DEBUG
        public static ObservableCollection<Milestone> TestData()
        {
            var testData = new ObservableCollection<Milestone>();

            var milestone1 = new Milestone();

            milestone1.AddTask(new Task("Name 1", "Beschreibung 1"));
            milestone1.AddTask(new Task("Name 2", "Beschreibung 2"));
            milestone1.AddTask(new Task("Name 3", "Beschreibung 3"));
            milestone1.AddTask(new Task("Name 4", "Beschreibung 4"));
            milestone1.AddTask(new Task("Name 5", "Beschreibung 5"));
            milestone1.AddTask(new Task("Name 6", "Beschreibung 6"));
            milestone1.AddTask(new Task("Name 7", "Beschreibung 7"));
            milestone1.AddTask(new Task("Name 8", "Beschreibung 8"));
            milestone1.AddTask(new Task("Name 9", "Beschreibung 9"));

            testData.Add(milestone1);

            var milestone2 = new Milestone();

            milestone2.AddTask(new Task("Name Gelb", "Beschreibung Gelb", Color.Yellow));
            milestone2.AddTask(new Task("Name Grün", "Beschreibung Grün", Color.Green));
            milestone2.AddTask(new Task("Name Rot", "Beschreibung Rot", Color.Red));
            milestone2.AddTask(new Task("Name Blau", "Beschreibung Blau", Color.Blue));
            milestone2.AddTask(new Task("Name Lila", "Beschreibung Lila", Color.Purple));
            milestone2.AddTask(new Task("Name Weiß", "Beschreibung Weiß", Color.White));
            milestone2.AddTask(new Task("Name Schwarz", "Beschreibung Schwarz", Color.Black));
            milestone2.AddTask(new Task("Name Orange", "Beschreibung Orange",Color.Orange));
            milestone2.AddTask(new Task("Name Rosarot", "Beschreibung Rosarot", Color.PinkRed));

            testData.Add(milestone2);

            return testData;
        }
#endif
    }
}
