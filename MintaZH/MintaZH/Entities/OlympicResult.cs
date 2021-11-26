using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH.Entities
{
    internal class OlympicResult
    {
        public int Year { get; set; }

        public string Country { get; set; }

        public int[] vs { get; set; }

        public int Position { get; set; } 
    }
}
