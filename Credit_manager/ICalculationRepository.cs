using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    //интерфейс ICalculationRepository = представляет собой интерфейс к базе данных
    interface ICalculationRepository
    {
        //+Insert = выполняет добавление калькуляции в базу
        void Insert(Calculation obj);
        //+Remove = выполняет удаление калькуляции из базы по указанному айди
        void Remove(uint id);
        //+Select = возвращает найденную по указанному айди калькуляцию из базы
        Calculation Select(uint id);
        //+SelectAll = возвращает все калькуляции из базы
        void SelectAll();
        //+Update = изменяет калькуляцию хранящуюся в базе
        void Update(uint id,Calculation n_obj);

    }
}
