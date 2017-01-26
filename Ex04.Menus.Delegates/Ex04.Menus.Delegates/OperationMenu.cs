using System;
namespace Ex04.Menus.Delegates
{
	public delegate void Executers();

	public class OperationMenu : MenuItem
	{
		public event Executers ExecuteMenuOperation;

		public OperationMenu(string i_MenuName)
			: base(i_MenuName)
		{
		}

		internal override void ExecuteOperationOrShowInnerMenu()
		{
			if (ExecuteMenuOperation != null)
			{
				ExecuteMenuOperation.Invoke();
			}
		}
	}
}
