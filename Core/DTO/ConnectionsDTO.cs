using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class ConnectionsDTO
    {
        public int Count { get; set; }
        public IEnumerable<string> results { get; set; }
    }
}
