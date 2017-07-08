using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterPanterWPF
{
    namespace DataService
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
        }

        public class Task
        {
            public Color Color{ get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double TotalTime { get; set; }
            public bool Finished { get; set; }
        }
    }
}
