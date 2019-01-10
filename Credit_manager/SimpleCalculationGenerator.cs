using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Credit_manager
{
    class SimpleCalculationGenerator : ICalculationGenerator
    {
        public Calculation  GetCalculationSheet(Inputdata data)
        {
            //WriteLine("Start CalcGen!!");
            // тут создаем обьект calculation заносим в него данные из структуры +вычисления выплат 
            //Далее передаем в репозиторий где он получает id
            Calculation obj = new Calculation();
            obj.Payer = data.PayerName + " " + data.PayerSurname; //имя + фамилия
            //пока пропустим вычисления
            obj.PaymentsCount = data.PaymentsCount;
            obj.TotalSum = data.TotalSum+(uint)(data.TotalSum*0.07);
            //////////////////////////////////////////
            //собственно считаем беру формулу из примера (ну чтото близкое) +7% к выпате в первый месяц
            //можно изменить но нехай пока так некритично
            //сразу пихаем первую выплату +7%
            for (uint i = 0; i < data.PaymentsCount; i++)
                obj.Payments.Add(data.TotalSum/data.PaymentsCount);

            obj.Payments[0] += (uint)(data.TotalSum * 0.07); //первая выплата + 7%


            //возращаем обьект класса (все поля заполнены кроме id)
            return obj;
        }
    }
}
