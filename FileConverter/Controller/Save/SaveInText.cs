using System.Globalization;
using System.Text;
using FileConverter.Controller.Reader;

namespace FileConverter.Controller.Save
{
    internal class SaveInText : ISave
    {
        string? text { set; get; }
        public void CreateFile()
        {
            StringBuilder str = new StringBuilder();

            CultureInfo culture = new CultureInfo("en-US");
            for (int i = 0; i < IReader.news.Count; i++)
            {
                str.Append($"News #{i + 1}\n");
                str.Append($"\tTitle: {IReader.news[i].Title}\n");
                str.Append($"\tLink: {IReader.news[i].Link}\n");
                str.Append($"\tDescription: {IReader.news[i].Description}\n");
                str.Append($"\tCategory: {IReader.news[i].Category}\n");
                str.Append($"\tDate: {IReader.news[i].PubDate.ToString("ddd, dd MMM yyyy HH:mm:ss", culture)}\n");
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

        public void Save()
        {
            CreateFile();
            SaveFile();
        }
    }
}
