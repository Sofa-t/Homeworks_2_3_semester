using System;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter       
    {
        public LighteningFilter() : base(new LighteningParameters()) { }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, 
            IParameters parameters)
        {
            return originalPixel * (parameters as LighteningParameters).Coefficient;
        }

     
    }
}
