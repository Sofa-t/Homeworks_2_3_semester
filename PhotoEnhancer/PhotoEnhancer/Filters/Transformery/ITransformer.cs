using System;
using System.Drawing;


namespace PhotoEnhancer
{
    public interface ITransformer<TParameters>
        where TParameters : IParameters, new()
    {
        void Initialize(Size size, TParameters parameters);
        Size ResultSize { get; }
        Point? MapPoint(Point newPoint);
    }
}
