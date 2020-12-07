using System;

namespace PhotoEnhancer
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParameters parameters;

        public ParametrizedFilter(IParameters p)
        {
            parameters = p;
        }
        public ParameterInfo[] GetParametersInfo()
        {
            return parameters.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            parameters.SetValues(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, IParameters parameters);
    }
}
