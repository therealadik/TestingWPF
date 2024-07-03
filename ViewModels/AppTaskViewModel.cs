using System.Collections.ObjectModel;
using Testing.Models;

namespace Testing.ViewModels
{
    /// <summary>
    /// ViewModel класс для AppTask модели.
    /// </summary>
    internal sealed class AppTaskViewModel : BaseViewModel
    {
        #region Поля и свойства
        /// <summary>
        /// Список состояний задачи.
        /// </summary>
        public ObservableCollection<AppTaskState> States { get; set; } = [AppTaskState.InProgress, AppTaskState.Completed];

        /// <summary>
        /// Привязанная задача.
        /// </summary>
        private AppTask appTask;

        public int Id => appTask.Id;

        public string Name
        {
            get
            {
                return appTask.Name;
            }

            set
            {
                if (appTask.Name != value)
                {
                    appTask.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Тип модели (Задача или документ).
        /// </summary>
        public string Type => appTask.Type.ToString();

        public string Body
        {
            get
            {
                return appTask.Body;
            }

            set
            {
                if (appTask.Body != value)
                {
                    appTask.Body = value;
                    OnPropertyChanged();
                }
            }
        }

        public AppTaskState State
        {
            get
            {
                return appTask.State;
            }

            set
            {
                if (appTask.State != value)
                {
                    appTask.State = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Конструктор

        /// <summary>
        /// </summary>
        /// <param name="task">Привязанная задача./param>
        public AppTaskViewModel(AppTask task)
        {
            this.appTask = task;
        }
        #endregion Конструктор
    }
}
