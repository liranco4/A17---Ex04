using System;
namespace Ex04.Menus.Delegates
{
	public class MainMenu : MenuWithInnerMenusCollection
	{
		public MainMenu(string i_MenuName)
			: base(i_MenuName)
		{
		}

		protected override string BackOrExitOperation()
		{
			return "Exit";
		}

		public void Show()
		{
			ExecuteOperationOrShowInnerMenu();
		}
	}
}
