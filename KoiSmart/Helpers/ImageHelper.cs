using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KoiSmart.Helpers
{
    public static class ImageHelper
    {
        public static byte[] ImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image BinaryToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }
    }
}