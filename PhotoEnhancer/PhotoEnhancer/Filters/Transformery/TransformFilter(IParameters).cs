using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        string name;
        ITransformer<TParameters> transformer;

        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }


        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            transformer.Initialize(oldSize, parameters);

            var result = new Photo(transformer.ResultSize.Width, transformer.ResultSize.Height);

            for(var x = 0; x < result.Width; x++)
                for(var y = 0; y < result.Height; y++)
                {
                    var oldPoint = transformer.MapPoint(new Point(x, y));
                    if(oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
