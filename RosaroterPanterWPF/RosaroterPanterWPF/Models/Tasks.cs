using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterPanterWPF
{
    /// <summary>
    /// Color class
    /// </summary>
    public class Color
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
    }

    /// <summary>
    /// Class representing a task.
    /// </summary>
    public class Task : NotifyPropertyChanged
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
    public class Milestone
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
