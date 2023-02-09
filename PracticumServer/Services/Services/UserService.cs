using AutoMapper;
using Common.Dto_s;
using Properties.Entities;
using Properties.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService:IDataService<UserDto>
    {
        private readonly IDataRepository<User> _IDataRepository;
        private readonly IMapper _mapper;
        public UserService(IDataRepository<User> IDataRepository, IMapper mapper)
        {
            _IDataRepository = IDataRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddAsync(UserDto entity)
        {
            User newUser = _mapper.Map<User>(entity);

            return _mapper.Map<UserDto>(await _IDataRepository.AddAsync(newUser));
        }

        public async Task DeleteAsync(string id)
        {
            await _IDataRepository.DeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return _mapper.Map<List<UserDto>>(await _IDataRepository.GetAllAsync());
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            return _mapper.Map<UserDto>(await _IDataRepository.GetByIdAsync(id));
        }


    }
}

