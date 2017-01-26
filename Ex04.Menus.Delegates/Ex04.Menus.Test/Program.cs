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
            RunDelegateMenu();
            RunInterfaceMenu();
        }

        private static void RunInterfaceMenu()
        {
            Interfaces.MainMenu mainMenuInterface = new Interfaces.MainMenu("Main Menu - Interface");
            Interfaces.MenuItemsList timeDateMenuItemInterface = new Interfaces.MenuItemsList("Show Date/Time");
            Interfaces.MenuItemsList versionAndActionsMenuItemInterface = new Interfaces.MenuItemsList("Version And Actions");
            Interfaces.MenuItemsList ActionsMenuItemInterface = new Interfaces.MenuItemsList("Actions");
            Interfaces.ManipulateMenuItem showTimeItemInterface = new Interfaces.ManipulateMenuItem("Show Time", new ShowTime());
            Interfaces.ManipulateMenuItem showDateItemInterface = new Interfaces.ManipulateMenuItem("Show Date", new ShowDate());
            Interfaces.ManipulateMenuItem versionMenuItemInterface = new Interfaces.ManipulateMenuItem("Show Version", new ShowVersion());
            Interfaces.ManipulateMenuItem charsCounterItemInterface = new Interfaces.ManipulateMenuItem("Chars Counter", new CharsCount());
            Interfaces.ManipulateMenuItem countSpacesItemInterface = new Interfaces.ManipulateMenuItem("Count Spaces", new CountSpaces());
            timeDateMenuItemInterface.AddItemToMenu(showTimeItemInterface);
            timeDateMenuItemInterface.AddItemToMenu(showDateItemInterface);
            versionAndActionsMenuItemInterface.AddItemToMenu(versionMenuItemInterface);
            ActionsMenuItemInterface.AddItemToMenu(charsCounterItemInterface);
            ActionsMenuItemInterface.AddItemToMenu(countSpacesItemInterface);
            versionAndActionsMenuItemInterface.AddItemToMenu(ActionsMenuItemInterface);
            mainMenuInterface.AddItemToMenu(timeDateMenuItemInterface);
            mainMenuInterface.AddItemToMenu(versionAndActionsMenuItemInterface);
            mainMenuInterface.ShowMenu();
        }

		private static void RunDelegateMenu()
		{
			Delegates.MainMenu mainMenu = new Delegates.MainMenu("Main Menu - Delegate");
			Delegates.MenuWithInnerMenusCollection dateTimeMenu = new Delegates.MenuWithInnerMenusCollection("Show Date/Time");
			Delegates.OperationMenu showDateMenu = new Delegates.OperationMenu("Show Date");
			Delegates.OperationMenu showTimeMenu = new Delegates.OperationMenu("Show Time");

			dateTimeMenu.AddToCollection(showDateMenu);
			dateTimeMenu.AddToCollection(showTimeMenu);


			showDateMenu.ExecuteMenuOperation += new ShowDate().ExecuteUserChoice;
			showTimeMenu.ExecuteMenuOperation += new ShowTime().ExecuteUserChoice;

			Delegates.MenuWithInnerMenusCollection versionAndActionsMenu = new Delegates.MenuWithInnerMenusCollection("Version And Actions");
			Delegates.OperationMenu versionMenu = new Delegates.OperationMenu("Show Version");
			Delegates.MenuWithInnerMenusCollection actionsMenu = new Delegates.MenuWithInnerMenusCollection("Actions");

			versionAndActionsMenu.AddToCollection(versionMenu);
			versionAndActionsMenu.AddToCollection(actionsMenu);

			versionMenu.ExecuteMenuOperation += new ShowVersion().ExecuteUserChoice;


			Delegates.OperationMenu charsCounterMenu = new Delegates.OperationMenu("Chars Counter");
			Delegates.OperationMenu countSpacesMenu = new Delegates.OperationMenu("Count Spaces");

			actionsMenu.AddToCollection(charsCounterMenu);
			actionsMenu.AddToCollection(countSpacesMenu);

			charsCounterMenu.ExecuteMenuOperation += new CharsCount().ExecuteUserChoice;
			countSpacesMenu.ExecuteMenuOperation += new CountSpaces().ExecuteUserChoice;

            mainMenu.AddToCollection(dateTimeMenu);
            mainMenu.AddToCollection(versionAndActionsMenu);
            mainMenu.Show();
		}
    }
}
