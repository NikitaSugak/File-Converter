using FileConverter.Controller.Reader;
using Microsoft.Office.Interop.Word;
using System.Windows;
using Application = Microsoft.Office.Interop.Word.Application;

namespace FileConverter.Controller.Save
{
    internal class SaveInWord : ISave
    {
        string? text { set; get; }

        Application app = new Application();

        Document doc;

        public void CreateFile()
        {
            doc = app.Documents.Add(Visible: false);

            Range range = doc.Range(0, 0);
            range.Text = $"NEWS\n";

            for (int i = 0; i < IReader.news.Count; i++)
            {
                range = doc.Range(range.End, range.End);
                range.Text = $"News #{i + 1}\n";
                range.Bold = 0;

                range = doc.Range(range.End, range.End);
                range.Text = "Title: ";
                range.Bold = 20;

                range = doc.Range(range.End, range.End);
                range.Text = IReader.news[i].Title + "\n";
                range.Bold = 0;

                range = doc.Range(range.End, range.End);
                range.Text = "Link: ";
                range.Bold = 20;

                range = doc.Range(range.End, range.End);
                range.Text = IReader.news[i].Link + "\n";
                range.Bold = 0;

                range = doc.Range(range.End, range.End);
                range.Text = "Description: ";
                range.Bold = 20;

                range = doc.Range(range.End, range.End);
                range.Text = IReader.news[i].Description + "\n";
                range.Bold = 0;

                range = doc.Range(range.End, range.End);
                range.Text = "Category: ";
                range.Bold = 20;

                range = doc.Range(range.End, range.End);
                range.Text = IReader.news[i].Category + "\n";
                range.Bold = 0;

                range = doc.Range(range.End, range.End);
                range.Text = "Date: ";
                range.Bold = 20;

                range = doc.Range(range.End, range.End);
                range.Text = IReader.news[i].PubDate + "\n";
                range.Bold = 0;
            }
        }

        public void SaveFile()
        {
            if (ISave.Filename != null)
            {
                try
                {
                    doc.SaveAs2(FileName: ISave.Filename);
                    doc.Close();

                    app.Quit();
                }
                catch
                {
                    MessageBox.Show("This file is open. Please close this file and try again", "Message");
                }
            }

        }

        public void Save()
        {
            CreateFile();
            SaveFile();
            
        }
    }
}
