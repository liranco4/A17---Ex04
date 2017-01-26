using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ManipulateMenuItem : MenuItem
    {
        private IManipulateUserChoice m_UserChoice;

        public ManipulateMenuItem(string i_ItemName, IManipulateUserChoice i_UserChoiceMethod)
            :base(i_ItemName)
        {
            m_UserChoice = i_UserChoiceMethod;
        }

        internal override void ExecuteActionOrSubMenu()
        {
            m_UserChoice.ExecuteUserChoice();
        }

    }
}