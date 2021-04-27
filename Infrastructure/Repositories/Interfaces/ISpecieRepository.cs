using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ISpecieRepository
    {
        Core.Entities.Specie GetByName(string name);
    }
}
