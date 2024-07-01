namespace Testing.Models
{
    /// <summary>
    /// Модель для представления задач.
    /// </summary>
    public enum AppTaskState
    {
        InProgress,
        Completed
    }

    internal class AppTask: BaseModel
    {
        public AppTaskState State { get; set; }

        public AppTask(int id, string name, AppTaskState state = AppTaskState.InProgress) : base(id, name)
        {
            this.Type = ModelType.Задача;
            this.State = state;
        }
    }
}
