using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;

namespace FileStorageAPI.Services
{
    public interface IBaseCrudService<TDTO,TEntity> 
        where TDTO : BaseEntityDTO
    {
        List<TDTO> Get();
        TDTO Get(Guid id);
        void Post(TDTO element);
        void Put(Guid id, TDTO element);
        void Delete(Guid id);
        TEntity MapDtoToEntity(TDTO dto);
    }
}
