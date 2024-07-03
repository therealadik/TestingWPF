namespace Testing.Models
{
    /// <summary>
    /// Перечисления типов модели.
    /// </summary>
    public enum ModelType
    {
        Документ,
        Задача
    }

    /// <summary>
    /// Базовый класс для представления модели.
    /// </summary>
    internal abstract class BaseModel
    {
        #region Поля и свойства
        /// <summary>
        /// Тип модели.
        /// </summary>
        public ModelType Type { get; protected set; }

        /// <summary>
        /// Индентификатор.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тело.
        /// </summary>
        public string Body { get; set; } = string.Empty;
        #endregion Поля и свойства

        #region Конструктор
        public BaseModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        #endregion Конструктор
    }
}
