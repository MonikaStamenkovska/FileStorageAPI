using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;

namespace FileStorageAPI.Services
{
    public interface IProductService : IBaseCrudService<ProductDTO,Product>
    {
    }
}
