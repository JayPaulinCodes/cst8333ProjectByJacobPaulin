﻿using cst8333ProjectByJacobPaulin.Csv;
using cst8333ProjectByJacobPaulin.Models;
using cst8333ProjectByJacobPaulin.UI;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace cst8333ProjectByJacobPaulin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static CsvHandler CSV = new CsvHandler("./Csv/Dataset/32100260.csv", typeof(VegetableRecord), typeof(VegetableRecordMap), new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            Comment = '#',
            HasHeaderRecord = true,
            NewLine = Environment.NewLine
        });

        public MainWindow()
        {
            InitializeComponent();

            ComboBoxCsvFile.ItemsSource = GetCsvFiles();
            ComboBoxCsvFile.SelectedIndex = 0;
            MainFrame.Content = new Home(true);
        }

        #region Interactions
        private void ButtonHome(object sender, RoutedEventArgs e) => MainFrame.Content = new Home();

        private void ButtonCreate(object sender, RoutedEventArgs e) { }

        private void ComboBoxCsvFilePath(object sender, SelectionChangedEventArgs e)
        {
            JFile selectedFile = (JFile)ComboBoxCsvFile.SelectedItem;
            CSV.FilePath = selectedFile.Path;
        }
        #endregion

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] {msg}");

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
