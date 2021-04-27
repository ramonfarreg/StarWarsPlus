using Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public abstract class BaseRepository
    {
        protected readonly StarWarsPlusContext _context;

        public BaseRepository(StarWarsPlusContext context)
        {
            _context = context;
        }
}
}
