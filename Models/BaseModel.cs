namespace Testing.Models
{
    public enum ModelType
    {
        Документ,
        Задача
    }

    internal abstract class BaseModel
    {
        public ModelType Type { get; protected set; }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Body { get; set; } = string.Empty;

        public BaseModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
