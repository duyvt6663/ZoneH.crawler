using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ardin.ZoneHCaptchaSolver.Sample
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            // Application.SetHighDpiMode(HighDpiMode.SystemAware);
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmMain());
            // System.Windows.Forms.PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
            if (args.Length == 1){
                string url = $"C:\\Users\\WIN\\Documents\\GitHub\\Ardin.ZoneHCaptchaSolver\\CaptchaSamples\\captcha{args[0]}.png";
                string solpath = @"C:\Users\WIN\Documents\GitHub\zone-h.org-website-grabber\Res.txt";
                string result = ML.Engine.ZoneH.Solve(url);
                
                System.Diagnostics.Debug.WriteLine(result);
                File.WriteAllText(solpath, result);
            }
        }
    }
}
