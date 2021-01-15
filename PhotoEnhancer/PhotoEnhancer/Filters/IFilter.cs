using System;


namespace PhotoEnhancer
{
    public interface IFilter
    {
        Photo Process(Photo original, double[] parameters);
        ParameterInfo[] GetParametersInfo();
    }
}
