using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class EmptyParameters : IParameters
    {
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[0];
        }

        public void SetValues(double[] values) {}
    }
}
