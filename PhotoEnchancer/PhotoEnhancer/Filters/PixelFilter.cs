using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters p) : base(p) { }
        //public abstract ParameterInfo[] GetParametersInfo();
        public override Photo Process(Photo original, IParameters parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                    newPhoto[x, y] = ProcessPixel(original[x, y],
                            parameters);

            return newPhoto;
        }

        public abstract Pixel ProcessPixel(Pixel originalPixel,
            IParameters parameters);
    }
}
