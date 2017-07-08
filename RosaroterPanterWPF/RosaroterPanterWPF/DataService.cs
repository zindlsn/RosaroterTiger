using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterPanterWPF
{
    public class Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color()
        {
            R = 0;
            G = 0;
            B = 0;
        }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static readonly Color White = new Color(255, 255, 255);
    }

    public class Task : NotifyPropertyChanged
    {
        private bool _completed;

        public Color Color { get; set; }
        public string Description { get; set; }
        public bool Completed
        {
            get
            {
                return _completed;
            }
            private set
            {
                _completed = value;
                OnPropertyChanged("Completed");
            }
        }
        public string Name { get; set; }
        public double TotalTime { get; private set; }

        public Task(string name, string description, Color color)
        {
            Name = name;
            Description = description;
            Color = color;
        }

        public Task(string name, string description) : this(name, description, Color.White)
        { }

        public Task(string name) : this(name, string.Empty, Color.White)
        { }

        public Task() : this(string.Empty, string.Empty, Color.White)
        { }

        void Complete(double time)
        {
            Completed = true;
            TotalTime = time;
        }
    }

    public class Milestone
    {
        private delegate void TaskCompletionChanged(object sender, PropertyChangedEventArgs e);

        private PropertyChangedEventHandler _completedChanged;

        private ObservableCollection<Task> _tasks;
        public Task[] Tasks
        {
            get
            {
                return _tasks.ToArray();
            }
        }
        public bool Completed { get; private set; }

        public Milestone()
        {
            Completed = false;
            _tasks = new ObservableCollection<Task>();
            _completedChanged =  (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName.Equals("Completed"))
                    Completed = CheckForCompletion();
            };
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
            task.PropertyChanged += _completedChanged;
        }

        public int CountOfTasks()
        {
            return _tasks.Count;
        }

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

        private bool CheckForCompletion()
        {
            foreach (Task t in _tasks)
            {
                if (!t.Completed) return false;
            }
            return true;
        }
    }

    public class DataService
    {

    }
}
