using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterTigerWPF
{
    /// <summary>
    /// Color class
    /// </summary>
    [Serializable]
    public class Color : ISerializable
    {
        static public readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            {"White", new Color(0xFF, 0xFF, 0xFF) },
            {"Yellow", new Color(0xFF, 0xFF, 0x00) },
            {"Green", new Color(0xFF, 0xFF, 0x00) },
            {"Black", new Color(0x00, 0x00, 0x00) },
            {"Red", new Color(0xFF, 0x00, 0x00) },
            {"Blue", new Color(0x00, 0x00, 0xFF) },
            {"Purple", new Color(0x6A, 0x5A, 0xCD) },
            {"Orange", new Color(0xFF, 0x8C, 0x00) },
            {"PinkRed", new Color(0xFF, 0x00, 0xFF) },
        };

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
        protected Color(SerializationInfo info, StreamingContext context)
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
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("R_Color_Value", R, typeof(byte));
            info.AddValue("G_Color_Value", G, typeof(byte));
            info.AddValue("B_Color_Value", B, typeof(byte));
        }

    }
}
