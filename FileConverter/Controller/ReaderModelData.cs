using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.Controller
{
    internal class ReaderModelData : IReader
    {
        ReaderModelData(string filename)
        {
            IReader.filename = filename;    
        }

        public void Read()
        {
        }

    }
}
