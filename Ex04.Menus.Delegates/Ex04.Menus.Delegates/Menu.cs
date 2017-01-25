using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    internal abstract class Menu
    {
        protected string r_MenuName;
        
        Menu(string i_MenuName)
        {
            r_MenuName = i_MenuName;
        }

        public string MenuName
        {
            get
            {
               return r_MenuName;
            }
        }

        protected abstract void ExecuteOperationOrShowInnerMenu();
    }
}
