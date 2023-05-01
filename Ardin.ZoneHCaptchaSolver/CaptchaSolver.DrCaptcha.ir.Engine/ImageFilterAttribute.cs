// Decompiled with JetBrains decompiler
// Type: CaptchaSolver.DrCaptcha.ir.Engine.ImageFilterAttribute
// Assembly: CaptchaSolver.DrCaptcha.ir.Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5137520E-BE24-43F6-8B80-475BCC7CF233
// Assembly location: C:\Users\WIN\Documents\GitHub\Ardin.ZoneHCaptchaSolver\Ardin.ZoneHCaptchaSolver.Sample\Dependencies\CaptchaSolver.DrCaptcha.ir.Engine.dll

using System;

namespace CaptchaSolver.DrCaptcha.ir.Engine
{
  public class ImageFilterAttribute : Attribute
  {
    public ImageFilterAttribute.FilterType Type = ImageFilterAttribute.FilterType.AForge;
    public string FarsiDescription = "توضیح فیلر";
    public string DisplayName = "FilterName";
    public string Name = "FilterName";

    public ImageFilterAttribute(
      string displayName,
      ImageFilterAttribute.FilterType type,
      string farsiDescription,
      string name)
    {
      this.Name = name;
      this.Type = type;
      this.FarsiDescription = farsiDescription;
      this.DisplayName = displayName;
    }

    public enum FilterType
    {
      AForge,
      Normal,
      Custom,
    }
  }
}
