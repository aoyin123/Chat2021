using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chat2021
{
    static class DealImage
    {
        /// <summary>
        /// 提取图像一部分
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <returns></returns>
        public static Bitmap GetPartOfImage(Bitmap sourceBitmap, int width, int height, int offsetX, int offsetY)
        {
            Bitmap resultBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resultBitmap))
            {
                Rectangle resultRectangle = new Rectangle(0, 0, width, height);
                Rectangle sourceRectangle = new Rectangle(0 + offsetX, 0 + offsetY, width, height);
                g.DrawImage(sourceBitmap, resultRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }
            return resultBitmap;
        }

        /// <summary>
        /// 使像素黑化
        /// </summary>
        /// <param name="sourceColor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Color PixelDarken(Color sourceColor, int value)
        {
            int R = sourceColor.R > value ? (sourceColor.R - value) : 0;
            int G = sourceColor.G > value ? (sourceColor.G - value) : 0;
            int B = sourceColor.B > value ? (sourceColor.B - value) : 0;
            return Color.FromArgb(R, G, B);
        }

        /// <summary>
        /// 使像素白化
        /// </summary>
        /// <param name="sourceColor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Color PixelBrighten(Color sourceColor, int value)
        {
            int R = sourceColor.R + value > 255 ? 255 : sourceColor.R + value;
            int G = sourceColor.G + value > 255 ? 255 : sourceColor.G + value;
            int B = sourceColor.B + value > 255 ? 255 : sourceColor.B + value;
            return Color.FromArgb(R, G, B);
        }

        /// <summary>
        /// 让图片变暗
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <returns></returns>
        public static Bitmap MakePicDarken(Bitmap sourceBitmap)
        {
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;
            Bitmap resultBitmap = new Bitmap(width, height);

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for(int j = 0; j < sourceBitmap.Height; j++)
                {
                    resultBitmap.SetPixel(i, j, PixelDarken(sourceBitmap.GetPixel(i, j), 30));
                }
            }
            resultBitmap.Save("ff.png");
            return resultBitmap;
        }
    }
}
