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
    public class UsersService : IService<UserDTO>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public UsersService(IAsyncRepository<User> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<User, UserDTO>();
                x.CreateMap<UserDTO, User>();
            }).CreateMapper();
        }

        public Task Add(UserDTO item)
        {
            var user = _mapper.Map<User>(item);
            return _repository.Add(user);
        }

        public async Task<UserDTO> Get(string id)
        {
            var result = await _repository.Get(id);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var result = await _repository.GetAll();
            return result.Select(x => _mapper.Map<UserDTO>(x));
        }

        public Task Remove(string id)
        {
            return _repository.Remove(id);
        }

        public Task Update(UserDTO item)
        {
            var user = _mapper.Map<User>(item);
            return _repository.Update(user);
        }
    }
}
