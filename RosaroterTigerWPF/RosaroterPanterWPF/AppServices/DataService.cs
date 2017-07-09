#define TESTDATA 

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using RosaroterTigerWPF.Models;
using System.Collections.Generic;

namespace RosaroterTigerWPF
{
    public static class DataService
    {
        /// <summary>
        /// Filename to I/O the goals
        /// </summary>
        public static readonly string goalsSaveFile = "goals.sav";

        /// <summary>
        /// Filename to I/O of the last 7 days results.
        /// </summary>
        public static readonly string daysSaveFile = "days.sav";

        /// <summary>
        /// The goals
        /// </summary>
        static ObservableCollection<Goal> _goals = null;

        /// <summary>
        /// The days
        /// </summary>
        static ObservableCollection<Day> _days = null;

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

                ShrinkGoals();

                return _goals;
            }
            set
            {
                _goals = value;
            }
        }

        /// <summary>
        /// The days
        /// </summary>
        public static ObservableCollection<Day> Days
        {
            get
            {
                if (_days == null)
                {
                    _days = DeserializeDays();
                }

                if (_days == null) _days = new ObservableCollection<Day>();

                if (!CorrectOrderOfDays())
                {
                    OrderDays();
                }

                ShrinkDays();

                return _days;
            }
            set
            {
                _days = value;
            }
        }

        /// <summary>
        /// Returns the day for today.
        /// </summary>
        public static Day Today
        {
            get
            {
                DateTime time = DateTime.Now;
                foreach (Day d in _days)
                {
                    if (d.DateTime.Day == time.Day && d.DateTime.Month == time.Month && d.DateTime.Year == d.DateTime.Year) return d;
                }

                // today was not found. Create a new day object.
                Day ret = new Day(time, null, string.Empty,Color.Colors["White"]);

                _days.Add(ret);

                return ret;
            }
        }


        /// <summary>
        /// Saves goals to goals.sav and days to days.sav
        /// </summary>
        public static void SaveEverything()
        {
            SerializeGoals();
            SerializeDays();
        }


        /// <summary>
        /// Shrinks the goals to only contain the last 7 days
        /// </summary>
        private static void ShrinkGoals()
        {
            for(int i = 0; i< _goals.Count; i++)
            {
                if(_goals[i].TimeOfTheLastCompletedTask > DateTime.Now.AddDays(7.0))
                {
                    _goals.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Reduces the number of days by removing the day at index 0.
        /// </summary>
        private static void ShrinkDays()
        {
            while(Days.Count > 7)
            {
                Days.RemoveAt(0);
            }
        }

        /// <summary>
        /// Checks if the order of day is correct (from oldest at index 0 to latest in index 1).
        /// </summary>
        /// <returns>If order is correct.</returns>
        private static bool CorrectOrderOfDays()
        {
            Day dayBefore = null;
            foreach(Day d in Days)
            {
                if(dayBefore != null)
                {
                    if(dayBefore.DateTime > d.DateTime)
                    {
                        return false;
                    }
                }
                dayBefore = d;
            }
            return true;
        }

        /// <summary>
        /// Sorts days.
        /// </summary>
        private static void OrderDays()
        {
            List<Day> sort = new List<Day>(_days);
            sort.Sort();
            _days = new ObservableCollection<Day>(sort);
        }

        /// <summary>
        /// Serialize the collection of goals
        /// </summary>
        private static void SerializeGoals()
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(goalsSaveFile, FileMode.Create))
            {
                formatter.Serialize(s, _goals);
            }
        }

        /// <summary>
        /// Deserialize the collection of goals
        /// </summary>
        /// <returns>Desierialized milestons.</returns>
        private static ObservableCollection<Goal> DeserializeGoals()
        {
#if DEBUG && TESTDATA
            return GoalsTestData();
#else
            IFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream s = new FileStream(daysSaveFile, FileMode.Open))
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

        
        /// <summary>
        /// Serialize the collection of days Results
        /// </summary>
        private static void SerializeDays()
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream s = new FileStream(goalsSaveFile, FileMode.Create))
            {
                formatter.Serialize(s, _days);
            }
        }

        /// <summary>
        /// Deserialize the collection of goals
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<Day> DeserializeDays()
        {
#if DEBUG && TESTDATA
            return DaysTestData();
#else
            IFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream s = new FileStream(goalsSaveFile, FileMode.Open))
                {
                    return (ObservableCollection<Day>)formatter.Deserialize(s);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                return null;
            }
#endif
        }

#if DEBUG
        public static ObservableCollection<Goal> GoalsTestData()
        {
            var testData = new ObservableCollection<Goal>();

            var milestone1 = new Goal()
            {
                Name = "Goal1"
            };

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

            var milestone2 = new Goal()
            {
                Name = "Goal2"
            };

            milestone2.AddTask(new Task("Name Gelb", "Beschreibung Gelb", Color.Colors["Yellow"]));
            milestone2.AddTask(new Task("Name Grün", "Beschreibung Grün", Color.Colors["Green"]));
            milestone2.AddTask(new Task("Name Rot", "Beschreibung Rot", Color.Colors["Red"]));
            milestone2.AddTask(new Task("Name Blau", "Beschreibung Blau", Color.Colors["Blue"]));
            milestone2.AddTask(new Task("Name Lila", "Beschreibung Lila", Color.Colors["Purple"]));
            milestone2.AddTask(new Task("Name Weiß", "Beschreibung Weiß", Color.Colors["White"]));
            milestone2.AddTask(new Task("Name Schwarz", "Beschreibung Schwarz", Color.Colors["Black"]));
            milestone2.AddTask(new Task("Name Orange", "Beschreibung Orange", Color.Colors["Orange"]));
            milestone2.AddTask(new Task("Name Rosarot", "Beschreibung Rosarot", Color.Colors["PinkRed"]));

            testData.Add(milestone2);

            return testData;
        }
        public static ObservableCollection<Day> DaysTestData()
        {
            var ret = new ObservableCollection<Day>();


            ResultOfTheDay result1 = new ResultOfTheDay();
            result1.CompletedTasks.Add(new Task("Task 1"));
            result1.CompletedTasks.Add(new Task("Task 2"));
            result1.CompletedGoals.Add("Goal 1");
            result1.CompletedGoals.Add("Goal 2");
            result1.CompletedGoals.Add("Goal 3");
            result1.TimeSpentWorking = 20.0;

            Day test1 = new Day(new DateTime(2000, 10, 10), result1, "Ein echt guter Kommentar 1", Color.Colors["Yellow"]);

            ResultOfTheDay result2 = new ResultOfTheDay();
            result2.CompletedTasks.Add(new Task("Another Task1"));
            result2.CompletedTasks.Add(new Task("Another Task2"));
            result2.CompletedGoals.Add("Another Goal1");
            result2.CompletedGoals.Add("Another Goal2");
            result2.CompletedGoals.Add("Another Goal3");
            result2.TimeSpentWorking = 10.0;

            Day test2 = new Day(new DateTime(2010, 10, 10), result2, "Ein weiterer guter Kommentar", Color.Colors["Orange"]);

            ret.Add(test1);
            ret.Add(test2);
            
            return ret;
        }
#endif
    }
}
