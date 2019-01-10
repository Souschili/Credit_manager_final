using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Credit_manager
{
    class SimpleInputService : IInputService
    {
        public Inputdata GetInputData()
        {

            //генерируем калькуляцию,т.е заполняем структуру+передаем данные в генератор

            //запрос данных у пользователя,сработал после команды add
            Inputdata data = new Inputdata(); // новая структура для сбора инфы
            //со строками просто хоть ежом обзови хоть р2д2
            WriteLine("Enter name :");
            data.PayerName = ReadLine();
            WriteLine("Enter Surname : ");
            data.PayerSurname = ReadLine();
            //замутить проверку через трайпарс,ибо цыфры. Сферический кредит в целых положительных цифрах
            uint temp; // недопер почему не сработал TryParse(readLine(),out data.TotalSum) ?в итоге завел локальную переменую
            do
            {
                WriteLine("Enter total payments sum : ");
                if (UInt32.TryParse(ReadLine(), out temp))
                {
                    data.TotalSum = temp;
                    break;
                }

                WriteLine("Wrong input !! Try again or die mortal !!");
            } while (true);
            //аналогичная проверка для временого отрезка
            do
            {
                WriteLine("Input payments count : ");
                if (UInt32.TryParse(ReadLine(), out temp))
                {
                    data.PaymentsCount = temp;
                    break;
                }

                WriteLine("Wrong input !! Try again or die mortal !!");
            } while (true);


            
            return data;
        }

           
       
    }
}
