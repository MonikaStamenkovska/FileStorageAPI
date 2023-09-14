namespace FileStorageAPI.DTOs
{
    public class ProductDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Decription { get; set; }
    }
}
