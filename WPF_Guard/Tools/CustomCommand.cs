﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Guard.Tools
{
    public class CustomCommand : ICommand
    {
        Action Action;
        public CustomCommand(Action action)
        {
            this.Action = action;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Action();
        }
    }
}
