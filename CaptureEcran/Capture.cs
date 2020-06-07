using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CaptureEcran
{
    /// <summary>
    /// This class represents a capture:
    /// * Image
    /// * Name of the Windows
    /// </summary>
    public class Capture
    {
        public byte [] Image { get; set; }

        public List<Area> Areas { get; set; } = new List<Area>();

        public class Area
        {
            public Area() { }

            public Area(string processName, string windowName, int x, int y, int width, int height)
            {
                ProcessName = processName; WindowName = windowName; X = x; Y = y; Width = width; Height = height;
            }
            public string ProcessName { get; set; }
            public string WindowName { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public bool IsOverlapped { get; set; }
        }
    }
}
