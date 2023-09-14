using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;

namespace FileStorageAPI.Services
{
    public interface ICategoryService : IBaseCrudService<CategoryDTO,Category>
    {
    }
}
