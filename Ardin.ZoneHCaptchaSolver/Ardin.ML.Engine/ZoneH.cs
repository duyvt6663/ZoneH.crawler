﻿using Ardin.ML.Model;
// using CaptchaSolver.DrCaptcha.ir.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaptchaSolver.DrCaptcha.ir.Engine;
// using AForge.Imaging;

namespace Ardin.ML.Engine
{
    public static class ZoneH
    {
        public static string Solve(string captchaFilePath)
        {
            // System.Diagnostics.Debug.WriteLine("System doing well");
            var filtered = MethodsImageFilter.CopyBitmap(new Bitmap(captchaFilePath));
            filtered = MethodsImageFilter.RemoveAllColorsAndPlaceOnTheFinalImage(filtered);
            filtered = MethodsImageFilter.Closing(filtered);
            filtered = MethodsImageFilter.Invert(filtered);
            var blobs = MethodsImageFilter.GetBlob(filtered);
            // System.Diagnostics.Debug.WriteLine("hello");

            string code = string.Empty;
            for (int i = 0; i < blobs.Length; i++)
            {
                string filename = Path.GetTempFileName().Replace(".tmp", ".png");
                blobs[i].Save(filename);
                ModelInput sampleData = new ModelInput()
                {
                    ImageSource = filename
                };

                var predictionResult = ConsumeModel.Predict(sampleData);
                code += predictionResult.Prediction;
                File.Delete(filename);
            }
            return code;
        }
    }
}
