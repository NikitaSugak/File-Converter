using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.Model
{
    internal class News
    {
        public string Title { get; }
        public string Link { get; }
        public string Description { get; }
        public string Category { get; }
        public string PubDate { get; }


        public News(string title, string link, string description, string category, string pubDate)
        {
            Title = title;
            Link = link;
            Description = description;
            Category = category;
            PubDate = pubDate;
        }
    }
}
