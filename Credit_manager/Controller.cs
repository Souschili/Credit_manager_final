using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Credit_manager
{
    class Controller
    {
        private ICalculationGenerator _CalculationGenerator;
        private ICalculationFormatter _CalculationFormatter;
        private IInputService _InputService;
        private ICalculationRepository _CalculationRepository;
        
        public Controller()
        {
            _CalculationFormatter = new SimpleCalculationFormatter();
            _CalculationGenerator = new SimpleCalculationGenerator();
            _CalculationRepository = new CalculationRepository();
            _InputService = new SimpleInputService();
        }


        public void AddCalcutions()
        {
            //начинаем опрос пользователя и по цепочке сдаем в репозиторий . Красоты мало но думаю так проще ИМХО
            //наглядно тут происходит следующее c права на лево. Опрос пользователя и создание структуры(inputserv) 
            // передается в генератор отчета ,а он в свою очередь передает обьект типа cаlculation в метод инсерт репозитория
            // Вопрос с "невидимостью" решился я забыл что они приватные поля и их невидно вне класса
            var t_calculation = _CalculationGenerator.GetCalculationSheet(_InputService.GetInputData());
            _CalculationRepository.Insert(t_calculation);
            
        }

        public void CalculationDetail(uint id)
        {
            //вроде ничего лишнего ,но потом еще гляну
            //можно и без переменой но так получиться цепь из методов что не сразу понятно
            var e = _CalculationRepository.Select(id);
            if(e!=null)
            {
                StringBuilder str = new StringBuilder();
                // вывод в тестовом режиме
                _CalculationFormatter.ToStringShort(e); //короткая инфа
                _CalculationFormatter.ToStringLong(e); //по выплатам и тд.
                WriteLine("Type option :");
                WriteLine("-delete ");
                WriteLine("-update ");
                WriteLine("-return");
                do
                {
                    str.Clear();
                    str.Append(ReadLine());
                    Write("_>");
                    //var str = ReadLine();
                    if (str.ToString().Equals("delete"))
                    {
                        //передаем в метод айди и там обрабатываем
                        DeleteCalculation(id);
                        break;
                    }
                    else if (str.ToString().Equals("update"))
                    {
                        //передаем id в editcalc(утром дописать)
                        EditCalculation(id);
                        break;
                    }
                    //укоротил
                    //else if (str.Equals("return"))
                    //{
                    //    WriteLine("return to Home");
                    //    break;
                    //}
                    //доделать апдейт и удаление
                } while (str.ToString()!="return");
                
            }
            else
            {
                //если ненашли
                WriteLine("Id not found!!\npress any key.....");
                Console.ReadKey(); // стопор для прочтения надписи выше 
               
                
            }
           
        }

        public void DeleteCalculation(uint id)
        {

            //тупо передаем id в репозиторий и там удаляем из колекции нужный обьект
            _CalculationRepository.Remove(id);
        }

        public void EditCalculation(uint id)
        {
            //мутим все по новой и передаем в апдейт id и новый обьект
            var temp = _CalculationGenerator.GetCalculationSheet(_InputService.GetInputData());
            _CalculationRepository.Update(id, temp);
            
        }

        public void Home()
        {
            //полностью переработал меню(стало короче ). В итоге выяснил что проблема была в логике вызовов и паре break.
            StringBuilder str = new StringBuilder();//для экономии памяти учитывая особеность типа стринг это оптимально
            while (str.ToString() != "exit")
            {
                Console.Clear();
                WriteLine("ID" + "  " + " Payer" + "     " + "TotalSum");
                _CalculationRepository.SelectAll();
                WriteLine(" -Ввод номера id из списка позволит редактировать и тд. запись ");
                WriteLine(" -Ввод add добавит новую запись в список ");
                WriteLine(" -Для выхода введите exit");
                do
                {

                    str.Clear();
                    Write("_>");
                    str.Append(ReadLine());
                    if (str.ToString() == "add")
                    {
                        AddCalcutions();
                        break;
                    }
                    else if (UInt32.TryParse(str.ToString(),out uint id) )
                    {
                        CalculationDetail(id);
                        break; // вот оно зло :)
                    }
                    
                   
                } while (str.ToString() != "exit");

            }
        }

    }
}
//класс Controller
//    -calculationFormatter = интерфейсная ссылка на объект, реализующий интерфейс ICalculationFormatter.
//                            используется для форматирования калькуляции для визуального отображения.
//                            простым языком - отвечает за вывод калькуляции на экран или за преобразование калькуляции в строку
//	
//	
//    -calculationGenerator = интерфейсная ссылка на объект, реализующий интерфейс ICalculationGenerator
//                            используется для генерации калькуляции кредита на основании входных данных
//                            простым языком - принимает входные данные и возвращает сгенерированную калькуляцию
//	
//	
//    -inputService = интерфейсная ссылка на объект, реализующий интерфейс IInputService
//                    используется для ввода данных пользователем
//                    простым языком - запрашивает у пользователя данные и возвращает структуру, хранящую эти данные
//					
//					
//    -calculationRepository = интерфейсная ссылка на объект, реализующий интерфейс ICalculationRepository.
//                             используется для работы с коллекцией калькуляций - добавления, удаления, изменения и чтения
//                             простым языком - является оберткой над коллекцией калькуляций.