namespace Testing.Models
{
    /// <summary>
    /// Модель для представления документа.
    /// </summary>

    internal sealed class Document: BaseModel
    {
        #region Поля и свойства
        /// <summary>
        /// Подпись документа.
        /// </summary>
        public Guid DigitalSignature { get; set; } = Guid.Empty;
        #endregion Поля и свойства

        #region Конструктор
        public Document(int id, string name) : base(id, name)
        {
            this.Type = ModelType.Документ;
        }
        #endregion Конструктор
    }
}
