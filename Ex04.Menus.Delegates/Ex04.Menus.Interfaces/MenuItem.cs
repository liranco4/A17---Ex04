using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_MenuHeaderName = string.Empty;

        public MenuItem(string i_MenuName)
        {
            m_MenuHeaderName = i_MenuName;
        }

        public string MenuName
        {
            get { return m_MenuHeaderName; }
            set { m_MenuHeaderName = value; }
        }

        internal abstract void ExecuteActionOrSubMenu();
    }
}