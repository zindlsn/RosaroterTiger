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
                g = G;
                b = B;
            }
        }

        public class Task
        {
            private Color _color;
            public Color Color
            {
                get
                {
                    return _color;
                }
                set
                {
                    _color = value;
                }
            }
            
        }
    }
}
