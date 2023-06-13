using cst8333ApplicationByJacobPaulin.BusinessLayer.Models;
using cst8333ApplicationByJacobPaulin.PersistenceLayer;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cst8333ApplicationByJacobPaulin.BusinessLayer
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
            Log($"(ReadRecords) Trying to create record");
            CSV.Contents.AddLast(record);
            Log($"(ReadRecords) Trying to save contents");
            bool operation = CSV.WriteContents(CSV.FilePath);
            if (operation)
            {
                Log($"(ReadRecords) Save operaton succeeded");
            }
            else
            {
                Log($"(ReadRecords) Save operaton failed");
            }
            return operation;
        }

        public LinkedList<VegetableRecord>? ReadRecords()
        {
            Log($"(ReadRecords) Trying to read contents of  \"{FilePath}\"");
            CSV.RefreshContent();
            if (CSV.Contents != null)
            {
                Log($"(ReadRecords) Read operaton succeeded");
            }
            else
            {
                Log($"(ReadRecords) Read operaton failed");
            }
            return CSV.Contents;
        }

        public bool UpdateRecord(VegetableRecord oldRecord, VegetableRecord newRecord)
        {
            Log($"(UpdateRecord) Trying to update record");
            CSV.Contents.Find(oldRecord).Value = newRecord;
            Log($"(UpdateRecord) Trying to save contents");
            bool operation = CSV.WriteContents(CSV.FilePath);
            if (operation)
            {
                Log($"(UpdateRecord) Save operaton succeeded");
            }
            else
            {
                Log($"(UpdateRecord) Save operaton failed");
            }
            return operation;
        }

        public bool DeleteRecord(VegetableRecord record)
        {
            Log($"(DeleteRecord) Trying to delete record");
            CSV.Contents.Remove(record);
            Log($"(DeleteRecord) Trying to save contents");
            bool operation = CSV.WriteContents(CSV.FilePath);
            if (operation)
            {
                Log($"(DeleteRecord) Save operaton succeeded");
            }
            else
            {
                Log($"(DeleteRecord) Save operaton failed");
            }
            return operation;
        }

        public bool SaveToCsv(string filePath)
        {
            Log($"(SaveToCsv) Trying to save contents to file \"{filePath}\"");
            CSV.RefreshContent();
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
