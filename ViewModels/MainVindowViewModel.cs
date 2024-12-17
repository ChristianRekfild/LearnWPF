using LearnWPF.Infrastructure.Commands;
using LearnWPF.Models;
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

        #region Тестовые DataPoint
        /// <summary>
        /// Тестовый набор для визуализации графиков
        /// </summary>
        private IEnumerable<DataPoint> _testPoints;

        /// <summary>
        /// Тестовый набор для визуализации графиков
        /// </summary>
        public IEnumerable<DataPoint> TestPoints
        {
            get => _testPoints;
            set => Set(ref _testPoints, value);
        }
        #endregion

        #region Для теста
        //#region Команды
        //public ICommand CloseApplicationCommand {  get; }
        //private void OnCloseApplicationCommandExecuted(object p)
        //{
        //    Application.Current.Shutdown();
        //}

        //// Команда доступна всегда для выполенения
        //private bool CanCloseApplicationCommandExecute(object p) => true;
        //#endregion

        //public MainVindowViewModel()
        //{
        //    CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        //} 
        #endregion

        public MainVindowViewModel()
        {

            var dataPoints = new List<DataPoint>((int)( 360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double toRadius = Math.PI / 180;
                var y = Math.Sin(x * toRadius);

                dataPoints.Add(new DataPoint { XValue = x, YValue = y });
                TestPoints = dataPoints;
            }
        }


    }
}
