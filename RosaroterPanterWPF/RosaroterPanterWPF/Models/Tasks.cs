using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace RosaroterPanterWPF
{
    /// <summary>
    /// Color class
    /// </summary>
    [Serializable]
    public class Color: ISerializable
    {
        /// <summary>
        /// The color white.
        /// </summary>
        public static readonly Color White = new Color(255, 255, 255);


        /// <summary>
        /// Default-Constructor
        /// </summary>
        public Color()
        {
            R = 0;
            G = 0;
            B = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r">The red value of the color from 0-255.</param>
        /// <param name="g">The green value of the color from 0-255.</param>
        /// <param name="b">The blue value of the color from 0-255.</param>
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Constructor for serialization
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        public Color(SerializationInfo info, StreamingContext context)
        {
            R = info.GetByte("R_Color_Value");
            G = info.GetByte("G_Color_Value");
            B = info.GetByte("B_Color_Value");
        }


        /// <summary>
        /// The red value of the color from 0-255.
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// The green value of the color from 0-255.
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        ///The blue value of the color from 0-255.
        /// </summary>
        public byte B { get; set; }


        /// <summary>
        /// Method for serialization
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("R_Color_Value", R, typeof(byte));
            info.AddValue("G_Color_Value", G, typeof(byte));
            info.AddValue("B_Color_Value", B, typeof(byte));
        }

    }

    /// <summary>
    /// Class representing a task.
    /// </summary>
    [Serializable]
    public class Task : NotifyPropertyChanged, ISerializable
    {
        private bool _completed;


        /// <summary>
        /// Default-Constructor
        /// </summary>
        public Task() : this(string.Empty, string.Empty, Color.White)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the task.</param>
        public Task(string name) : this(name, string.Empty, Color.White)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="description">The description of the task.</param>
        public Task(string name, string description) : this(name, description, Color.White)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="description">The description of the task.</param>
        /// <param name="color">The color value of the task.</param>
        public Task(string name, string description, Color color)
        {
            Name = name;
            Description = description;
            Color = color;
            TotalTime = 0.0;
        }

        /// <summary>
        /// Constructor for serialization
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        public Task(SerializationInfo info, StreamingContext context)
        {
            _completed = info.GetBoolean("Task_Completed");
            Color = (Color) info.GetValue("Task_Color", typeof(Color));
            Description = info.GetString("Task_Description");
            Name = info.GetString("Task_Name");
            TotalTime = info.GetDouble("Task_TotalTime");
        }


        /// <summary>
        /// A color value of the task
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If the task is completed.
        /// </summary>
        public bool Completed
        {
            get
            {
                return _completed;
            }
            private set
            {
                _completed = value;
                OnPropertyChanged(nameof(Complete));
            }
        }

        /// <summary>
        /// The name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time spent till the completion of the task.
        /// </summary>
        public double TotalTime { get; private set; }


        /// <summary>
        /// Method for serialization
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Task_Completed", _completed, typeof(bool));
            info.AddValue("Task_Color", Color, typeof(Color));
            info.AddValue("Task_Description", Description, typeof(string));
            info.AddValue("Task_Name", Name, typeof(string));
            info.AddValue("Task_TotalTime", TotalTime, typeof(double));
        }

        /// <summary>
        /// Complete the task and register a total time spent with it.
        /// </summary>
        /// <param name="time"></param>
        public void Complete(double time)
        {
            Completed = true;
            TotalTime += time;
        }

        /// <summary>
        /// Sets completed to false while containing the time spent
        /// </summary>
        public void UnComplete()
        {
            Completed = false;
        }
    }

    /// <summary>
    /// Class representing a milestone. A milestone is series of tasks.
    /// </summary>
    [Serializable]
    public class Milestone : ISerializable
    {
        private ObservableCollection<Task> _tasks;
        private PropertyChangedEventHandler _completedChanged;

        private delegate void TaskCompletionChanged(object sender, PropertyChangedEventArgs e);


        /// <summary>
        /// Default-Constructor
        /// </summary>
        public Milestone()
        {
            Completed = false;
            _tasks = new ObservableCollection<Task>();
            _completedChanged = (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName.Equals("Completed"))
                    Completed = CheckForCompletion();
            };
        }

        /// <summary>
        /// Constructor for serialization
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        public Milestone(SerializationInfo info, StreamingContext context)
        {
            _tasks = (ObservableCollection<Task>)info.GetValue("Ms_Tasks", typeof(ObservableCollection<Task>));

            _completedChanged = (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName.Equals("Completed"))
                    Completed = CheckForCompletion();
            };

            foreach (Task t in _tasks)
            {
                t.PropertyChanged += _completedChanged;
            }

            Completed = CheckForCompletion();
        }


        /// <summary>
        /// Array containing every task of the milestone.
        /// </summary>
        public Task[] Tasks
        {
            get
            {
                return _tasks.ToArray();
            }
        }

        /// <summary>
        /// If the milestone is completed.
        /// </summary>
        public bool Completed { get; private set; }

        
        /// <summary>
        /// Adds a task.
        /// </summary>
        /// <param name="task">The task to add.</param>
        public void AddTask(Task task)
        {
            _tasks.Add(task);
            task.PropertyChanged += _completedChanged;
            Completed = CheckForCompletion();
        }

        /// <summary>
        /// Returns the count of tasks.
        /// </summary>
        /// <returns>Count of tasks.</returns>
        public int CountOfTasks()
        {
            return _tasks.Count;
        }

        /// <summary>
        /// Removes a task at a given index.
        /// </summary>
        /// <param name="index">Index of the task to remove.</param>
        /// <returns>If the index was valid.</returns>
        public bool RemoveTaskAt(int index)
        {
            if (_tasks.Count > index)
            {
                _tasks.ElementAt(index).PropertyChanged -= (object sender, PropertyChangedEventArgs e) =>
                {
                    if (e.PropertyName.Equals("Completed"))
                        Completed = CheckForCompletion();
                };
                _tasks.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method for serialization
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // calculate completed in the constructor
            // initialise _completed changed in constructor

            info.AddValue("Ms_Tasks", _tasks, typeof(ObservableCollection<Task>));
        }


        /// <summary>
        /// Checks every task for completion. To verify if the milestone was reached.
        /// </summary>
        /// <returns>If the milestone is complete.</returns>
        private bool CheckForCompletion()
        {
            foreach (Task t in _tasks)
            {
                if (!t.Completed) return false;
            }
            return true;
        }

       
    }
}
