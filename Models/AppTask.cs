namespace Testing.Models
{
    /// <summary>
    /// Перечисления статусов выполнения задачи.
    /// </summary>
    public enum AppTaskState
    {
        InProgress,
        Completed
    }

    /// <summary>
    /// Модель для представления задач.
    /// </summary>
    internal sealed class AppTask : BaseModel
    {
        #region Поля и свойства

        /// <summary>
        /// Статус выполнения задачи.
        /// </summary>
        public AppTaskState State { get; set; } = AppTaskState.InProgress;
        #endregion Поля и свойства

        #region Конструктор
        public AppTask(int id, string name) : base(id, name)
        {
            this.Type = ModelType.Задача;
        }
        #endregion Конструктор
    }
}
