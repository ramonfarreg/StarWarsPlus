using Core.Entities;
using Core.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{    
    public class SpecieService : ISpecieService
    {
        private readonly ISpecieRepository _specieRepository;

        public SpecieService(ISpecieRepository specieRepository)
        {
            _specieRepository = specieRepository;
        }

        public Specie GetByName(string name)
        {
            return _specieRepository.GetByName(name);
        }
    }
}
