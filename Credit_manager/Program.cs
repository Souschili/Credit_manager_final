using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    //
    struct Inputdata
    {

        public string PayerName { set; get; }     // = имя плательщика по кредиту
        public string PayerSurname { get; set; } // = фамилия плательщика по кредиту
        public uint PaymentsCount { get; set; } // = количество платежей, на которое растянута выплата кредита
        public uint TotalSum { get; set; }     // = общая сумма кредита без процентов
    }




    class Program
    {
        static void Main(string[] args)
        {
            Console.Title= "Credit_Manager v0.0.1a   (c) Dylan Hunt ";
            CreditManager T = new CreditManager();

            T.Run();
        }
    }
}
