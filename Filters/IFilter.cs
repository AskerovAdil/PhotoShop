using MyPhotoshop.Data;
using System;

namespace MyPhotoshop
{

	
	public interface IFilter
	{

  	    ParameterInfo[] GetParameters();

		Photo Process(Photo original, double[] parameters);


    }
}

