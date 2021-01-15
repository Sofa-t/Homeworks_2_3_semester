using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        public Size ResultSize { get; private set; }
        Func<Size, Size> sizeTransformer;
        Func<Point, Size, Point> pointTransformer;

        public FreeTransformer(Func<Size, Size> sizeTransformer,
            Func<Point, Size, Point> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        Size oldSize;

        public void Initialize(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = sizeTransformer(size);
        }

        public Point? MapPoint(Point newPoint)
        {
            return pointTransformer(newPoint, oldSize);
        }
    }
}
