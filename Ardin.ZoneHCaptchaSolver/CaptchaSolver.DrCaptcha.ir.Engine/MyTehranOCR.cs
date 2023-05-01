// Decompiled with JetBrains decompiler
// Type: CaptchaSolver.DrCaptcha.ir.Engine.MyTehranOCR
// Assembly: CaptchaSolver.DrCaptcha.ir.Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5137520E-BE24-43F6-8B80-475BCC7CF233
// Assembly location: C:\Users\WIN\Documents\GitHub\Ardin.ZoneHCaptchaSolver\Ardin.ZoneHCaptchaSolver.Sample\Dependencies\CaptchaSolver.DrCaptcha.ir.Engine.dll

using AForge.Imaging;
using AForge.Imaging.Filters;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace CaptchaSolver.DrCaptcha.ir.Engine
{
  public class MyTehranOCR
  {
    private static int SmallerSize = 36;
    public static double Tolerance = 25.0;

    public string CaptchaDataPath { get; set; }

    public MyTehranOCR(string captchaDataPath) => this.CaptchaDataPath = captchaDataPath;

    public string OCR(Bitmap captcha)
    {
      Bitmap bitmap = MethodsImageFilter.Invert(MethodsImageFilter.Erosion(MethodsImageFilter.Opening(MethodsImageFilter.RemoveBlackPixelAloneVertical(MethodsImageFilter.RemoveBlackPixelAloneHorizontaly(MethodsImageFilter.Threshold220(MethodsImageFilter.RemoveColor(this.ConvertToJpg((System.Drawing.Image) captcha), "100", "000000")))))));
      BlobCounter blobCounter1 = new BlobCounter();
      blobCounter1.FilterBlobs = true;
      blobCounter1.ObjectsOrder = ObjectsOrder.XY;
      BlobCounter blobCounter2 = blobCounter1;
      blobCounter2.ProcessImage(bitmap);
      Blob[] objects = blobCounter2.GetObjects(bitmap, true);
      string empty = string.Empty;
      for (int index = 0; index < objects.Length; ++index)
      {
        try
        {
          int area = objects[index].Area;
          Bitmap captchaCode = MethodsImageFilter.Invert(new Crop(objects[index].Rectangle).Apply(bitmap));
          empty += this.OCR_Segment(captchaCode);
        }
        catch (Exception ex)
        {
        }
      }
      return empty;
    }

    private Bitmap ConvertToJpg(System.Drawing.Image image)
    {
      Bitmap jpg;
      using (Bitmap original = new Bitmap(image.Width, image.Height))
      {
        original.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using (Graphics graphics = Graphics.FromImage((System.Drawing.Image) original))
        {
          graphics.Clear(Color.White);
          graphics.DrawImageUnscaled(image, 0, 0);
        }
        jpg = new Bitmap((System.Drawing.Image) original);
      }
      return jpg;
    }

    private string OCR_Segment(Bitmap captchaCode)
    {
      Dictionary<string, double> source = new Dictionary<string, double>();
      DirectoryInfo directoryInfo = new DirectoryInfo(this.CaptchaDataPath);
      for (int index = 0; index <= 9; ++index)
      {
        try
        {
          foreach (FileInfo file in directoryInfo.GetFiles(index.ToString() + "_*"))
          {
            try
            {
              double num1 = this.CheckSimilarity(captchaCode, new Bitmap(file.FullName));
              if (source.Keys.Contains<string>(index.ToString()))
              {
                double num2 = source[index.ToString()];
                if (num1 > num2)
                  source[index.ToString()] = num1;
              }
              else
                source.Add(index.ToString(), num1);
            }
            catch (Exception ex)
            {
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
      return source.OrderByDescending<KeyValuePair<string, double>, double>((Func<KeyValuePair<string, double>, double>) (a => a.Value)).FirstOrDefault<KeyValuePair<string, double>>().Key.ToString();
    }

    private double CheckSimilarity(Bitmap captchaCode, Bitmap template)
    {
      double num = 0.0;
      try
      {
        System.Drawing.Image original1 = MyTehranOCR.Resize((System.Drawing.Image) captchaCode, MyTehranOCR.SmallerSize, MyTehranOCR.SmallerSize, false);
        System.Drawing.Image original2 = MyTehranOCR.Resize((System.Drawing.Image) template, MyTehranOCR.SmallerSize, MyTehranOCR.SmallerSize, false);
        Mat mat1 = BitmapConverter.ToMat(new Bitmap(original1));
        Mat mat2 = BitmapConverter.ToMat(new Bitmap(original2));
        num = MyTehranOCR.ComparePixels(mat1, mat2);
        ((DisposableObject) mat1).Dispose();
        ((DisposableObject) mat2).Dispose();
        Mat mat3 = BitmapConverter.ToMat(new Bitmap(original1));
        Mat mat4 = BitmapConverter.ToMat(new Bitmap(original2));
        MyTehranOCR.ComparePixelsDistance(mat3, mat4);
        ((DisposableObject) mat3).Dispose();
        ((DisposableObject) mat4).Dispose();
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    private static double ComparePixelsDistance(Mat image1, Mat image2)
    {
      image1 = MyTehranOCR.SmallerImage(image1);
      image2 = MyTehranOCR.SmallerImage(image2);
      if (image1 == null || image1.Empty() || image2 == null || image2.Empty())
        return 0.0;
      MatIndexer<Vec3b> byteVectorIndexer1 = MyTehranOCR.GetByteVectorIndexer(image1);
      MatIndexer<Vec3b> byteVectorIndexer2 = MyTehranOCR.GetByteVectorIndexer(image2);
      double num1 = 0.0;
      for (int index1 = 0; index1 < image1.Width; ++index1)
      {
        for (int index2 = 0; index2 < image1.Height; ++index2)
        {
          Vec3b vec3b1 = byteVectorIndexer1[index1, index2];
          Vec3b vec3b2 = byteVectorIndexer2[index1, index2];
          Color pixel1 = Color.FromArgb((int) vec3b1.Item2, (int) vec3b1.Item1, (int) vec3b1.Item0);
          Color pixel2 = Color.FromArgb((int) vec3b2.Item2, (int) vec3b2.Item1, (int) vec3b2.Item0);
          num1 += MyTehranOCR.Compare2Pixels_distance(pixel1, pixel2);
        }
      }
      double num2 = num1 / (double) (image1.Width * image1.Height);
      ((DisposableObject) image1).Dispose();
      ((DisposableObject) image2).Dispose();
      return num2;
    }

    private static double Compare2Pixels_distance(Color pixel1, Color pixel2)
    {
      long num1 = ((long) pixel1.R + (long) pixel2.R) / 2L;
      long num2 = (long) pixel1.R - (long) pixel2.R;
      long num3 = (long) pixel1.G - (long) pixel2.G;
      long num4 = (long) pixel1.B - (long) pixel2.B;
      return 100.0 - 100.0 * Math.Sqrt((double) (((512L + num1) * num2 * num2 >> 8) + 4L * num3 * num3 + ((767L - num1) * num4 * num4 >> 8))) / 764.833315173967;
    }

    private static double ComparePixels(Mat image1, Mat image2)
    {
      image1 = MyTehranOCR.SmallerImage(image1);
      image2 = MyTehranOCR.SmallerImage(image2);
      if (image1 == null || image1.Empty() || image2 == null || image2.Empty())
        return 0.0;
      double num1 = (double) image1.Width * (double) image1.Height;
      double num2 = 0.0;
      MatIndexer<Vec3b> byteVectorIndexer1 = MyTehranOCR.GetByteVectorIndexer(image1);
      MatIndexer<Vec3b> byteVectorIndexer2 = MyTehranOCR.GetByteVectorIndexer(image2);
      for (int index1 = 0; index1 < image1.Width; ++index1)
      {
        for (int index2 = 0; index2 < image1.Height; ++index2)
        {
          Vec3b vec3b1 = byteVectorIndexer1[index1, index2];
          Vec3b vec3b2 = byteVectorIndexer2[index1, index2];
          num2 += 0.0;
          if (MyTehranOCR.Compare2Pixels(Color.FromArgb((int) vec3b1.Item2, (int) vec3b1.Item1, (int) vec3b1.Item0), Color.FromArgb((int) vec3b2.Item2, (int) vec3b2.Item1, (int) vec3b2.Item0)) >= 100.0)
            ++num2;
        }
      }
      ((DisposableObject) image1).Dispose();
      ((DisposableObject) image2).Dispose();
      return 100.0 * (num2 / num1);
    }

    private static double Compare2Pixels(Color pixel1, Color pixel2)
    {
      double num = 0.0;
      if (Math.Abs((double) pixel1.R - (double) pixel2.R) <= MyTehranOCR.Tolerance && Math.Abs((double) pixel1.G - (double) pixel2.G) <= MyTehranOCR.Tolerance && Math.Abs((double) pixel1.B - (double) pixel2.B) <= MyTehranOCR.Tolerance)
        num = 100.0;
      return num;
    }

    private static MatIndexer<Vec3b> GetByteVectorIndexer(Mat image) => ((Mat<Vec3b, MatOfByte3>) new MatOfByte3(image)).GetIndexer();

    private static Mat SmallerImage(Mat image)
    {
      Size size;
      // ISSUE: explicit constructor call
      ((Size) ref size).\u002Ector(MyTehranOCR.SmallerSize, MyTehranOCR.SmallerSize);
      Mat mat = image;
      try
      {
        if (image.Width > MyTehranOCR.SmallerSize || image.Height > MyTehranOCR.SmallerSize || image.Width != image.Height)
          mat = image.Resize(size, 0.0, 0.0, (InterpolationFlags) 1);
      }
      catch (Exception ex)
      {
        return new Mat();
      }
      return mat;
    }

    private static System.Drawing.Image Resize(
      System.Drawing.Image originalImage,
      int maxWidth,
      int maxHeight,
      bool preserveRatio)
    {
      try
      {
        double num = Math.Min((double) maxWidth / (double) originalImage.Width, (double) maxHeight / (double) originalImage.Height);
        int width;
        int height;
        if (preserveRatio)
        {
          width = (int) ((double) originalImage.Width * num);
          height = (int) ((double) originalImage.Height * num);
        }
        else
        {
          width = maxWidth;
          height = maxHeight;
        }
        Bitmap bitmap = new Bitmap(width, height);
        using (Graphics graphics = Graphics.FromImage((System.Drawing.Image) bitmap))
        {
          graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
          graphics.PixelOffsetMode = PixelOffsetMode.Half;
          graphics.DrawImage(originalImage, 0, 0, width, height);
        }
        return (System.Drawing.Image) bitmap;
      }
      catch (Exception ex)
      {
        return originalImage;
      }
    }
  }
}
