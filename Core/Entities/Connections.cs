using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Connections
    {
        public int Count { get; set; }
        public IEnumerable<string> results { get; set; }
    }
}
