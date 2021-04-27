using Infrastructure.DAL;
using Infrastructure.DAL.Mapper;
using Infrastructure.DAL.Model;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(StarWarsPlusContext context) : base(context) 
        { }

        /// <returns>Returns true on success, otherwise returns false</returns>
        public bool Add(Core.Entities.User user)
        {
            var item = Mapper.Map<User>(user);

            try
            {
                item.Homeworld = null;
                item.Specie = null;
                _context.User.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var item = _context.User.Find(id);
            _context.User.Remove(item);
            _context.SaveChanges();
        }

        public Core.Entities.User Get(int id)
        {
            var item = _context.User.AsNoTracking().Include("Homeworld").Include("Specie").Where(i => i.Id == id).FirstOrDefault();
            return Mapper.Map<Core.Entities.User>(item);
        }

        public IEnumerable<Core.Entities.User> GetAll()
        {
            var items = _context.User.AsNoTracking().Include("Homeworld").Include("Specie").ToList();
            return Mapper.Map<IEnumerable<Core.Entities.User>>(items);
        }

        /// <returns>Returns true on success, otherwise returns false</returns>
        public bool Update(Core.Entities.User user)
        {
            var item = Mapper.Map<User>(user);
            try
            {
                _context.User.Update(item);
                _context.Entry(item).Property(x => x.Created).IsModified = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Core.Entities.User> GetByHomeworld(string homeworld)
        {
            var items = _context.User.AsNoTracking().Include("Homeworld").Where(i => i.Homeworld.Name == homeworld);
            return Mapper.Map<IEnumerable<Core.Entities.User>>(items);
        }
    }
}
