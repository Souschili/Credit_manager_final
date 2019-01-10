using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_manager
{
    interface IInputService
    {
        //+GetInputData = запрашивает у пользователя данные и возвращает структуру, хранящую эти данные
        Inputdata GetInputData();
    }
}
