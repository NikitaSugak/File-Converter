using FileConverter.Model;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace FileConverter.Controller.Reader
{
    internal class ReaderRegularExpression : IReader
    {
        public void Read()
        {
            string text = File.ReadAllText(IReader.filename);

            //Искать данные в файле можно было бы с помощью одного регулярного выражения, но в этом случае 
            //мы должны быть уверены, что этот файл имеет только такую структуру.
            //Этот же способ, будет работать даже если теги в xml будут написаны в другом порядке. 
            //В контенте тегов может содержаться закрываюший тег, распознование все равно будет корретным.
            Regex reges = new Regex(@"(<title>)(?<title>.*)(</title>)");
            MatchCollection title = reges.Matches(text);
            reges = new Regex(@"(<link>)(?<link>.*)(</link>)");
            MatchCollection link = reges.Matches(text);
            reges = new Regex(@"(<description>)(?<description>.*)(</description>)");
            MatchCollection description = reges.Matches(text);
            reges = new Regex(@"(<category>)(?<category>.*)(</category>)");
            MatchCollection category = reges.Matches(text);
            reges = new Regex(@"(<pubDate>)(?<pubDate>.*)(</pubDate>)");
            MatchCollection pubDate = reges.Matches(text);

            bool error = false;
            for (int i = 0; i < title.Count; i++)
            {
                try
                {
                    News news = new News(title[i].Groups["title"].Value,
                                         link[i].Groups["link"].Value,
                                         description[i].Groups["description"].Value,
                                         category[i].Groups["category"].Value,
                                         pubDate[i].Groups["pubDate"].Value);
                    IReader.news.Add(news);
                }
                catch
                {
                    error = true;
                }
            }

            if (error)
            {
                MessageBox.Show("One or more tags were not found.",
                                "Message");
            }
            else
            {
                MessageBox.Show("Recognition was successful. Now you can save the file",
                                "Message");
            }
        }
    }
}
