using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.Controller
{
    internal class ReaderRegularExpression : IReader
    {
        ReaderRegularExpression(string filename)
        {
            IReader.filename = filename;
        }
        public void Read()
        {
            
        }
    }
}
