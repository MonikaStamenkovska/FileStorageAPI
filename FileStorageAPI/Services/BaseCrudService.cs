using FileStorageAPI.DTOs;
using FileStorageAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace FileStorageAPI.Services
{
    public class BaseCrudService<TDTO,TEntity> : IBaseCrudService<TDTO,TEntity> where TDTO : BaseEntityDTO, new()
        where TEntity : BaseEntity
        
    {
        private string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly IOptions<AppSettings> _appSettings;

        public BaseCrudService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public List<TDTO> Get()
        {
            List<TDTO> resultList = new List<TDTO>();
            string folderName = projectPath + "\\" + _appSettings.Value.MainFolderName + "\\" + typeof(TDTO).Name.Replace("DTO", "");

            if (!Directory.Exists(folderName))
            {
                return resultList;
            }

            string[] files = Directory.GetFiles(folderName);
            foreach (var file in files)
            {
                string fileContent = File.ReadAllText(file);
                TDTO dto = JsonConvert.DeserializeObject<TDTO>(fileContent);
                resultList.Add(dto);
            }
            return resultList;
        }
        public TDTO Get(Guid id)
        {
            string filePath = projectPath + "\\" + _appSettings.Value.MainFolderName + "\\" + typeof(TDTO).Name.Replace("DTO", "") + "\\" + id;
            if (!File.Exists(filePath))
            {
                return new TDTO();
            }
            string fileContent = File.ReadAllText(filePath);
            TDTO resultObject = JsonConvert.DeserializeObject<TDTO>(fileContent);
            return resultObject;
        }
        public void Post(TDTO dtoElement)
        {
            string folderPath = projectPath + "\\" + _appSettings.Value.MainFolderName + "\\" + typeof(TDTO).Name.Replace("DTO", "");
            string filePath = folderPath + "\\" + dtoElement.Id;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(folderPath);
            }
            TEntity elementToAdd = MapDtoToEntity(dtoElement);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(elementToAdd));
        }

        public void Put(Guid id, TDTO dtoElement)
        {
            string filePath = projectPath + "\\" + _appSettings.Value.MainFolderName + "\\" + typeof(TDTO).Name.Replace("DTO", "") + "\\" + id;
            TEntity elementToUpdate = MapDtoToEntity(dtoElement);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(elementToUpdate));
        }

        public void Delete(Guid id)
        {
            string fileName = projectPath + "\\" + _appSettings.Value.MainFolderName + "\\" + typeof(TDTO).Name.Replace("DTO", "") + "\\" + id;
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        public virtual TEntity MapDtoToEntity(TDTO dto)
        {
            string dtoData = JsonConvert.SerializeObject(dto);
            TEntity entityObject = JsonConvert.DeserializeObject<TEntity>(dtoData);            
            return entityObject;
        }
    }
}
