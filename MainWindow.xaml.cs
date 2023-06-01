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
using System.Windows.Shapes;

namespace cst8333ProjectByJacobPaulin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CsvHandler CSV = new CsvHandler("./Csv/Dataset/32100260.csv", new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            Comment = '#',
            HasHeaderRecord = true
        });

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Check the output for null
            if (CSV.Contents == null) { return; }

            // Loop through the returned list and print outputs
            foreach (VegetableRecord record in CSV.Contents)
            {
                int recordCount = CSV.Contents.IndexOf(record) + 1;
                // Stop after the first 200 records for poc
                if (recordCount > 200) { break; }
                Console.WriteLine($"\n[Written by Jacob Paulin] Record #{recordCount} = {record.ToPrettyString()}");
            }
        }
    }
}
