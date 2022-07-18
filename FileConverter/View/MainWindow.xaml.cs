using FileConverter.Controller.Reader;
using FileConverter.Controller.Save;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms

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

        async private void Recognize_Click(object sender, RoutedEventArgs e)
        {
            IReader.news.Clear();

            if (RegularExpression.IsChecked == true)
            {
                ReaderRegularExpression reader = new ReaderRegularExpression();
                await Task.Run(() => reader.Read());
            }

            if (XmlDocument.IsChecked == true)
            {
                ReaderModelData reader = new ReaderModelData();
                await Task.Run(() => reader.Read());
            }

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
            if (IReader.news.Count != 0 && !File.Exists(ISave.Filename))
            {
                MessageBoxResult result = MessageBox.Show("Data not saved. Do you really want to leave?", "Message", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    Application.Current.Exit();
                }
            }
            else
            {
                Application.Current.Shutdown();
            }

        }
    }
}
