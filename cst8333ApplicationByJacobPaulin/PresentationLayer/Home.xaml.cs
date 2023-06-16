/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: Jun 13, 2023
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer;
using cst8333ApplicationByJacobPaulin.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace cst8333ApplicationByJacobPaulin.PresentationLayer
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    /// <author>Jacob Paulin</author>
    public partial class Home : Page
    {
        private DataController Controller;

        /// <summary>
        /// Constructor for the main window, in here
        /// we will run code that will initialize the
        /// user interface
        /// </summary>
        /// <author>Jacob Paulin</author>
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
        /// <summary>
        /// Interaction method triggered when a new CSV file
        /// from the dropdown list is selected. It will then 
        /// load that CSV file and display it's records
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void EventNewCsvSelected(object sender, EventArgs e)
        {
            Log($"(EventNewCsvSelected) Heard event trigger for event \"NewCsvSelected\"");
            Log($"(EventNewCsvSelected) Refreshing the list of records");
            RefreshRecordList();
        }
        #endregion

        #region Interaction Events
        /// <summary>
        /// Interaction method triggered when the refresh
        /// button is pushed, refreshes the record list and 
        /// updates the GUI
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            Log($"(ButtonRefresh) Refresh button was pushed");
            Log($"(ButtonRefresh) Refreshing the list of records");
            RefreshRecordList();
        }

        /// <summary>
        /// Interaction method triggered when the save record
        /// button is pushed, builds a new record object
        /// and tries to save it showing a failure or success
        /// message after.
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
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

        /// <summary>
        /// Interaction method triggered when a item from 
        /// records list is selected. It will display the record
        /// view page with the approriate record info.
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ListRecordsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new RecordView((VegetableRecord)e.AddedItems[0]));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simplyfied log method to add consistient formatting for all logs
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <author>Jacob Paulin</author>
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] Home.xaml.cs: {msg}");

        /// <summary>
        /// Refreshes the record list on the GUI
        /// </summary>
        /// <author>Jacob Paulin</author>
        private void RefreshRecordList()
        {
            Log($"(RefreshRecordList) Refreshing list view with data from CSV file {Controller.FilePath}");
            LinkedList<VegetableRecord> records = Controller.ReadRecords();
            Log($"(RefreshRecordList) New list has {records.Count} entries and is read as: {JsonSerializer.Serialize(records)}");
            ListRecords.ItemsSource = records;
        }
        #endregion
    }
}
