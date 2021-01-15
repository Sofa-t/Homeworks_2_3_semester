using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoEnhancer
{
    public static class Convertors
    {
        public static Photo Bitmap2Photo(Bitmap bmp)
        {
            var result = new Photo(bmp.Width, bmp.Height);

            for(var x = 0; x < bmp.Width; x++)
                for(var y = 0; y < bmp.Height; y++)
                {
                    var pixel = bmp.GetPixel(x, y);

                    //result[x, y].R = (double)pixel.R / 255;
                    //result[x, y].G = (double)pixel.G / 255;
                    //result[x, y].B = (double)pixel.B / 255;

                    result[x, y] = new Pixel(
                        (double)pixel.R / 255,
                        (double)pixel.G / 255,
                        (double)pixel.B / 255
                        );
                }

            return result;
        }

        public static Bitmap Photo2Bitmap(Photo photo)
        {
            var result = new Bitmap(photo.Width, photo.Height);
            
            for(var x = 0; x < photo.Width; x++)
                for(var y = 0; y < photo.Height; y++)
                {
                    result.SetPixel(x, y, Color.FromArgb(
                        (int)(photo[x, y].R * 255),
                        (int)(photo[x, y].G * 255),
                        (int)(photo[x, y].B * 255)
                        ));
                }

            return result;
        }
    }
}
