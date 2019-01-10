using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    //класс коллектор инфы
    class Calculation
    {
        public uint Id { get; set; }// = уникальный идентификационный номер калькуляции для нахождения ее в базе
        public string Payer { get; set; }// = имя и фамилия плательщика по кредиту
        public IList<uint> Payments = new List<uint>();// = коллекция платежей, в котором каждый элемент хранит сумму одного платежа
        public uint PaymentsCount { get; set; }// = количество платежей
        public uint TotalSum { get; set; }// = общая сумма по кредиту
        public Calculation() { }
    }
}
