using System;
using System.Collections.Generic;
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

    public class Task
    {
        public Color Color { get; set; }
        public string Description { get; set; }
        public bool Completed { get; private set; }
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
        public List<Task> Tasks { get; set; }
        public bool Completed { get; private set; }

        public Milestone(int number_of_tasks)
        {
            Completed = false;
            Tasks = new List<Task>(number_of_tasks);
        }

        public Milestone() : this(0)
        { }

        void AddTask(Task task)
        {
            Tasks.Add(task);

        }
    }

    public class DataService
    {

    }
}
