using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class ReversePerspParameters : IParameters
    {
        public double Squish { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo() {
                    Name = "Сужаемая часть(в процентах)",
                    MinValue = 0,
                    MaxValue = 100,
                    DefaultValue = 100,
                    Increment = 5
                    }
            };
        }

        public void SetValues(double[] values)
        {
            Squish = values[0];
        }
    }
}

