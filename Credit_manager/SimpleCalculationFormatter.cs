using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Credit_manager
{
    class SimpleCalculationFormatter : ICalculationFormatter
    {
        public void ToStringLong(Calculation obj)
        {
            //второй метод калькуляцию выводит
            // foreach (var elem in obj.Payments)
            //     WriteLine(elem);
            //форматированый расово верный вывод
            WriteLine("\nPayCount" + "\t" + "Sum");
            WriteLine("_______________________");
            for(int i=0;i<obj.Payments.Count;i++)
            {
                WriteLine((i+1) + "\t\t" + obj.Payments[i]);
            }
            WriteLine("_______________________");
        }


        public void ToStringShort(Calculation obj)
        {
            //Никто не помог решил разбить вывод на 2 части ,вначале все поля 
            //второй метод калькуляцию выводит
            WriteLine("ID:\t" + obj.Id + "\nPayer:\t" + obj.Payer + "\nPayments:\t" + obj.TotalSum);
            
        }
       
    }
}
