using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersCounter
{
    class NodeModel
    {
        public readonly string Name;
        public readonly string[] Words;

        public NodeModel(string name, string[] words)
        {
            Name = name;
            Words = words;
        }
    }
}
