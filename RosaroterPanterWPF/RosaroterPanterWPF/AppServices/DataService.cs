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
        public static readonly string filename = "goals.sav";

        /// <summary>
        /// The goals
        /// </summary>
        static ObservableCollection<Goal> _goals = null;


        /// <summary>
        /// The goals
        /// </summary>
        public static ObservableCollection<Goal> Goals
        {
            get
            {
                if (_goals == null)
                {
                    // evtl. fixme if DeserializeGoals does not handle a errored file.
                    _goals = DeserializeGoals();
                }

                // when goals are still null then create a new Collection
                if (_goals == null) _goals = new ObservableCollection<Goal>();

                return _goals;
            }
            set
            {
                _goals = value;
            }
        }


        /// <summary>
        /// Serialize the collection of milestones
        /// </summary>
        public static void SerializeGoals()
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(s, _goals);
            }
        }

        /// <summary>
        /// Deserialize the collection of milestones
        /// </summary>
        /// <returns>Desierialized milestons.</returns>
        public static ObservableCollection<Goal> DeserializeGoals()
        {
#if DEBUG && TESTDATA
            return TestData();
#else
            IFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream s = new FileStream(filename, FileMode.Open))
                {
                    return (ObservableCollection<Goal>)formatter.Deserialize(s);
                }
            }
            catch(System.IO.FileNotFoundException)
            {
                return null;
            }
#endif
        }

#if DEBUG
        public static ObservableCollection<Goal> TestData()
        {
            var testData = new ObservableCollection<Goal>();

            var milestone1 = new Goal();

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

            var milestone2 = new Goal();

            milestone2.AddTask(new Task("Name Gelb", "Beschreibung Gelb", Color.Yellow));
            milestone2.AddTask(new Task("Name Grün", "Beschreibung Grün", Color.Green));
            milestone2.AddTask(new Task("Name Rot", "Beschreibung Rot", Color.Red));
            milestone2.AddTask(new Task("Name Blau", "Beschreibung Blau", Color.Blue));
            milestone2.AddTask(new Task("Name Lila", "Beschreibung Lila", Color.Purple));
            milestone2.AddTask(new Task("Name Weiß", "Beschreibung Weiß", Color.White));
            milestone2.AddTask(new Task("Name Schwarz", "Beschreibung Schwarz", Color.Black));
            milestone2.AddTask(new Task("Name Orange", "Beschreibung Orange", Color.Orange));
            milestone2.AddTask(new Task("Name Rosarot", "Beschreibung Rosarot", Color.PinkRed));

            testData.Add(milestone2);

            return testData;
        }
#endif
    }
}
