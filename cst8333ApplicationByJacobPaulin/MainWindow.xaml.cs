/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: Jun 13, 2023
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer;
using cst8333ApplicationByJacobPaulin.BusinessLayer.Models;
using cst8333ApplicationByJacobPaulin.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using Path = System.IO.Path;

namespace cst8333ApplicationByJacobPaulin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <author>Jacob Paulin</author>
    public partial class MainWindow : Window
    {
        #region Variables
        private DataController Controller;
        public static event EventHandler? NewCsvSelected;
        #endregion

        /// <summary>
        /// Constructor for the main window, in here
        /// we will run code that will initialize the
        /// user interface
        /// </summary>
        /// <author>Jacob Paulin</author>
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();

            // Load the possible csv files
            ComboBoxCsvFile.ItemsSource = GetCsvFiles();
            ComboBoxCsvFile.SelectedIndex = 0;

            // Navigate to the home page
            MainFrame.Navigate(new Home());
        }

        #region Interactions
        /// <summary>
        /// Interaction method triggered when the home button 
        /// is clicked, sends the user to the home page
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ButtonHome(object sender, RoutedEventArgs e)
        {
            Log($"(ButtonHome) Home button was pushed");
            Log($"(ButtonHome) Navigating to home page");
            MainFrame.Navigate(new Home());
        }

        /// <summary>
        /// Interaction method triggered when the create a 
        /// record button is clicked, sends the user to 
        /// the record creation page
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            Log($"(ButtonHome) Create record button was pushed");
            Log($"(ButtonHome) Navigating to create record page");
            MainFrame.Navigate(new CreateRecord());
        }

        /// <summary>
        /// Interaction method triggered when a item is selected
        /// from the dropdown menu for csv files. 
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ComboBoxCsvFilePath(object sender, SelectionChangedEventArgs e)
        {
            Log($"(ComboBoxCsvFilePath) A CSV file item was selected");
            JFile selectedFile = (JFile)ComboBoxCsvFile.SelectedItem;
            Log($"(ComboBoxCsvFilePath) Retrieving the CSV file selected: {selectedFile.Path}");
            Log($"(ComboBoxCsvFilePath) Setting the file path on the data controller");
            Controller.FilePath = selectedFile.Path;
            Log($"(ComboBoxCsvFilePath) Triggering the new csv selected event");
            TriggerEventNewCsvSelected(new EventArgs());
        }
        #endregion

        #region Events
        /// <summary>
        /// Trigger the NewCsvSelected event
        /// </summary>
        /// <param name="e">Arguments to pass to the event trigger</param>
        /// <author>Jacob Paulin</author>
        private void TriggerEventNewCsvSelected(EventArgs e)
        {
            Log($"(TriggerEventNewCsvSelected) Trying to trigger the NewCsvSelected event");
            if (NewCsvSelected != null)
            {
                Log($"(TriggerEventNewCsvSelected) Event var isn't null, triggering event");
                NewCsvSelected(this, e);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simplyfied log method to add consistient formatting for all logs
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <author>Jacob Paulin</author>
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] MainWindow.xaml.cs: {msg}");

        /// <summary>
        /// Utility method used to verify if a string is a valid
        /// name for a file by ensuring there are no invalid chars in it
        /// </summary>
        /// <param name="fileName">The string to check</param>
        /// <returns>Boolean indicating if the string is a valid file name</returns>
        /// <author>Jacob Paulin</author>
        public static bool CheckFileName(string fileName)
        {
            Log($"(CheckFileName) Checking file name \"{fileName}\"");
            Log($"(CheckFileName) Found {fileName.IndexOfAny(Path.GetInvalidFileNameChars())} invalid chars");
            return !string.IsNullOrEmpty(fileName) && fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && fileName.EndsWith(".csv");
        }

        /// <summary>
        /// Utility method used to get all the CSV files
        /// in the "./Csv/Dataset" directory
        /// </summary>
        /// <returns>A list of the files in the directory</returns>
        /// <author>Jacob Paulin</author>
        private static IList<JFile> GetCsvFiles()
        {
            List<JFile> files = new List<JFile>();

            foreach (string file in Directory.GetFiles("./Csv/Dataset"))
            {
                Console.WriteLine(Path.GetFileName(file));
                files.Add(new JFile
                {
                    Name = Path.GetFileName(file),
                    Path = "./Csv/Dataset/" + Path.GetFileName(file)
                });
            }

            return files;
        }
        #endregion
    }
}
