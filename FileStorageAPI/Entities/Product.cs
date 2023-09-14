namespace FileStorageAPI.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Decription { get; set; }
    }
}
