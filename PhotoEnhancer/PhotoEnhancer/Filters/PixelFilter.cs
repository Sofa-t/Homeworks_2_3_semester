using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        string name;
        Func<Pixel, TParameters, Pixel> processor;

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> processor)
        {
            this.name = name;
            this.processor = processor;
        }
        public override Photo Process(Photo original, TParameters parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                    newPhoto[x, y] = processor(original[x, y], parameters);

            return newPhoto;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
