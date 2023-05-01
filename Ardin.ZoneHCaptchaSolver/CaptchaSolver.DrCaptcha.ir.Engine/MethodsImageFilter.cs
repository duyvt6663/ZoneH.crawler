// Decompiled with JetBrains decompiler
// Type: CaptchaSolver.DrCaptcha.ir.Engine.MethodsImageFilter
// Assembly: CaptchaSolver.DrCaptcha.ir.Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5137520E-BE24-43F6-8B80-475BCC7CF233
// Assembly location: C:\Users\WIN\Documents\GitHub\Ardin.ZoneHCaptchaSolver\Ardin.ZoneHCaptchaSolver.Sample\Dependencies\CaptchaSolver.DrCaptcha.ir.Engine.dll

using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace CaptchaSolver.DrCaptcha.ir.Engine
{
  public class MethodsImageFilter
  {
    public static Bitmap CopyBitmap(Bitmap source) => new Bitmap((System.Drawing.Image) source);

    [ImageFilter("Remove Border", ImageFilterAttribute.FilterType.Normal, "حذف لبه ها", "RemoveBorder")]
    public static Bitmap RemoveBorder(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (x < Image.Width - 1 & y <= 7)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < Image.Width - 1 & y >= Image.Height - 7)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < 7 & y < Image.Height - 1)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x >= Image.Width - 1 & y <= Image.Height - 1)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Border TRT21", ImageFilterAttribute.FilterType.Normal, "حذف لبه ها به روش TRT21", "RemoveBorderTRT21")]
    public static Bitmap RemoveBorderTRT21(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (x < Image.Width - 1 & y <= 4)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < Image.Width - 1 & y >= Image.Height - 7)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < 7 & y < Image.Height - 1)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x >= Image.Width - 7 & y <= Image.Height - 1)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Border TRF4", ImageFilterAttribute.FilterType.Normal, "حذف لبه ها به روش TRF4", "RemoveBorderTRF4")]
    public static Bitmap RemoveBorderTRF4(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (x < Image.Width - 1 & y <= 7)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < Image.Width - 1 & y >= Image.Height - 5)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < 7 & y < Image.Height - 5)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x >= Image.Width - 10 & y <= Image.Height - 5)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Border Bottom", ImageFilterAttribute.FilterType.Normal, "حذف لبه ی پایین", "RemoveBorderBottom")]
    public static Bitmap RemoveBorderBottom(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (x == 0 || y == 0)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x == Image.Width - 1 || y == Image.Height - 1)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Border Top", ImageFilterAttribute.FilterType.Normal, "حذف لبه ی بالا", "RemoveBorderTop")]
    public static Bitmap RemoveBorderTop(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (x < Image.Width - 1 & y <= 12)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < Image.Width - 1 & y >= Image.Height - 3)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < 7 & y < Image.Height - 5)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x >= Image.Width - 10 & y <= Image.Height - 5)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Currect Transparency", ImageFilterAttribute.FilterType.Normal, "تصحیح شفافیت ", "CurrectTransparency")]
    public static void CurrectTransparency(Bitmap Image, string fileName)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      using (Bitmap bitmap = new Bitmap(Image.Width, Image.Height))
      {
        bitmap.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);
        using (Graphics graphics = Graphics.FromImage((System.Drawing.Image) bitmap))
        {
          graphics.Clear(Color.White);
          graphics.DrawImageUnscaled((System.Drawing.Image) Image, 0, 0);
        }
        if (fileName.Contains(".png"))
        {
          bitmap.Save(fileName.Replace(".png", ".bmp"), ImageFormat.Bmp);
        }
        else
        {
          if (!fileName.Contains(".jpg"))
            return;
          bitmap.Save(fileName.Replace(".jpg", ".bmp"), ImageFormat.Bmp);
        }
      }
    }

    [ImageFilter("Remove Black Pixel Horizontaly", ImageFilterAttribute.FilterType.Normal, "حذف پیکسل های سیاه به صورت افقی", "FA_RemoveBlackPixelHorizontaly")]
    public static Bitmap FA_RemoveBlackPixelHorizontaly(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (x + 1 <= Image.Width - 1)
            color1 = Image.GetPixel(x + 1, y);
          if (x - 1 >= 0)
            color2 = Image.GetPixel(x - 1, y);
          if (y + 1 <= Image.Height - 1)
            color3 = Image.GetPixel(x, y + 1);
          if (y - 1 >= 0)
            color4 = Image.GetPixel(x, y - 1);
          if (color2.R == byte.MaxValue & color2.G == byte.MaxValue & color2.B == byte.MaxValue & color1.R == byte.MaxValue & color1.G == byte.MaxValue & color1.B == byte.MaxValue & pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0 & (color3.R == byte.MaxValue & color3.G == byte.MaxValue & color3.B == byte.MaxValue | color4.R == byte.MaxValue & color4.G == byte.MaxValue & color4.B == byte.MaxValue))
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Black Pixel Verticaly", ImageFilterAttribute.FilterType.Normal, "حذف پیکسل های سیاه به صورت عمودی", "FA_RemoveBlackPixelVerticaly")]
    public static Bitmap FA_RemoveBlackPixelVerticaly(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (y + 1 <= Image.Height - 1)
            color1 = Image.GetPixel(x, y + 1);
          if (y - 1 >= 0)
            color2 = Image.GetPixel(x, y - 1);
          if (x + 1 <= Image.Width - 1)
            color3 = Image.GetPixel(x + 1, y);
          if (x - 1 >= 0)
            color4 = Image.GetPixel(x - 1, y);
          if (color2.R == byte.MaxValue & color2.G == byte.MaxValue & color2.B == byte.MaxValue & color1.R == byte.MaxValue & color1.G == byte.MaxValue & color1.B == byte.MaxValue & pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0 & (color3.R == byte.MaxValue & color3.G == byte.MaxValue & color3.B == byte.MaxValue | color4.R == byte.MaxValue & color4.G == byte.MaxValue & color4.B == byte.MaxValue))
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Paint White Among Blacks", ImageFilterAttribute.FilterType.Normal, "کشیدن سفید در میان سیاه", "PaintWhiteAmongBlacks")]
    public static Bitmap PaintWhiteAmongBlacks(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int y = 0; y <= Image.Height - 1; ++y)
      {
        for (int x = 0; x <= Image.Width - 1; ++x)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          if (y + 1 <= Image.Height - 1)
            color1 = Image.GetPixel(x, y + 1);
          if (y - 1 > 0)
            color2 = Image.GetPixel(x, y - 1);
          if (color2.R == (byte) 0 & color2.G == (byte) 0 & color2.B == (byte) 0 & color1.R == (byte) 0 & color1.G == (byte) 0 & color1.B == (byte) 0 & pixel.R == byte.MaxValue & pixel.G == byte.MaxValue & pixel.B == byte.MaxValue)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, 0, 0, 0));
        }
      }
      return Image;
    }

    [ImageFilter("Paint Pixel Black Among White", ImageFilterAttribute.FilterType.Normal, "کشیدن پیکسل سیاه در میان سفید", "PaintPixelBlackAmongWhite")]
    public static Bitmap PaintPixelBlackAmongWhite(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Color color = new Color();
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if ((int) pixel.R + (int) pixel.G + (int) pixel.B > 210)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          else
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, 0, 0, 0));
        }
      }
      return Image;
    }

    [ImageFilter("Paint Pixel Black Among White 2", ImageFilterAttribute.FilterType.Normal, "کشیدن پیکسل سیاه در میان سفید - 2", "PaintPixelBlackAmongWhite2")]
    public static Bitmap PaintPixelBlackAmongWhite2(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Color color = new Color();
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (pixel.R >= (byte) 80 || pixel.G >= (byte) 80 || pixel.B >= (byte) 80)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          else
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, 0, 0, 0));
        }
      }
      return Image;
    }

    [ImageFilter("Thicker Black Line", ImageFilterAttribute.FilterType.Normal, "خطوط سیاه ضخیم تر", "ThickerBlackLine")]
    public static Bitmap ThickerBlackLine(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel1 = Image.GetPixel(x, y);
          if (x - 1 > 0 && pixel1.R == (byte) 0 | pixel1.G == (byte) 0 | pixel1.B == (byte) 0)
          {
            Color pixel2 = Image.GetPixel(x - 1, y);
            if (pixel2.R == byte.MaxValue & pixel2.G == byte.MaxValue & pixel2.B == byte.MaxValue)
              Image.SetPixel(x - 1, y, Color.FromArgb((int) pixel1.A, 0, 0, 0));
          }
        }
      }
      return Image;
    }

    [ImageFilter("Remove Pixel Alone", ImageFilterAttribute.FilterType.Normal, "حذف رنگ های تنها", "RemovePixelAlone")]
    public static Bitmap RemovePixelAlone(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (x + 1 <= Image.Width - 1)
            color1 = Image.GetPixel(x + 1, y);
          if (x - 1 >= 0)
            color2 = Image.GetPixel(x - 1, y);
          if (y + 1 <= Image.Height - 1)
            color3 = Image.GetPixel(x, y + 1);
          if (y - 1 >= 0)
            color4 = Image.GetPixel(x, y - 1);
          if (color2.R == byte.MaxValue & color2.G == byte.MaxValue & color2.B == byte.MaxValue && color1.R == byte.MaxValue & color1.G == byte.MaxValue & color1.B == byte.MaxValue && color3.R == byte.MaxValue & color3.G == byte.MaxValue & color3.B == byte.MaxValue && color4.R == byte.MaxValue & color4.G == byte.MaxValue & color4.B == byte.MaxValue && pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove All Colors And Place On The Final Image", ImageFilterAttribute.FilterType.Normal, "حذف همه ی رنگ ها و قراردادن آنها در تصویر نهایی", "RemoveAllColorsAndPlaceOnTheFinalImage")]
    public static Bitmap RemoveAllColorsAndPlaceOnTheFinalImage(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Bitmap bitmap1 = new Bitmap(Image.Width, Image.Height);
      Bitmap bitmap2 = new Bitmap(Image.Width, Image.Height);
      Bitmap bitmap3 = new Bitmap(Image.Width, Image.Height);
      Color color1 = new Color();
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          color1 = Image.GetPixel(x, y);
          if (color1.R == (byte) 0 & color1.G == (byte) 0 & color1.B == (byte) 0 | color1.R == byte.MaxValue & color1.G == byte.MaxValue & color1.B == byte.MaxValue)
            bitmap1.SetPixel(x, y, Color.FromArgb((int) color1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          else
            bitmap1.SetPixel(x, y, Color.FromArgb((int) color1.A, 0, 0, 0));
        }
      }
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          color1 = Image.GetPixel(x, y);
          if (color1.R < (byte) 10 & color1.G < (byte) 10 & color1.B < (byte) 10)
            bitmap2.SetPixel(x, y, Color.FromArgb((int) color1.A, 0, 0, 0));
          else
            bitmap2.SetPixel(x, y, Color.FromArgb((int) color1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      Color color2 = new Color();
      Color color3 = new Color();
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          if (bitmap1.GetPixel(x, y).R == (byte) 0 | bitmap2.GetPixel(x, y).R == (byte) 0)
            bitmap3.SetPixel(x, y, Color.FromArgb((int) color1.A, 0, 0, 0));
          else
            bitmap3.SetPixel(x, y, Color.FromArgb((int) color1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return bitmap3;
    }

    [ImageFilter("RemoveBlackPixelAloneHorizontaly", ImageFilterAttribute.FilterType.Normal, "حذف پیکسل سیاه تنها به صورت افقی", "RemoveBlackPixelAloneHorizontaly")]
    public static Bitmap RemoveBlackPixelAloneHorizontaly(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (x + 1 <= Image.Width - 1)
            color1 = Image.GetPixel(x + 1, y);
          if (x - 1 >= 0)
            color2 = Image.GetPixel(x - 1, y);
          if (y + 1 <= Image.Height - 1)
            color3 = Image.GetPixel(x, y + 1);
          if (y - 1 >= 0)
            color4 = Image.GetPixel(x, y - 1);
          if (color2.R == byte.MaxValue & color2.G == byte.MaxValue & color2.B == byte.MaxValue & color1.R == byte.MaxValue & color1.G == byte.MaxValue & color1.B == byte.MaxValue & pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Border RS", ImageFilterAttribute.FilterType.Normal, "حذف لبه RS", "RemoveBorderRS")]
    public static Bitmap RemoveBorderRS(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if (x < Image.Width - 1 & y <= 3)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < Image.Width - 1 & y >= Image.Height - 3)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x < 10 & y < Image.Height)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          if (x >= Image.Width - 10 & y <= Image.Height)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Paint Black Pixel In White TRT17", ImageFilterAttribute.FilterType.Normal, "کشیدن پیکسل سیاه در سفید به روش TRT17", "PaintBlackPixelInWhiteTRT17")]
    public static Bitmap PaintBlackPixelInWhiteTRT17(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Color color = new Color();
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if ((int) pixel.R + (int) pixel.G + (int) pixel.B > 150)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          else
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, 0, 0, 0));
        }
      }
      return Image;
    }

    [ImageFilter("Clear 2 PX", ImageFilterAttribute.FilterType.Normal, "حذف 2 پیکسل", "Clear2PX")]
    public static Bitmap Clear2PX(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int y = 10; y <= Image.Height - 5; ++y)
      {
        for (int x = 10; x <= Image.Width - 5; ++x)
        {
          Color pixel1 = Image.GetPixel(x, y);
          Color pixel2 = Image.GetPixel(x, y - 1);
          Color pixel3 = Image.GetPixel(x, y - 2);
          Color pixel4 = Image.GetPixel(x, y + 1);
          if ((pixel1.R == (byte) 0 || pixel1.G == (byte) 0 || pixel1.B == (byte) 0) && (pixel2.R == (byte) 0 || pixel2.G == (byte) 0 || pixel2.B == (byte) 0) && (pixel4.R == byte.MaxValue || pixel4.G == byte.MaxValue || pixel4.B == byte.MaxValue) && (pixel3.R == byte.MaxValue || pixel3.G == byte.MaxValue || pixel3.B == byte.MaxValue))
          {
            Image.SetPixel(x, y, Color.FromArgb((int) pixel1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
            Image.SetPixel(x, y - 1, Color.FromArgb((int) pixel1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
        }
      }
      for (int y = 10; y <= Image.Height - 10; ++y)
      {
        for (int x = 10; x <= Image.Width - 10; ++x)
        {
          Color pixel5 = Image.GetPixel(x, y);
          Color pixel6 = Image.GetPixel(x - 1, y);
          Color pixel7 = Image.GetPixel(x - 2, y);
          Color pixel8 = Image.GetPixel(x + 1, y);
          if ((pixel5.R == (byte) 0 || pixel5.G == (byte) 0 || pixel5.B == (byte) 0) && (pixel6.R == (byte) 0 || pixel6.G == (byte) 0 || pixel6.B == (byte) 0) && (pixel8.R == byte.MaxValue || pixel8.G == byte.MaxValue || pixel8.B == byte.MaxValue) && (pixel7.R == byte.MaxValue || pixel7.G == byte.MaxValue || pixel7.B == byte.MaxValue))
          {
            Image.SetPixel(x, y, Color.FromArgb((int) pixel5.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
            Image.SetPixel(x, y - 1, Color.FromArgb((int) pixel5.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
        }
      }
      return Image;
    }

    [ImageFilter("Take Blue", ImageFilterAttribute.FilterType.Normal, "گرفتن آبی", "TakeBlue")]
    public static Bitmap TakeBlue(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Color color = new Color();
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          if ((pixel.R != (byte) 0 || pixel.G != (byte) 0 || pixel.B != (byte) 0) && (int) pixel.B <= (int) pixel.G + 35 && (int) pixel.B <= (int) pixel.R + 35)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Black Pixel Alone Vertical", ImageFilterAttribute.FilterType.Normal, "حذف پیکسل سیاه تنها به صورت عمودی", "RemoveBlackPixelAloneVertical")]
    public static Bitmap RemoveBlackPixelAloneVertical(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (x + 1 <= Image.Width - 1)
            color1 = Image.GetPixel(x + 1, y);
          if (x - 1 >= 0)
            color2 = Image.GetPixel(x - 1, y);
          if (y + 1 <= Image.Height - 1)
            color3 = Image.GetPixel(x, y + 1);
          if (y - 1 >= 0)
            color4 = Image.GetPixel(x, y - 1);
          if (color3.R == byte.MaxValue & color3.G == byte.MaxValue & color3.B == byte.MaxValue & color4.R == byte.MaxValue & color4.G == byte.MaxValue & color4.B == byte.MaxValue & pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0)
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      return Image;
    }

    [ImageFilter("Remove Black Pixel Between White 2 Horizontal", ImageFilterAttribute.FilterType.Normal, "حذف پیکسل سیاه بین سفید 2 افقی", "RemoveBlackPixelBetweenWhite2Horizontal")]
    public static Bitmap RemoveBlackPixelBetweenWhite2Horizontal(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (x + 1 <= Image.Width - 1)
            color1 = Image.GetPixel(x + 1, y);
          if (x + 2 <= Image.Width - 1)
            color2 = Image.GetPixel(x + 2, y);
          if (x - 1 >= 0)
            color3 = Image.GetPixel(x - 1, y);
          if (x - 2 >= 0)
            color4 = Image.GetPixel(x - 2, y);
          if (pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0 & color1.R == (byte) 0 & color1.G == (byte) 0 & color1.B == (byte) 0 & color2.R == byte.MaxValue & color2.G == byte.MaxValue & color2.B == byte.MaxValue & color3.R == byte.MaxValue & color3.G == byte.MaxValue & color3.B == byte.MaxValue)
          {
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
            Image.SetPixel(x + 1, y, Color.FromArgb((int) color1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
        }
      }
      return Image;
    }

    [ImageFilter("Remove Black Pixel Between White 3 Horizontal", ImageFilterAttribute.FilterType.Normal, "حذف پیکسل سیاه بین سفید 3 افقی", "RemoveBlackPixelBetweenWhite3Horizontal")]
    public static Bitmap RemoveBlackPixelBetweenWhite3Horizontal(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 1; ++x)
      {
        for (int y = 0; y <= Image.Height - 1; ++y)
        {
          Color pixel = Image.GetPixel(x, y);
          Color color1 = new Color();
          Color color2 = new Color();
          Color color3 = new Color();
          Color color4 = new Color();
          if (x + 1 <= Image.Width - 1)
            color1 = Image.GetPixel(x + 1, y);
          if (x + 2 <= Image.Width - 1)
            color2 = Image.GetPixel(x + 2, y);
          if (x - 1 >= 0)
            color3 = Image.GetPixel(x - 1, y);
          if (x - 2 >= 0)
            color4 = Image.GetPixel(x - 2, y);
          if (pixel.R == (byte) 0 & pixel.G == (byte) 0 & pixel.B == (byte) 0 & color1.R == (byte) 0 & color1.G == (byte) 0 & color1.B == (byte) 0 & color3.R == (byte) 0 & color3.G == (byte) 0 & color3.B == (byte) 0 & color4.R == byte.MaxValue & color4.G == byte.MaxValue & color4.B == byte.MaxValue & color2.R == byte.MaxValue & color2.G == byte.MaxValue & color2.B == byte.MaxValue)
          {
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
            Image.SetPixel(x + 1, y, Color.FromArgb((int) color1.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
            Image.SetPixel(x + 2, y, Color.FromArgb((int) color2.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
        }
      }
      return Image;
    }

    [ImageFilter("Remove Ball", ImageFilterAttribute.FilterType.Normal, "حذف توپ ها", "RemoveBall")]
    public static Bitmap RemoveBall(Bitmap Image)
    {
      Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      for (int x = 0; x <= Image.Width - 2; ++x)
      {
        for (int y = 0; y <= Image.Height - 2; ++y)
        {
          if (x >= 10 && x <= 16 && y >= 8 && y <= 13)
          {
            Color pixel = Image.GetPixel(x, y);
            Image.SetPixel(x, y, Color.FromArgb((int) pixel.A, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
        }
      }
      return Image;
    }

    [ImageFilter("Gray Scale", ImageFilterAttribute.FilterType.Normal, "مقیاس خاکستری", "GrayScale")]
    public static unsafe Bitmap GrayScale(Bitmap b)
    {
      BitmapData bitmapdata = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      int stride = bitmapdata.Stride;
      byte* scan0 = (byte*) (void*) bitmapdata.Scan0;
      int num1 = stride - b.Width * 3;
      for (int index1 = 0; index1 < b.Height; ++index1)
      {
        for (int index2 = 0; index2 < b.Width; ++index2)
        {
          byte num2 = *scan0;
          byte num3 = scan0[1];
          byte num4 = scan0[2];
          *scan0 = (byte) (*(sbyte*) (scan0 + 1) = *(sbyte*) (scan0 + 2) = (sbyte) (byte) (0.299 * (double) num4 + 0.587 * (double) num3 + 0.114 * (double) num2));
          scan0 += 3;
        }
        scan0 += num1;
      }
      b.UnlockBits(bitmapdata);
      return b;
    }

    [ImageFilter("Threshold220", ImageFilterAttribute.FilterType.Normal, "آستانه 220", "Threshold220")]
    public static unsafe Bitmap Threshold220(Bitmap b)
    {
      bool flag = true;
      BitmapData bitmapdata = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      int stride = bitmapdata.Stride;
      IntPtr scan0 = bitmapdata.Scan0;
      int num1 = 220;
      byte* numPtr = (byte*) (void*) scan0;
      int num2 = stride - b.Width * 3;
      for (int index1 = 0; index1 < b.Height; ++index1)
      {
        for (int index2 = 0; index2 < b.Width; ++index2)
        {
          byte num3 = *numPtr;
          byte num4 = numPtr[1];
          byte num5 = (byte) (0.299 * (double) numPtr[2] + 0.587 * (double) num4 + 0.114 * (double) num3);
          if ((int) num5 < num1 & flag)
            *numPtr = (byte) (*(sbyte*) (numPtr + 1) = *(sbyte*) (numPtr + 2) = (sbyte) 0);
          else if ((int) num5 >= num1 & flag)
          {
            *numPtr = (byte) (*(sbyte*) (numPtr + 1) = *(sbyte*) (numPtr + 2) = (sbyte) -1);
          }
          else
          {
            int num6 = (int) num5 >= num1 ? 0 : (!flag ? 1 : 0);
            *numPtr = num6 == 0 ? (byte) (*(sbyte*) (numPtr + 1) = *(sbyte*) (numPtr + 2) = (sbyte) 0) : (byte) (*(sbyte*) (numPtr + 1) = *(sbyte*) (numPtr + 2) = (sbyte) -1);
          }
          numPtr += 3;
        }
        numPtr += num2;
      }
      b.UnlockBits(bitmapdata);
      return b;
    }

    [ImageFilter("Noise Removal", ImageFilterAttribute.FilterType.Normal, "حذف نویز", "NoiseRemoval")]
    public static unsafe Bitmap NoiseRemoval(Bitmap IntensityImage)
    {
      Bitmap bitmap = (Bitmap) IntensityImage.Clone();
      BitmapData bitmapdata1 = IntensityImage.LockBits(new Rectangle(0, 0, IntensityImage.Width, IntensityImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      BitmapData bitmapdata2 = bitmap.LockBits(new Rectangle(0, 0, IntensityImage.Width, IntensityImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      int stride = bitmapdata1.Stride;
      IntPtr scan0_1 = bitmapdata1.Scan0;
      IntPtr scan0_2 = bitmapdata2.Scan0;
      byte* numPtr1 = (byte*) (void*) scan0_1;
      byte* numPtr2 = (byte*) (void*) scan0_2;
      int num1 = stride - IntensityImage.Width * 3;
      int num2 = IntensityImage.Width * 3;
      byte* numPtr3 = numPtr1 + stride;
      byte* numPtr4 = numPtr2 + stride;
      for (int index1 = 1; index1 < IntensityImage.Height - 1; ++index1)
      {
        byte* numPtr5 = numPtr3 + 3;
        byte* numPtr6 = numPtr4 + 3;
        for (int index2 = 3; index2 < num2 - 3; ++index2)
        {
          byte num3 = *numPtr6;
          if (num3 == (byte) 0)
          {
            int num4 = numPtr6[3] == (byte) 0 || *(numPtr6 - 3) == (byte) 0 || numPtr6[stride] == (byte) 0 || *(numPtr6 - stride) == (byte) 0 || (int) (numPtr6 + stride)[3] == (int) num3 || *(numPtr6 + stride - 3) == (byte) 0 || *(numPtr6 - stride - 3) == (byte) 0 ? 1 : ((numPtr6 + stride)[3] == (byte) 0 ? 1 : 0);
            *numPtr5 = num4 == 0 ? byte.MaxValue : num3;
          }
          ++numPtr5;
          ++numPtr6;
        }
        numPtr3 = numPtr5 + (num1 + 3);
        numPtr4 = numPtr6 + (num1 + 3);
      }
      IntensityImage.UnlockBits(bitmapdata1);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    [ImageFilter("Noise Removal 2", ImageFilterAttribute.FilterType.Normal, "حذف نویز 2", "NoiseRemoval2")]
    public static Bitmap NoiseRemoval2(Bitmap Image)
    {
      int num1 = 5;
      Bitmap bitmap1 = Image;
      Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
      Graphics graphics = Graphics.FromImage((System.Drawing.Image) bitmap2);
      graphics.DrawImage((System.Drawing.Image) bitmap1, new Rectangle(0, 0, bitmap1.Width, bitmap1.Height), new Rectangle(0, 0, bitmap1.Width, bitmap1.Height), GraphicsUnit.Pixel);
      graphics.Dispose();
      Random random = new Random();
      int num2 = -(num1 / 2);
      int num3 = num1 / 2;
      for (int x1 = 0; x1 < bitmap2.Width; ++x1)
      {
        for (int y1 = 0; y1 < bitmap2.Height; ++y1)
        {
          List<int> intList1 = new List<int>();
          List<int> intList2 = new List<int>();
          List<int> intList3 = new List<int>();
          for (int index1 = num2; index1 < num3; ++index1)
          {
            int x2 = x1 + index1;
            if (x2 >= 0 && x2 < bitmap2.Width)
            {
              for (int index2 = num2; index2 < num3; ++index2)
              {
                int y2 = y1 + index2;
                if (y2 >= 0 && y2 < bitmap2.Height)
                {
                  Color pixel = bitmap1.GetPixel(x2, y2);
                  intList1.Add((int) pixel.R);
                  intList2.Add((int) pixel.G);
                  intList3.Add((int) pixel.B);
                }
              }
            }
          }
          intList1.Sort();
          intList2.Sort();
          intList3.Sort();
          Color color = Color.FromArgb(intList1[intList1.Count / 2], intList2[intList2.Count / 2], intList3[intList3.Count / 2]);
          bitmap2.SetPixel(x1, y1, color);
        }
      }
      return bitmap2;
    }

    [ImageFilter("Noise Removal 3", ImageFilterAttribute.FilterType.Normal, "حذف نویز 3", "NoiseRemoval3")]
    public static Bitmap NoiseRemoval3(Bitmap image)
    {
      int x = 0;
      int y = 0;
      while (MethodsImageFilter.IsBlobs(ref image, x, y))
      {
        for (int index1 = 0; index1 < image.Width; ++index1)
        {
          x = index1;
          for (int index2 = 0; index2 < image.Height; ++index2)
            y = index2;
        }
      }
      return image;
    }

    private static bool IsBlobs(ref Bitmap image, int x, int y)
    {
      Dictionary<int, int> dictionary = new Dictionary<int, int>();
      return true;
    }

    [ImageFilter("Blur", ImageFilterAttribute.FilterType.AForge, "محو سازی", "Blur")]
    public static Bitmap Blur(Bitmap Image)
    {
      AForge.Imaging.Filters.Blur blur = new AForge.Imaging.Filters.Blur();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = blur.Apply(Image);
      return Image;
    }

    [ImageFilter("Brightness Correction", ImageFilterAttribute.FilterType.AForge, "تصحیح روشنایی", "BrightnessCorrection")]
    public static Bitmap BrightnessCorrection(Bitmap Image)
    {
      AForge.Imaging.Filters.BrightnessCorrection brightnessCorrection = new AForge.Imaging.Filters.BrightnessCorrection();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = brightnessCorrection.Apply(Image);
      return Image;
    }

    [ImageFilter("Contrast Correction", ImageFilterAttribute.FilterType.AForge, "تصحیح کنتراست", "ContrastCorrection")]
    public static Bitmap ContrastCorrection(Bitmap Image)
    {
      AForge.Imaging.Filters.ContrastCorrection contrastCorrection = new AForge.Imaging.Filters.ContrastCorrection();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = contrastCorrection.Apply(Image);
      return Image;
    }

    [ImageFilter("Saturation Correction", ImageFilterAttribute.FilterType.AForge, "تصحیح اشباع", "SaturationCorrection")]
    public static Bitmap SaturationCorrection(Bitmap Image)
    {
      AForge.Imaging.Filters.SaturationCorrection saturationCorrection = new AForge.Imaging.Filters.SaturationCorrection();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = saturationCorrection.Apply(Image);
      return Image;
    }

    [ImageFilter("Closing", ImageFilterAttribute.FilterType.AForge, "بسته سازی", "Closing")]
    public static Bitmap Closing(Bitmap Image)
    {
      AForge.Imaging.Filters.Closing closing = new AForge.Imaging.Filters.Closing();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = closing.Apply(Image);
      return Image;
    }

    [ImageFilter("Dilatation", ImageFilterAttribute.FilterType.AForge, "تکمیل سازی", "Dilatation")]
    public static Bitmap Dilatation(Bitmap Image)
    {
      AForge.Imaging.Filters.Dilatation dilatation = new AForge.Imaging.Filters.Dilatation();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = dilatation.Apply(Image);
      return Image;
    }

    [ImageFilter("Erosion", ImageFilterAttribute.FilterType.AForge, "فرسایش سازی", "Erosion")]
    public static Bitmap Erosion(Bitmap Image)
    {
      AForge.Imaging.Filters.Erosion erosion = new AForge.Imaging.Filters.Erosion();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = erosion.Apply(Image);
      return Image;
    }

    [ImageFilter("Blobs Filtering", ImageFilterAttribute.FilterType.AForge, "فیلترکردن حباب ها", "BlobsFiltering")]
    public static Bitmap BlobsFiltering(Bitmap Image)
    {
      AForge.Imaging.Filters.BlobsFiltering blobsFiltering = new AForge.Imaging.Filters.BlobsFiltering();
      blobsFiltering.CoupledSizeFiltering = true;
      blobsFiltering.MinWidth = 10;
      blobsFiltering.MinHeight = 10;
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = blobsFiltering.Apply(Image);
      return Image;
    }

    [ImageFilter("Median2", ImageFilterAttribute.FilterType.AForge, "متوسط سازی - 2", "Median2")]
    public static Bitmap Median2(Bitmap Image)
    {
      AForge.Imaging.Filters.Median median = new AForge.Imaging.Filters.Median(2);
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = median.Apply(Image);
      return Image;
    }

    [ImageFilter("Opening", ImageFilterAttribute.FilterType.AForge, "بازکردن", "Opening")]
    public static Bitmap Opening(Bitmap Image)
    {
      AForge.Imaging.Filters.Opening opening = new AForge.Imaging.Filters.Opening();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = opening.Apply(Image);
      return Image;
    }

    [ImageFilter("Mean", ImageFilterAttribute.FilterType.AForge, "متوسط سازی", "Mean")]
    public static Bitmap Mean(Bitmap Image)
    {
      AForge.Imaging.Filters.Mean mean = new AForge.Imaging.Filters.Mean();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = mean.Apply(Image);
      return Image;
    }

    [ImageFilter("Bilateral Smoothing", ImageFilterAttribute.FilterType.AForge, "صاف کردن دوطرفه", "BilateralSmoothing")]
    public static Bitmap BilateralSmoothing(Bitmap Image)
    {
      AForge.Imaging.Filters.BilateralSmoothing bilateralSmoothing = new AForge.Imaging.Filters.BilateralSmoothing();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = bilateralSmoothing.Apply(Image);
      return Image;
    }

    [ImageFilter("Invert", ImageFilterAttribute.FilterType.AForge, "معکوس کردن", "Invert")]
    public static Bitmap Invert(Bitmap Image)
    {
      AForge.Imaging.Filters.Invert invert = new AForge.Imaging.Filters.Invert();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = invert.Apply(Image);
      return Image;
    }

    public static Bitmap Convolution(Bitmap Image, int[,] kernel)
    {
      AForge.Imaging.Filters.Convolution convolution = new AForge.Imaging.Filters.Convolution(kernel);
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = convolution.Apply(Image);
      return Image;
    }

    public static Bitmap Convolution(Bitmap Image, int[,] kernel, int divisor)
    {
      AForge.Imaging.Filters.Convolution convolution = new AForge.Imaging.Filters.Convolution(kernel, divisor);
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = convolution.Apply(Image);
      return Image;
    }

    [ImageFilter("Gaussian Sharpen", ImageFilterAttribute.FilterType.AForge, "تیزکردن گاوسی", "GaussianSharpen")]
    public static Bitmap GaussianSharpen(Bitmap Image)
    {
      AForge.Imaging.Filters.GaussianSharpen gaussianSharpen = new AForge.Imaging.Filters.GaussianSharpen();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = gaussianSharpen.Apply(Image);
      return Image;
    }

    [ImageFilter("Median", ImageFilterAttribute.FilterType.AForge, "متوسط سازی", "Median")]
    public static Bitmap Median(Bitmap Image)
    {
      AForge.Imaging.Filters.Median median = new AForge.Imaging.Filters.Median();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = median.Apply(Image);
      return Image;
    }

    [ImageFilter("Sharpen", ImageFilterAttribute.FilterType.AForge, "تیز کردن", "Sharpen")]
    public static Bitmap Sharpen(Bitmap Image)
    {
      AForge.Imaging.Filters.Sharpen sharpen = new AForge.Imaging.Filters.Sharpen();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = sharpen.Apply(Image);
      return Image;
    }

    public static Bitmap ResizeNearestNeighbor(Bitmap Image, int newWidth, int newHeight)
    {
      AForge.Imaging.Filters.ResizeNearestNeighbor resizeNearestNeighbor = new AForge.Imaging.Filters.ResizeNearestNeighbor(newWidth, newHeight);
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = resizeNearestNeighbor.Apply(Image);
      return Image;
    }

    [ImageFilter("Shrink", ImageFilterAttribute.FilterType.AForge, "کوچک کردن", "Shrink")]
    public static Bitmap Shrink(Bitmap Image)
    {
      AForge.Imaging.Filters.Shrink shrink = new AForge.Imaging.Filters.Shrink();
      Image = Image.Clone(new Rectangle(0, 0, Image.Width, Image.Height), PixelFormat.Format24bppRgb);
      Image = shrink.Apply(Image);
      return Image;
    }

    [ImageFilter("Remove Background", ImageFilterAttribute.FilterType.Custom, "حذف پس زمینه", "RemoveBackground")]
    public static Bitmap RemoveBackground(Bitmap original, Bitmap backgroundBitmap, int telourance = 15)
    {
      if (original.Width == backgroundBitmap.Width && original.Height == backgroundBitmap.Height)
      {
        for (int x = 0; x < original.Width; ++x)
        {
          for (int y = 0; y < original.Height; ++y)
          {
            Color pixel1 = original.GetPixel(x, y);
            Color pixel2 = backgroundBitmap.GetPixel(x, y);
            if (Math.Abs((int) ((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11) - (int) ((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11)) < 15)
            {
              original.SetPixel(x, y, Color.White);
            }
            else
            {
              Color color = Color.FromArgb((int) pixel1.R, (int) pixel1.G, (int) pixel1.B);
              original.SetPixel(x, y, color);
            }
          }
        }
      }
      return original;
    }

    [ImageFilter("Remove Color", ImageFilterAttribute.FilterType.Custom, "حذف رنگ", "RemoveColor")]
    public static Bitmap RemoveColor(Bitmap image, string radius = "120", string centerColor = "FFF")
    {
      EuclideanColorFiltering euclideanColorFiltering = new EuclideanColorFiltering();
      Color color = ColorTranslator.FromHtml(centerColor);
      euclideanColorFiltering.CenterColor = new RGB(color);
      euclideanColorFiltering.FillColor = new RGB(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      euclideanColorFiltering.Radius = short.Parse(radius);
      euclideanColorFiltering.ApplyInPlace(image);
      return image;
    }

    [ImageFilter("Crop", ImageFilterAttribute.FilterType.Custom, "بریدن گوشه های تصویر", "Crop")]
    public static Bitmap Crop(Bitmap image, string x, string y, string width, string height)
    {
      Rectangle srcRect = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(width), Convert.ToInt32(height));
      Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
      using (Graphics graphics = Graphics.FromImage((System.Drawing.Image) bitmap))
        graphics.DrawImage((System.Drawing.Image) image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
      return bitmap;
    }

    public static Bitmap[] GetBlob(Bitmap image)
    {
      BlobCounterBase blobCounterBase = (BlobCounterBase) new BlobCounter();
      blobCounterBase.FilterBlobs = true;
      blobCounterBase.MinHeight = 10;
      blobCounterBase.MinWidth = 5;
      blobCounterBase.ProcessImage(image);
      Blob[] array = ((IEnumerable<Blob>) blobCounterBase.GetObjectsInformation()).OrderBy<Blob, int>((Func<Blob, int>) (a => a.Rectangle.X)).ToArray<Blob>();
      List<Bitmap> bitmapList = new List<Bitmap>();
      foreach (Blob blob in array)
      {
        blobCounterBase.ExtractBlobsImage(image, blob, true);
        Bitmap bitmap1 = new AForge.Imaging.Filters.Shrink(Color.Black).Apply(blob.Image.ToManagedImage());
        if (bitmap1.Width > 35 || bitmap1.Height > 30)
        {
          Rectangle rectangle = new Rectangle(0, 0, bitmap1.Width / 2, bitmap1.Height);
          Bitmap bitmap2 = new AForge.Imaging.Filters.Crop(rectangle).Apply(bitmap1);
          bitmapList.Add(bitmap2);
          rectangle.X = bitmap1.Width / 2;
          Bitmap bitmap3 = new AForge.Imaging.Filters.Crop(rectangle).Apply(bitmap1);
          bitmapList.Add(bitmap3);
        }
        else
          bitmapList.Add(bitmap1);
      }
      return bitmapList.ToArray();
    }

    public static Bitmap Test(Bitmap image)
    {
      new AForge.Imaging.Filters.BlobsFiltering()
      {
        CoupledSizeFiltering = true,
        MinWidth = 10,
        MinHeight = 10
      }.ApplyInPlace(image);
      return image;
    }
  }
}
