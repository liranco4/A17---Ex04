using System;
namespace Ex04.Menus.Delegates
{
	public class MainMenu : MenuWithInnerMenusCollection
	{
        private const string k_Exit = "Exit";
		public MainMenu(string i_MenuName)
			: base(i_MenuName)
		{
		}

        protected override string BackOrExitOperation
        {
           get{ return k_Exit; }
        }

		public void Show()
		{
			ExecuteOperationOrShowInnerMenu();
		}
	}
}
