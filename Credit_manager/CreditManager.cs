using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    class CreditManager
    {


        private Controller _controller;

        public CreditManager()
        {
            _controller = new Controller();
        }
       

        public void Run()
        {
            _controller.Home();

        }
    }
}

//класс CreditManager
//    -controller = объект контроллера, отвечающий за взаимодействие с юзером
//    +CreditManager = конструктор
//    +Run = главный метод программы, реализующий управление программой через меню
//
