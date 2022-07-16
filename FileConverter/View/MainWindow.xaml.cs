using FileConverter.Controller.Reader;
using FileConverter.Controller.Save;
using FileConverter.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                IReader.filename = openFileDialog.FileName;

                RegularExpression.IsEnabled = true;
                XmlDocument.IsEnabled = true;
            }
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Recognize_Click(object sender, RoutedEventArgs e)
        {
            ReaderModelData reader = new ReaderModelData();
            reader.Read();

            ISave.Filename = null;
            Text.IsEnabled = true;
            Excel.IsEnabled = true;
            Word.IsEnabled = true;
        }

        async private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Excel.IsChecked == true)
            {
                ISave.OpenFileDialogScreen("Document Excel", "xlsx");
                if (ISave.Create)
                {
                    SaveInExcel excel = new SaveInExcel();
                    await Task.Run(() => excel.Save());
                }
            }
            else if (Word.IsChecked == true)
            {
                ISave.OpenFileDialogScreen("Document Word", "docx");
                if (ISave.Create)
                {
                    SaveInWord word = new SaveInWord();
                    await Task.Run(() => word.Save());
                }
            }
            else if (Text.IsChecked == true)
            {
                ISave.OpenFileDialogScreen("Text file", "txt");
                if (ISave.Create)
                {
                    SaveInText text = new SaveInText();
                    await Task.Run(() => text.Save());
                }
            }
        }

        private void Recognition_Checked(object sender, RoutedEventArgs e)
        {
            Recognize.IsEnabled = true;
        }

        private void Conversion_Checked(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = true;
        }

        private void Closing_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ISave.Filename))
            {
                MessageBox.Show("Добавить подтверждение закрытия, если файл не сохранён", "Message");
            }

            Application.Current.Shutdown();
        }
    }
}
