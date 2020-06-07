using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;

namespace CaptureEcran
{
    /// <summary>
    /// This class contains the parameters and logic to capture the screen
    /// </summary>
    public class Capturer
    {
        public Screen Screen { get; set; }
        public string OuputDirectory { get; set; }
    
        /// <summary>
        /// Capture the screen
        /// </summary>
        public Capture Capture()
        {
            var c = new Capture();

            using (Bitmap screenCap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height))
            {

                using (Graphics g = Graphics.FromImage(screenCap))
                { 
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     screenCap.Size,
                                     CopyPixelOperation.SourceCopy);

                }
                using (var ms = new MemoryStream())
                {
                    screenCap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    c.Image = ms.ToArray();
                }
            }


            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                try
                {
                    var form = Form.FromHandle(process.MainWindowHandle);
                    var r = form.RectangleToScreen(form.Bounds);
                    if (Screen.Bounds.Contains(r))
                    {
                        c.Areas.Add(new Capture.Area(process.ProcessName, form.Name, r.X, r.Y, r.Width, r.Height));
                    }
                }
                catch (Exception)
                {

                }
            }
            return c;
        }
    }
}
