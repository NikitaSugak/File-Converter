using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace FileConverter.Controller.Save
{
    internal interface ISave
    {
        private protected static string? Filename { private set;  get; }
        public static void OpenFileDialogScreen()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "text files (*.txt)|*.txt";
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
                MessageBox.Show("You didn't save the file.", "Message");
            }
        }


        void CreateFile();

        void SaveFile();
    }
}
