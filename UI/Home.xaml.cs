using cst8333ProjectByJacobPaulin.Csv;
using cst8333ProjectByJacobPaulin.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace cst8333ProjectByJacobPaulin.UI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            Debug.WriteLine($"Refresh records");
            RefreshRecordList();
        }

        #region Interaction Events
        private void ButtonRefresh(object sender, RoutedEventArgs e) => RefreshRecordList();

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            _ = MainWindow.CSV.WriteContents(MainWindow.CSV.FilePath);
        }

        private void ButtonSaveToFile(object sender, RoutedEventArgs e) 
        {
            Log($"Save to file button pushed, gathered input of \"{TextBoxFilePath.Text}\"");
            Log($"Validating file name \"{TextBoxFilePath.Text}\", results: {MainWindow.CheckFileName(TextBoxFilePath.Text)}");
            if (MainWindow.CheckFileName(TextBoxFilePath.Text))
            {
                Log($"File name valid");
                MainWindow.CSV.WriteContents($"./Csv/Dataset/{TextBoxFilePath.Text}");
            }
            else
            {
                Log($"File name not valid");
                MessageBox.Show("Invalid file name!");
            }
        }

        private void ListRecordsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new RecordView((VegetableRecord)e.AddedItems[0]));
        }
        #endregion

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] {msg}");

        private void RefreshRecordList(bool refreshCsv = false)
        {
            Debug.WriteLine($"Reloading CSV file: {MainWindow.CSV.FilePath}");
            MainWindow.CSV.RefreshContent();
            ListRecords.ItemsSource = MainWindow.CSV.Contents;
        }
        #endregion
    }
}
