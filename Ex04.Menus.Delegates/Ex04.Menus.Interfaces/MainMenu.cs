using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItemsList
    {
        public MainMenu(string i_MenuName)
           : base(i_MenuName)
        {
            m_backOrExitMsgToUser = "Exit";
        }

        public void ShowMenu()
        {
            ExecuteActionOrSubMenu();
        }
    }
}
