using System;
namespace Ex04.Menus.Delegates
{
	public delegate void Executers<T>(T param);

	public class OperationMenu : Menu
	{
		public event Executers<Menu> m_InvokeOperations;

		public OperationMenu(string i_MenuName)
			: base(i_MenuName)
		{
		}

		internal override void ExecuteOperationOrShowInnerMenu()
		{
			if (m_InvokeOperations != null)
			{
				m_InvokeOperations.Invoke(this);
			}
		}
	}
}
