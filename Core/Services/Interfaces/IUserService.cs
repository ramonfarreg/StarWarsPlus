using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Get(int id);

        /// <returns>Returns true on success, otherwise returns false</returns>
        bool Add(User user);
        void Delete(int id);

        /// <returns>Returns true on success, otherwise returns false</returns>
        bool Update(User user);
        Connections GetConnections(string homeworld);
    }
}
