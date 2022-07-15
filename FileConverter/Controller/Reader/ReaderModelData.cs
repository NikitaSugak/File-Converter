using FileConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace FileConverter.Controller.Reader
{
    internal class ReaderModelData : IReader
    {
        public void Read()
        {
            XmlDocument xmlFile = new XmlDocument();

            if (IReader.filename != null)
            {
                xmlFile.Load(IReader.filename);
                if (xmlFile.DocumentElement != null)
                {
                    bool error = false;
                    for (int i = 0; i < xmlFile.DocumentElement.ChildNodes.Count; i++)
                    {
                        XmlNode? xmlNode = xmlFile.DocumentElement.ChildNodes[i];
                        string title = "Default title";
                        string link = "Default link";
                        string description = "Default description";
                        string category = "Default category";
                        string pubDate = "Default pubDate";
                        try { title = xmlNode["title"].InnerText; } catch { error = true; }
                        try { link = xmlNode["link"].InnerText; } catch { error = true; }
                        try { description = xmlNode["description"].InnerText; } catch { error = true; }
                        try { category = xmlNode["category"].InnerText; } catch { error = true; }
                        try { pubDate = xmlNode["pubDate"].InnerText; } catch { error = true; }
                        News news = new News(title, link, description, category, pubDate);
                    }


                    if (error)
                    {
                        MessageBox.Show(
                       "Один или несколько тегов были не найдены. Применены значения по умолчанию",
                       "Сообщение");
                    }
                }
            }
            //foreach (XmlNode xmlNode in xmlFile.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            //Console.WriteLine(xmlNode.Attributes["currency"].Value + ": " + xmlNode.Attributes["rate"].Value);

        }
    }
}
