using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FileConverter.Controller.Reader;

namespace FileConverter.Controller.Save
{
    internal class SaveInText : ISave
    {
        string? text { set; get; }
        public void CreateFile()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < IReader.news.Count; i++)
            {
                str.Append($"News #{i + 1}\n");
                str.Append($"\t Title: {IReader.news[i].Title} \n");
                str.Append($"\t Link: {IReader.news[i].Link} \n");
                str.Append($"\t Description: {IReader.news[i].Description} \n");
                str.Append($"\t Category: {IReader.news[i].Category} \n");
                str.Append($"\t PubDate: {IReader.news[i].PubDate} \n");
            }

            text = str.ToString();
        }

        public void SaveFile()
        {
            if (ISave.Filename != null)
            {
                System.IO.File.WriteAllText(ISave.Filename, text);
            }
        }

        public SaveInText()
        {
            CreateFile();
            SaveFile();
        }


    }
}
