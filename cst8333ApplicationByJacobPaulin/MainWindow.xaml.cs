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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace cst8333ApplicationByJacobPaulin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataController Controller;
        public static event EventHandler NewCsvSelected;

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
        private void ButtonHome(object sender, RoutedEventArgs e)
        {
            Log($"(ButtonHome) Home button was pushed");
            Log($"(ButtonHome) Navigating to home page");
            MainFrame.Navigate(new Home());
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            Log($"(ButtonHome) Create record button was pushed");
            Log($"(ButtonHome) Navigating to create record page");
            MainFrame.Navigate(new CreateRecord());
        }

        private void ComboBoxCsvFilePath(object sender, SelectionChangedEventArgs e)
        {
            JFile selectedFile = (JFile)ComboBoxCsvFile.SelectedItem;
            Controller.FilePath = selectedFile.Path;
            TriggerEventNewCsvSelected(new EventArgs());
        }
        #endregion

        #region Events
        private void TriggerEventNewCsvSelected(EventArgs e)
        {
            if (NewCsvSelected != null)
            {
                NewCsvSelected(this, e);
            }
        }
        #endregion

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] MainWindow.xaml.cs: {msg}");

        public static bool CheckFileName(string fileName)
        {
            Log($"Checking file name \"{fileName}\"");
            Log($"Checking against {JsonSerializer.Serialize(Path.GetInvalidFileNameChars())}");
            Log($"Found {fileName.IndexOfAny(Path.GetInvalidFileNameChars())}");

            return !string.IsNullOrEmpty(fileName) && fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && fileName.EndsWith(".csv");
        }

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
