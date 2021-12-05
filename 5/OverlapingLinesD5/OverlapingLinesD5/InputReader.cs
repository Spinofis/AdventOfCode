using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OverlapingLinesD5
{
    class InputReader
    {
        private string path;
        public InputReader(string _path) => path = _path;
        public List<string> Read() => File.ReadAllLines(path).ToList();
    }
}
