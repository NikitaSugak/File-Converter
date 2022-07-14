using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.Controller
{
    internal interface IReader
    {
        static string filename;
        void Read();

    }
}
