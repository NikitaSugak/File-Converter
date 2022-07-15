using FileConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.Controller.Reader
{
    internal interface IReader
    {
        static string? filename { set; private protected get; }

        static List<News> news = new List<News>();
        void Read();
    }
}
