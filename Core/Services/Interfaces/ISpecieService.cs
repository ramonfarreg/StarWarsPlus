using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface ISpecieService
    {
        Core.Entities.Specie GetByName(string name);

    }
}
