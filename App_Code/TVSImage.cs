using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

public class TVSImage
{
    #region method TVSImage
    public TVSImage()
    {
    }
    #endregion

    #region method TVSImage
    public Image saveResizeImage(Image img, int width)
    {
        try
        {
            int originalW = img.Width;
            int originalH = img.Height;
            int resizedW = width;
            int resizedH = (originalH * resizedW) / originalW;
            Bitmap b = new Bitmap(resizedW, resizedH);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.DrawImage(img, 0, 0, resizedW, resizedH);
            g.Dispose();
            img = b;
            return img;
        }
        catch (Exception e)
        {
            return img;
        }
    }
    #endregion
}