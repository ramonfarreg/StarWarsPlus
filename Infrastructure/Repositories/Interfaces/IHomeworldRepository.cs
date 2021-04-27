using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IHomeworldRepository
    {
        Core.Entities.Homeworld GetByName(string name);
    }
}
