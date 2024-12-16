using LearnWPF.Infrastructure.Commands;
using LearnWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LearnWPF.ViewModels
{
    class MainVindowViewModel : ViewModelBase
    {

        #region Title
        private string _title = "Анализ статистики CV19";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string TItle
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Status
        private string _status = "Готов!";


        /// <summary>
        /// Статус окна
        /// </summary>
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region Команды
        public ICommand CloseApplicationCommand {  get; }
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        // Команда доступна всегда для выполенения
        private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion

        public MainVindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}
