using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using FileStorageAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageAPI.Controllers
{
    [ApiController]
    public class BaseCrudController<TService, TDTO, TEntity> : ControllerBase
         where TService : IBaseCrudService<TDTO, TEntity>
         where TDTO : BaseEntityDTO
         where TEntity : BaseEntity

    {
        private readonly TService _baseCrudService;
        public BaseCrudController(TService baseCrudService)
        {
            _baseCrudService = baseCrudService;
        }

        [HttpGet]
        public List<TDTO> Get()
        {
            return _baseCrudService.Get();
        }

        [HttpGet("{id}")]
        public TDTO Get(Guid id)
        {
            return _baseCrudService.Get(id);
        }

        [HttpPost]
        public void Post(TDTO element)
        {
            _baseCrudService.Post(element);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, TDTO element)
        {
            _baseCrudService.Put(id, element);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _baseCrudService.Delete(id);
        }
    }
}
