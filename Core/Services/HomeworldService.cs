using Core.Entities;
using Core.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{    
    public class HomeworldService : IHomeworldService
    {
        private readonly IHomeworldRepository _homeworldRepository;

        public HomeworldService(IHomeworldRepository homeworldRepository)
        {
            _homeworldRepository = homeworldRepository;
        }

        public Homeworld GetByName(string name)
        {
            return _homeworldRepository.GetByName(name);
        }
    }
}
