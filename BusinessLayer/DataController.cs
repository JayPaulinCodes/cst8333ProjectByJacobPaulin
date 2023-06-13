using cst8333ProjectByJacobPaulin.Models;
using cst8333ProjectByJacobPaulin.PersistenceLayer;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cst8333ProjectByJacobPaulin.BusinessLayer
{
    public class DataController
    {
        private static CsvHandler CSV = new CsvHandler("./Csv/Dataset/32100260.csv", new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            Comment = '#',
            HasHeaderRecord = true,
            NewLine = Environment.NewLine
        });

        public string FilePath
        {
            get
            {
                return CSV.FilePath;
            }

            set
            {
                Log($"Changing CSV file path from \"{CSV.FilePath}\" to \"{value}\"");
                CSV.FilePath = value;
            }
        }

        public DataController()
        {

        }

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] DataController.cs: {msg}");

        public bool CreateRecord(VegetableRecord record)
        {
            return false;
        }

        public LinkedList<VegetableRecord> ReadRecords()
        {
            return new LinkedList<VegetableRecord>(CSV.Contents);
        }

        public bool UpdateRecord(VegetableRecord oldRecord, VegetableRecord newRecord)
        {
            return false;
        }

        public bool DeleteRecord(VegetableRecord record)
        {
            return false;
        }

        public bool SaveToCsv(string filePath)
        {
            Log($"(SaveToCsv) Trying to save contents to file \"{filePath}\"");
            bool operation = CSV.WriteContents(filePath);
            if (operation)
            {
                Log($"(SaveToCsv) Save operaton succeeded");
            }
            else
            {
                Log($"(SaveToCsv) Save operaton failed");
            }
            return operation;
        }

        #endregion

    }
}
