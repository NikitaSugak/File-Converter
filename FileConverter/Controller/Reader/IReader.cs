using FileConverter.Model;
using System.Collections.Generic;

namespace FileConverter.Controller.Reader
{
    internal interface IReader
    {
        static string? filename { set; private protected get; }

        static List<News> news = new List<News>();
        void Read();
    }
}
