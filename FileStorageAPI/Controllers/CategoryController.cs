using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using FileStorageAPI.Services;

namespace FileStorageAPI.Controllers
{
    public class CategoryController : BaseCrudController<ICategoryService, CategoryDTO,Category>
    {
        public CategoryController(ICategoryService baseCrudService) : base(baseCrudService)
        {
        }
    }
}
