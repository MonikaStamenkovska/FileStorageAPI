using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using FileStorageAPI.Services;

namespace FileStorageAPI.Controllers
{
    public class ProductController : BaseCrudController<IProductService, ProductDTO,Product>
    {
        public ProductController(IProductService baseCrudService) : base(baseCrudService)
        {
        }

        
    }
}
