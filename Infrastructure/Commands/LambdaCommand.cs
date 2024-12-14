using LearnWPF.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWPF.Infrastructure.Commands
{
    class LambdaCommand : CommandBase
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<Object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute ?? throw new ArgumentException($"Не передан параметр {nameof(execute)}");
            this._canExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _execute(parameter);
    }
}
