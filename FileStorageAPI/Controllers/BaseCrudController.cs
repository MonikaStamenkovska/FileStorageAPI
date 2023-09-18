using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using FileStorageAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageAPI.Controllers
{
    [ApiController]
    public class BaseCrudController<TService, TDTO, TEntity,TController> : ControllerBase
         where TService : IBaseCrudService<TDTO, TEntity>
         where TDTO : BaseEntityDTO
         where TEntity : BaseEntity
         where TController : ControllerBase
    {
        private readonly TService _baseCrudService;
        private readonly ILogger<TController> _logger;
        public BaseCrudController(TService baseCrudService, ILogger<TController> logger)
        {
            _baseCrudService = baseCrudService;
            _logger = logger;
        }

        [HttpGet]
        public List<TDTO> Get()
        {
            _logger.LogInformation(typeof(TDTO).Name + " -> Get method");
            return _baseCrudService.Get();
        }

        [HttpGet("{id}")]
        public TDTO Get(Guid id)
        {
            _logger.LogInformation(typeof(TDTO).Name + " -> Get by id method");
            return _baseCrudService.Get(id);
        }

        [HttpPost]
        public void Post(TDTO element)
        {
            _logger.LogInformation(typeof(TDTO).Name + " -> Post method");
            _baseCrudService.Post(element);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, TDTO element)
        {
            _logger.LogInformation(typeof(TDTO).Name + " -> Put method");
            _baseCrudService.Put(id, element);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _logger.LogInformation(typeof(TDTO).Name + " -> Delete method");
            _baseCrudService.Delete(id);
        }
    }
}
