using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<Core.Entities.User> GetAll();
        Core.Entities.User Get(int id);

        /// <returns>Returns true on success, otherwise returns false</returns>
        bool Add(Core.Entities.User user);
        void Delete(int id);

        /// <returns>Returns true on success, otherwise returns false</returns>
        bool Update(Core.Entities.User user);
        IEnumerable<Core.Entities.User> GetByHomeworld(string homeworld);

    }
}
