using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItemsList
    {
        private const string k_Exit = "Exit";

        public MainMenu(string i_MenuName)
           : base(i_MenuName)
        {
            this.m_BackOrExitMsgToUser = k_Exit;
        }

        public void ShowMenu()
        {
            this.ExecuteActionOrSubMenu();
        }
    }
}
