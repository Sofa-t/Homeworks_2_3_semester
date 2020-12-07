using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PhotoEnhancer
{
    class InvertFilter : PixelFilter
    {
        public InvertFilter() : base(new EmptyParameters()) { }

        public override string ToString()
        {
            return "Инверсия";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {

            var newR = 1 - originalPixel.R;
            var newG = 1 - originalPixel.G;
            var newB = 1 - originalPixel.B;

            return new Pixel(newR, newG, newB);
        }

    }
   
}
