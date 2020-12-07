using System;

namespace PhotoEnhancer
{
    public class GrayscaleFilter : PixelFilter
    {
        public GrayscaleFilter() : base(new EmptyParameters()) { }
        
        public override string ToString()
        {
            return "Оттенки серого";
        }

        public override Pixel ProcessPixel(Pixel originalPixel,
            IParameters parameters)
        {
            var chanel = 0.3 * originalPixel.R +
                        0.6 * originalPixel.G +
                        0.1 * originalPixel.B;

            return new Pixel(chanel, chanel, chanel);
        }
    }
}
