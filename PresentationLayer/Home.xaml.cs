using cst8333ProjectByJacobPaulin.BusinessLayer;
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

namespace cst8333ProjectByJacobPaulin.PresentationLayer
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private DataController Controller;

        public Home()
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();

            // Register event listeners
            MainWindow.NewCsvSelected += new EventHandler(EventNewCsvSelected);

            // Initialize the list of records by refreshing
            RefreshRecordList();
        }

        #region Event Methods
        private void EventNewCsvSelected(object sender, EventArgs e)
        {
            Log($"(EventNewCsvSelected) Heard event trigger for event \"NewCsvSelected\"");
            Log($"(EventNewCsvSelected) Refreshing the list of records");
            RefreshRecordList();
        }
        #endregion

        #region Interaction Events
        private void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            Log($"(ButtonRefresh) Refresh button was pushed");
            Log($"(ButtonRefresh) Refreshing the list of records");
            RefreshRecordList();
        }

        private void ButtonSaveToFile(object sender, RoutedEventArgs e) 
        {
            Log($"(ButtonSaveToFile) Save to file button pushed");
            Log($"(ButtonSaveToFile) Validating file name \"{TextBoxFilePath.Text}\", results: {MainWindow.CheckFileName(TextBoxFilePath.Text)}");
            if (MainWindow.CheckFileName(TextBoxFilePath.Text))
            {
                Log($"(ButtonSaveToFile) File name valid");
                bool operation = Controller.SaveToCsv($"./Csv/Dataset/{TextBoxFilePath.Text}");
                if (operation)
                {
                    Log($"(ButtonSaveToFile) Displaying success message");
                    MessageBox.Show("Successfully saved data");
                }
                else
                {
                    Log($"(ButtonSaveToFile) Displaying failed message");
                    MessageBox.Show("Failed to save data");
                }
            }
            else
            {
                Log($"(ButtonSaveToFile) File name not valid");
                Log($"(ButtonSaveToFile) Displaying file name not valid message");
                MessageBox.Show("Invalid file name!");
            }
        }

        private void ListRecordsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new RecordView((VegetableRecord)e.AddedItems[0]));
        }
        #endregion

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] Home.xaml.cs: {msg}");

        private void RefreshRecordList()
        {
            Log($"(RefreshRecordList) Refreshing list view with data from CSV file {Controller.FilePath}");
            LinkedList<VegetableRecord> records = Controller.ReadRecords();
            ListRecords.ItemsSource = records;
        }
        #endregion
    }
}
