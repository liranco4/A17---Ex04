using System;
namespace Ex04.Menus.Delegates
{
	public delegate void ExecuteOperation(Menu i_Menu);
	public class OperationMenu : Menu
	{
		public event ExecuteOperation m_InvokeOperation;

		public OperationMenu(string i_MenuName)
			: base(i_MenuName)
		{
		}

		internal override void ExecuteOperationOrShowInnerMenu()
		{
			if (m_InvokeOperation != null)
			{
				m_InvokeOperation.Invoke(this);
			}
		}
	}
}
