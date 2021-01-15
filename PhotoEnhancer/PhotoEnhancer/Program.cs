using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var chanel = 0.3 * pixel.R +
                                0.6 * pixel.G +
                                0.1 * pixel.B;

                    return new Pixel(chanel, chanel, chanel);
                }
                ));
            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Инверсия цвета",
                (pixel, parameters) =>
                {
                    var newR = 1 - pixel.R;
                    var newG = 1 - pixel.G;
                    var newB = 1 - pixel.B;

                    return new Pixel(newR, newG, newB);
                }));

            mainForm.AddFilter(new TransformFilter(
                "Мозаика(Должна быть)",
                size => size,
                (point, size) =>
                {
                    int x = point.X;
                    int y = point.Y;

                    if (x < size.Width / 2)
                        x = x * 2;
                    else
                        x = (size.Width - x - 1) * 2;

                    if (y < size.Height / 2)
                        y = y * 2;
                    else
                        y = (size.Height - y - 1) * 2;

                    return new Point(x, y);
                }
                )); 

            mainForm.AddFilter(new TransformFilter<ReversePerspParameters>(
                "Сужение нижней части", new ReversePerspectiveTransformer()));
            Application.Run(mainForm);
        }
    }
}
    

