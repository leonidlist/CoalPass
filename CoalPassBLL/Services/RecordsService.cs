using AutoMapper;
using CoalPassBLL.DTO;
using CoalPassDAL.Abstractions;
using CoalPassDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalPassBLL.Services
{
    public class RecordsService : IService<RecordDTO>
    {
        private readonly IAsyncRepository<Password> _repository;
        private readonly IMapper _mapper;

        public RecordsService(IAsyncRepository<Password> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = new MapperConfiguration(x => 
            {
                x.CreateMap<Password, RecordDTO>();
                x.CreateMap<RecordDTO, Password>();
            }).CreateMapper();
        }

        public Task Add(RecordDTO item)
        {
            var record = _mapper.Map<Password>(item);
            return _repository.Add(record);
        }

        public async Task<RecordDTO> Get(string id)
        {
            var result = await _repository.Get(id);
            return _mapper.Map<RecordDTO>(result);
        }

        public async Task<IEnumerable<RecordDTO>> GetAll()
        {
            var result = await _repository.GetAll();
            return result.Select(x => _mapper.Map<RecordDTO>(x));
        }

        public Task Remove(string id)
        {
            return _repository.Remove(id);
        }

        public Task Update(RecordDTO item)
        {
            var record = _mapper.Map<Password>(item);
            return _repository.Update(record);
        }
    }
}
