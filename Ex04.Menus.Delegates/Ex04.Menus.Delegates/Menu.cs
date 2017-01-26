using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public abstract class Menu
    {
        protected string r_MenuName;
        
        protected Menu(string i_MenuName)
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

        internal abstract void ExecuteOperationOrShowInnerMenu();
    }
}
