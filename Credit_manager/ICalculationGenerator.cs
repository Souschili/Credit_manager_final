using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    //+GetCalculationSheet = принимает ВходныеДанные и генерирует особым образом на основе этих данных Калькуляцию
    interface ICalculationGenerator
    {
        Calculation GetCalculationSheet(Inputdata data);
    }
}
