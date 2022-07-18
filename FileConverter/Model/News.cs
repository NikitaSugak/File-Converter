using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileConverter.Model
{
    internal class News
    {
        public string Title { get; }
        public string Link { get; }
        public string Description { get; }
        public string Category { get; }
        public DateTime PubDate { get; private set; }


        public News(string title, string link, string description, string category, string pubDate)
        {
            Title = title;
            Link = link;
            Description = description;
            Category = category;
            setDate(pubDate);
        }

        private void setDate(string date)
        {
            //Удобно распарсить дату с помощью метода ParseExact, но мы должны быть уверены,
            //что строка даты имеет только такой формат. В будущем, источник файла xml, может изменить формат
            //строки, тогда придётся менять код. Универсальнее использовать способ, который написан в методе
            //Read класса ReaderRegularExpression.
            PubDate = DateTime.ParseExact(date, "ddd, dd MMM yyyy HH:mm:ss", new CultureInfo("en-US"));
        }
    }
}
