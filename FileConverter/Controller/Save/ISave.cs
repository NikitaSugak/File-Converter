using Microsoft.Win32;
using System.Windows;

namespace FileConverter.Controller.Save
{
    internal interface ISave
    {
        public static string? Filename { set;  get; }

        public static bool Create { private set; get; } = true;
        public static void OpenFileDialogScreen(string format, string extension)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{format} (*.{extension})|*.{extension}";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                Filename = saveFileDialog.FileName;
            }
            else
            {
                Create = false;
                MessageBox.Show("You didn't save the file.", "Message");
            }
        }

        void CreateFile();

        void SaveFile();

        void Save();
    }
}
