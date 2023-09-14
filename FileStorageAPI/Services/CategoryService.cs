using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using Microsoft.Extensions.Options;

namespace FileStorageAPI.Services
{
    public class CategoryService : BaseCrudService<CategoryDTO, Category>, ICategoryService
    {
        public CategoryService(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }
    }
}
