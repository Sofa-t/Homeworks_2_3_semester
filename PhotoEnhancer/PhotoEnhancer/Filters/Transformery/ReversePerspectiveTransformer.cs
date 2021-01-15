using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoEnhancer
{
    class ReversePerspectiveTransformer : ITransformer<ReversePerspParameters>
    {
        public Size ResultSize { get; set; }

        Size originalSize;
        double Squish;

        public void Initialize(Size size, ReversePerspParameters parameters)
        {
            originalSize = size;
            Squish = parameters.Squish;
            ResultSize = originalSize;
        }

        public Point? MapPoint(Point point)
        {
            {
                double x = point.X;
                double y = point.Y;
                double variable = 1 - y / ResultSize.Height;
                double percent = 100 / (100 - Squish + Squish * variable);
                x = x * percent + (1 - percent) * ResultSize.Width / 2;

                if (x < 0 || x > originalSize.Width - 1)
                    return null;

                return new Point((int)x, (int)y);
            }

        }

    } 
    
}


