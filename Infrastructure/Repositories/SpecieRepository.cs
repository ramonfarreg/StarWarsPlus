using Core.Entities;
using Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DAL.Mapper;
using Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class SpecieRepository : BaseRepository, ISpecieRepository
    {
        public SpecieRepository(StarWarsPlusContext context) : base(context)
        { }

        public Specie GetByName(string name)
        {
            var item = _context.Specie.AsNoTracking().Where(i => i.Name == name).FirstOrDefault();
            return Mapper.Map<Core.Entities.Specie>(item);

        }
    }
}
