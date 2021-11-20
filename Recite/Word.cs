using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recite
{
    class Word
    {
        public string Name { get; protected set; }
        public string Defination { get; protected set; }
        public int Extent { get; set; } = 1;
        public Word(string name, string definition)
        {
            Name = name;
            Defination = definition;
        }
    }
}
