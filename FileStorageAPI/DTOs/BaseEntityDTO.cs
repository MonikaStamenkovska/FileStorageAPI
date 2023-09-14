namespace FileStorageAPI.DTOs
{
    public class BaseEntityDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}
