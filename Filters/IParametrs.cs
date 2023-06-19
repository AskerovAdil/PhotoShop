using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    /*
     - создайте интерфейс IParameters - по смыслу, это интерфейс класса, который содержит настройки какого-то фильтра.
      В этом интерфейсе определите методы:
        ParameterInfo[] GetDesсription(), который будет возвращать информацию о настройках
        void Parse(double[]), который будет устанавливать поля класса в соответствие с массиво
    */
    public interface IParametrs
    {
        ParameterInfo[] GetDescription();
        void SetValues(double[] doubles);
    }
}
