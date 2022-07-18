using FileConverter.Controller.Reader;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Windows;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace FileConverter.Controller.Save
{
    internal class SaveInExcel : ISave
    {
        string? text { set; get; }

        Application app = new Application();

        Workbook workbook;

        public void CreateFile()
        {
            app.SheetsInNewWorkbook = 1;
            app.Workbooks.Add();

            workbook = app.Workbooks[1];
            Worksheet sheet = workbook.Sheets[1];
            
            Range cell = sheet.get_Range("A1", "A1");
            cell.Value2 = "#";
            cell.Font.Bold = true;
            cell = sheet.get_Range("B1", "B1");
            cell.Value2 = "Title";
            cell.Font.Bold = true;  
            cell = sheet.get_Range("C1", "C1");
            cell.Value2 = "Link";
            cell.Font.Bold = true;
            cell = sheet.get_Range("D1", "D1");
            cell.Value2 = "Description";
            cell.Font.Bold = true;
            cell = sheet.get_Range("E1", "E1");
            cell.Value2 = "Category";
            cell.Font.Bold = true;
            cell = sheet.get_Range("F1", "F1");
            cell.Value2 = "Date";
            cell.Font.Bold = true;

            CultureInfo culture = new CultureInfo("en-US");
            for (int i = 0; i < IReader.news.Count; i++)
            {
                cell = sheet.get_Range($"A{i + 2}", $"A{i + 2}");
                cell.Value2 = i + 1;
                cell.ColumnWidth = 3;
                cell.VerticalAlignment = XlVAlign.xlVAlignTop;
                cell = sheet.get_Range($"B{i + 2}", $"B{i + 2}");
                cell.Value2 = IReader.news[i].Title;
                cell.ColumnWidth = 20;
                cell.WrapText = true;
                cell.VerticalAlignment = XlVAlign.xlVAlignTop;
                cell = sheet.get_Range($"C{i + 2}", $"C{i + 2}");
                cell.Value2 = IReader.news[i].Link;
                cell.ColumnWidth = 20;
                cell.WrapText = true;
                cell.VerticalAlignment = XlVAlign.xlVAlignTop;
                cell.Font.Italic = true;
                cell = sheet.get_Range($"D{i + 2}", $"D{i + 2}");
                cell.Value2 = IReader.news[i].Description;
                cell.ColumnWidth = 60;
                cell.WrapText = true;
                cell.VerticalAlignment = XlVAlign.xlVAlignTop;
                cell = sheet.get_Range($"E{i + 2}", $"E{i + 2}");
                cell.Value2 = IReader.news[i].Category;
                cell.ColumnWidth = 30;
                cell.WrapText = true;
                cell.VerticalAlignment = XlVAlign.xlVAlignTop;
                cell = sheet.get_Range($"F{i + 2}", $"F{i + 2}");
                cell.Value2 = IReader.news[i].PubDate.ToString("ddd, dd MMM yyyy HH:mm:ss", culture);
                cell.ColumnWidth = 25;
                cell.Font.Italic = true;
                cell.VerticalAlignment = XlVAlign.xlVAlignTop;
            }
        }

        public void SaveFile()
        {
            if (ISave.Filename != null)
            {
                app.DisplayAlerts = false;
                try
                {
                    workbook.SaveAs(ISave.Filename);
                }
                catch
                {
                    MessageBox.Show("This file is open. Please close this file and try again", "Message");
                }
            }

            workbook.Close();
            app.Quit();
        }

        public void Save()
        {
            CreateFile();
            SaveFile();
        }
    }
}
