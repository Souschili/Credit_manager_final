using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Credit_manager
{
    class CalculationRepository : ICalculationRepository
    {
        private IList<Calculation> _bd = new List<Calculation>();
        private uint _id = 0; //всегда положительное,выдается только в репозитории ,изначально 0
        public void Insert(Calculation obj)
        {
            //тут тока 2 действия запись в колекцию и  увеличения счетчика id на 1
            obj.Id = _id; //таки еще выдача id 
            _bd.Add(obj);
            _id++;
           
        }

        public void Remove(uint ID)
        {
            //удаляем по айди
            var valuefordelete = _bd.First(x => x.Id == ID);
            _bd.Remove(valuefordelete);
            
        }

        public Calculation Select(uint id)
        {
            // ищем есть ли айди в списке и возращаем сообщение что его нет либо вызываем отчет
            foreach (var elem in _bd)
            {
                if (elem.Id == id)
                {
                    //WriteLine("We find it!!");
                    return elem;
                }
            }
           
            return null;
        }

        public void SelectAll()
        {
            foreach (var elem in _bd)
                WriteLine(elem.Id + "   " + elem.Payer + "   " + elem.TotalSum);
        }

        public void Update(uint id,Calculation new_obj)
        {
            //находим нужный обьект по id и заменяем поля 
            var old_obj = _bd.First(x => x.Id == id);
            old_obj.Payer = new_obj.Payer;
            old_obj.Payments = new_obj.Payments;
            old_obj.PaymentsCount = new_obj.PaymentsCount;
            old_obj.TotalSum = new_obj.TotalSum;
            
            
        }
    }
}
