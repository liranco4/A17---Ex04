using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItemsList
    {
        private const string Exit = "Exit";

        public MainMenu(string i_MenuName)
           : base(i_MenuName)
        {
            this.m_backOrExitMsgToUser = Exit;
        }

        public void ShowMenu()
        {
            this.ExecuteActionOrSubMenu();
        }
    }
}
