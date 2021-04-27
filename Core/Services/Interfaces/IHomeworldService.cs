using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IHomeworldService
    {
        Core.Entities.Homeworld GetByName(string name);

    }
}
