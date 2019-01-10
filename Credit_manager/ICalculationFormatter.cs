using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    interface ICalculationFormatter
    {
        //+ToStringLong = генерирует строку, содержащую полный отчет по кредиту
        void ToStringLong(Calculation obj);
        //+ToStringShort = генерирует строку, содержащую короткий отчет по кредиту
        void ToStringShort(Calculation obj);
    }
}
