using Core.Entities;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHomeworldService _homeworldService;
        private readonly ISpecieService _specieService;

        public UserService(IUserRepository userRepository, IHomeworldService homeworldService, ISpecieService specieService)
        {
            _userRepository = userRepository;
            _homeworldService = homeworldService;
            _specieService = specieService;
        }

        /// <returns>Returns true on success, otherwise returns false</returns>
        public bool Add(User user)
        {
            var homeworld = _homeworldService.GetByName(user.Homeworld.Name);
            if (homeworld == null)
                return false;

            var specie = _specieService.GetByName(user.Specie.Name);
            if (specie == null)
                return false;

            user.Homeworld.Id = homeworld.Id;
            user.Specie.Id = specie.Id;
            user.Created = DateTime.Now;
            user.Edited = user.Created;
            return _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        /// <returns>Returns true on success, otherwise returns false</returns>
        public bool Update(User user)
        {
            var homeworld = _homeworldService.GetByName(user.Homeworld.Name);
            if (homeworld == null)
                return false;

            var specie = _specieService.GetByName(user.Specie.Name);
            if (specie == null)
                return false;

            user.Homeworld.Id = homeworld.Id;
            user.Specie.Id = specie.Id;
            user.Edited = DateTime.Now;
            return _userRepository.Update(user);
        }

        public Connections GetConnections(string homeworld)
        {
           var items = _userRepository.GetByHomeworld(homeworld);

            return new Connections
            {
                Count = items.Count(),
                results = items.Select(i => i.Name).ToList()
            };
        }
    }
}
