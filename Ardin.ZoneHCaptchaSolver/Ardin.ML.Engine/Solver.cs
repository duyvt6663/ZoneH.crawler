using Ardin.ML.Model;
// using CaptchaSolver.DrCaptcha.ir.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaptchaSolver.DrCaptcha.ir.Engine;

namespace Ardin.ML.Engine
{
    public static class Solver
    {
        public static string Solve(string captchaPath)
        {
            try
            {
                var filtered = MethodsImageFilter.CopyBitmap(new Bitmap(captchaPath));
                filtered = MethodsImageFilter.RemoveAllColorsAndPlaceOnTheFinalImage(filtered);
                filtered = MethodsImageFilter.Closing(filtered);
                // Console.Write("Press  to exit... ");
                filtered = MethodsImageFilter.Invert(filtered);
                // Console.Write("Press  to exit... ");
                var blobs = MethodsImageFilter.GetBlob(filtered);

                string code = string.Empty;
                // Console.Write("Press  to exit... ");
                for (int i = 0; i < blobs.Length; i++)
                {
                    string filename = Guid.NewGuid() + ".png";
                    string imgSource = "c:\\temp\\" + filename;
                    Console.Write("Press  to exit... ");
                    blobs[i].Save(imgSource);
                    ModelInput sampleData = new ModelInput()
                    {
                        ImageSource = imgSource
                    };

                    var predictionResult = ConsumeModel.Predict(sampleData);
                    code += predictionResult.Prediction;
                }
                return code;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
