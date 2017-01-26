﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
   public class ShowTime : IManipulateUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
        }
    }
}
