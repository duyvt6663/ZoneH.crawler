// Decompiled with JetBrains decompiler
// Type: CaptchaSolver.DrCaptcha.ir.Engine.MethodsCaptchaSolver
// Assembly: CaptchaSolver.DrCaptcha.ir.Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5137520E-BE24-43F6-8B80-475BCC7CF233
// Assembly location: C:\Users\WIN\Documents\GitHub\Ardin.ZoneHCaptchaSolver\Ardin.ZoneHCaptchaSolver.Sample\Dependencies\CaptchaSolver.DrCaptcha.ir.Engine.dll

using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using Tesseract;

namespace CaptchaSolver.DrCaptcha.ir.Engine
{
  public class MethodsCaptchaSolver
  {
    public static string OCR(Bitmap b, string whiteList = "abcdefghijklmnopqrstuvwxyz123456789", bool upperCase = false)
    {
      try
      {
        string str = string.Empty;
        string appSetting = ConfigurationManager.AppSettings["tessdata"];
        if (string.IsNullOrEmpty(whiteList))
          whiteList = "abcdefghijklmnopqrstuvwxyz123456789";
        if (upperCase)
          whiteList = whiteList.ToUpper();
        using (TesseractEngine tesseractEngine = new TesseractEngine(appSetting, "eng", (EngineMode) 0))
        {
          tesseractEngine.SetVariable("tessedit_char_whitelist", whiteList);
          tesseractEngine.SetVariable("tessedit_unrej_any_wd", true);
          tesseractEngine.SetVariable("tessedit_adapt_to_char_fragments", true);
          tesseractEngine.SetVariable("tessedit_redo_xheight", true);
          tesseractEngine.SetVariable("chop_enable", true);
          Bitmap bitmap = b.Clone(new Rectangle(0, 0, b.Width, b.Height), PixelFormat.Format24bppRgb);
          using (Page page = tesseractEngine.Process(bitmap, new PageSegMode?((PageSegMode) 8)))
            str = page.GetText().Replace(" ", "").Trim();
        }
        return str;
      }
      catch (Exception ex)
      {
        return (string) null;
      }
    }

    public static string OCR2(string imagePath, string whiteList = "abcdefghijklmnopqrstuvwxyz0123456789", bool upperCase = false)
    {
      string str1 = string.Empty;
      try
      {
        if (string.IsNullOrEmpty(whiteList))
          whiteList = "abcdefghijklmnopqrstuvwxyz0123456789";
        if (upperCase)
          whiteList = whiteList.ToUpper();
        string appSetting = ConfigurationManager.AppSettings["TesseractJsWorkingDirectory"];
        string str2 = "node index.js " + imagePath + whiteList;
        Process process = new Process();
        process.StartInfo.WorkingDirectory = appSetting;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/c " + str2;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        string end = process.StandardOutput.ReadToEnd();
        process.Close();
        str1 = end;
      }
      catch (Exception ex)
      {
      }
      if (!string.IsNullOrEmpty(str1))
        ;
      return str1;
    }

    public static string OCR(
      string sampleFilename,
      string whitelist,
      bool isUpperCase = false,
      bool isMyTehran = false)
    {
      if (isMyTehran)
        return new MyTehranOCR(ConfigurationManager.AppSettings["MyTehranCaptchaData"]).OCR(new Bitmap(sampleFilename));
      try
      {
        using (WebClient webClient = new WebClient())
        {
          string appSetting = ConfigurationManager.AppSettings["TesseractjsApi"];
          if (isUpperCase)
            whitelist = whitelist.ToUpper();
          string address = appSetting + "?captcha=" + sampleFilename + "&whitelist=" + whitelist;
          string str = webClient.DownloadString(address).Replace("\\n", string.Empty).Replace("\"", string.Empty);
          if (isUpperCase)
            str = str.ToUpper();
          char[] charArray = str.ToCharArray();
          string empty = string.Empty;
          foreach (char ch1 in charArray)
          {
            foreach (char ch2 in whitelist.ToCharArray())
            {
              if ((int) ch1 == (int) ch2)
                empty += ch1.ToString();
            }
          }
          return empty;
        }
      }
      catch (Exception ex)
      {
        return string.Empty;
      }
    }
  }
}
