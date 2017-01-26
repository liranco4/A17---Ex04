using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            RunInterfaceMenu();
        }

        private static void RunInterfaceMenu()
        {
            Interfaces.MainMenu mainMenuInterface = new Interfaces.MainMenu("Main Menu - Interface");
            Interfaces.MenuItemsList timeDateMenuItemInterface = new Interfaces.MenuItemsList("Show Date/Time");
            Interfaces.MenuItemsList versionAndActionsMenuItemInterface = new Interfaces.MenuItemsList("Version And Actions");

            Interfaces.ManipulateMenuItem showTimeItemInterface = new Interfaces.ManipulateMenuItem("Show Time", new ShowTime());
            Interfaces.ManipulateMenuItem showDateItemInterface = new Interfaces.ManipulateMenuItem("Show Date", new ShowDate());
            Interfaces.ManipulateMenuItem versionMenuItemInterface = new Interfaces.ManipulateMenuItem("Show Version", new ShowVersion());
   

            timeDateMenuItemInterface.AddItemToMenu(showTimeItemInterface);
            timeDateMenuItemInterface.AddItemToMenu(showDateItemInterface);

            versionAndActionsMenuItemInterface.AddItemToMenu(versionMenuItemInterface);

            mainMenuInterface.AddItemToMenu(timeDateMenuItemInterface);
            mainMenuInterface.AddItemToMenu(versionAndActionsMenuItemInterface);
            mainMenuInterface.ShowMenu();
        }
    }
}
