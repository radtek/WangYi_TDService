using System;
using System.Collections.Generic;
using System.Text;

namespace TDService
{
    public class StaticForm
    {
        public static mainForm main = new mainForm();

       public static TDService.Code.INIClass ini = new TDService.Code.INIClass(".\\Config.ini");

        public static int loginstat = 1;
    }
}
