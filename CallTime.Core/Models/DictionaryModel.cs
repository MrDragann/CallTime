namespace CallTime.Core.Models
{
    public class DictionaryModel
    {
        public DictionaryModel() { }

        public DictionaryModel(int id, string value)
        {
            Id = id;
            Name = value;
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
