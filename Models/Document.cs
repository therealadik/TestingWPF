namespace Testing.Models
{
    /// <summary>
    /// Модель для представления документа.
    /// </summary>

    internal class Document: BaseModel
    {
        public Guid DigitalSignature { get; set; } = Guid.Empty;

        public Document(int id, string name) : base(id, name)
        {
            this.Type = ModelType.Документ;
        }
    }
}
