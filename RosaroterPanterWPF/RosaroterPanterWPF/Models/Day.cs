using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterTigerWPF.Models
{
    [Serializable]
    public class ResultOfTheDay : ISerializable
    {
        /// <summary>
        /// The names of the completed goals of the day 
        /// </summary>
        public ObservableCollection<string> CompletedGoals { get; set; }

        /// <summary>
        /// The completed tasks of the day with all its information
        /// </summary>
        public ObservableCollection<Task> CompletedTasks { get; set; }

        /// <summary>
        /// The time that was spent working on that day
        /// </summary>
        public double TimeSpentWorking { get; set; }

        /// <summary>
        /// Default Constuctor
        /// </summary>
        ResultOfTheDay() : this(null, null, 0.0)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="completedGoals">The names of the completed Goals of the day.</param>
        /// <param name="completedTasks">The tasks completed this day.</param>
        /// <param name="timeSpentWorking">The time spent working on that day.</param>
        public ResultOfTheDay(ObservableCollection<String> completedGoals, ObservableCollection<Task> completedTasks, double timeSpentWorking)
        {
            CompletedGoals = completedGoals;
            CompletedTasks = completedTasks;
            TimeSpentWorking = timeSpentWorking;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ResultOfTheDay(SerializationInfo info, StreamingContext context)
        {
            CompletedGoals = (ObservableCollection<string>)info.GetValue("ROTDay_CompletedGoals", typeof(ObservableCollection<string>));
            CompletedTasks = (ObservableCollection<Task>)info.GetValue("ROTDay_CompletedTasks", typeof(ObservableCollection<Task>));
            TimeSpentWorking = info.GetDouble("ROTDay_TimeSpentWorking");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ROTDay_CompletedGoals", CompletedGoals, typeof(ObservableCollection<string>));
            info.AddValue("ROTDay_CompletedTasks", CompletedTasks, typeof(ObservableCollection<Task>));
            info.AddValue("ROTDay_TimeSpentWorking", TimeSpentWorking);
        }
    }

    [Serializable]
    public class Day : ISerializable
    {
        public DateTime DateTime { get; set; }

        public string Weekday { get; set; }

        public ResultOfTheDay Results { get; set; }

        public string Comments { get; set; }

        public Day(DateTime dateTime, ResultOfTheDay results, string comments)
        {
            DateTime = dateTime;
            Results = results;
            Comments = comments;

            SetWeekdayString();
        }

        public Day(SerializationInfo info, StreamingContext context)
        {
            DateTime = info.GetDateTime("Day_DateTimeCompleted");
            Results = (ResultOfTheDay) info.GetValue("Day_Results", typeof(ResultOfTheDay));
            Comments = info.GetString("Day_Comments");

            SetWeekdayString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Day_DateTime", DateTime);
            info.AddValue("Day_Results", Results, typeof(ResultOfTheDay));
            info.AddValue("Day_Comments", Comments);
        }

        private void SetWeekdayString()
        {
            switch (DateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Weekday = "Monday";
                    break;

                case DayOfWeek.Tuesday:
                    Weekday = "Tuesday";
                    break;

                case DayOfWeek.Thursday:
                    Weekday = "Thursday";
                    break;

                case DayOfWeek.Friday:
                    Weekday = "Friday";
                    break;

                case DayOfWeek.Saturday:
                    Weekday = "Saturday";
                    break;

                case DayOfWeek.Sunday:
                    Weekday = "Sunday";
                    break;

                default:
                    Weekday = "Some day";
                    break;
            }
        }
    }
}
