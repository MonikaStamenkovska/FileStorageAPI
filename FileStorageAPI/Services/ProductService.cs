using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using Microsoft.Extensions.Options;

namespace FileStorageAPI.Services
{
    public class ProductService : BaseCrudService<ProductDTO, Product>, IProductService
    {
        public ProductService(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }
        public override Product MapDtoToEntity(ProductDTO dto)
        {
            Product entity = base.MapDtoToEntity(dto);
            entity.Price = entity.Price + 10;
            return entity;
        }

    }
}
