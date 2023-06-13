using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cst8333ProjectByJacobPaulin.Models;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Media.Media3D;
using System.Formats.Asn1;

namespace cst8333ProjectByJacobPaulin.Csv
{
    internal class CsvHandler
    {
        #region Variables
        public string FilePath { get; set; }
        public CsvConfiguration? Config { get; set; }

        public Type RecordType { get; set; }
        public Type RecordMapType { get; set; }

        public IList? Contents { get; set; }
        #endregion

        #region Constructors
        public CsvHandler(string filePath, Type recordType, Type recordMapType, CsvConfiguration? csvConfig)
        {
            FilePath = filePath;
            Config = csvConfig;
            RecordType = recordType;
            RecordMapType = recordMapType;

            RefreshContent();
        }
        #endregion

        #region Methods
        public void RefreshContent()
        {
            Contents = (IList?)GetType()
                .GetMethod("ReadCsv", BindingFlags.Public | BindingFlags.Instance)
                .MakeGenericMethod(RecordType, RecordMapType)
                .Invoke(this, new object[] { FilePath, Config });
        }


        public bool WriteContents(string filePath, IReaderConfiguration? config = null)
        {
            return (bool)GetType()
                .GetMethod("WriteCsv", BindingFlags.Public | BindingFlags.Instance)
                .MakeGenericMethod(RecordType)
                .Invoke(this, new object[] { filePath, Contents, Config });
        }

        public bool WriteCsv<T>(string filePath, IList data, IReaderConfiguration? config = null)
            where T : class
        {
            // Validate the filePath variable
            if (string.IsNullOrWhiteSpace(filePath)) { return false; }

            // Using a try/catch block to handle any errors
            try
            {
                // If the parameter config is supplied use it, otherwise use pre-defined defaults
                // Using the dynamic keyword because the type will either be CultureInfo or ReaderConfiguration
                dynamic cultureConfig = (config == null) ? CultureInfo.InvariantCulture : config;

                Log($"Attempting to open and write to file at path \"{filePath}\"");
                // Utilizing the using statement to automatically dispose once done, even on the occurrence of an exception
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, cultureConfig))
                {
                    Log($"Writing header for class \"{typeof(T).Name}\"");
                    csv.WriteHeader<T>();
                    csv.NextRecord();

                    foreach (var entry in data)
                    {
                        Log($"Writing entry #{data.IndexOf(entry) + 1} of data list");
                        csv.WriteRecord(entry);
                        csv.NextRecord();
                    }

                    Log($"Finised writing data list to file \"{filePath}\"");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log($"An error occurred in the WriteCsv method: \"{ex.Message}\"");
                return false;
            }
        }

        /// <summary>
        /// Reads a CSV file at a specified path and converts it to a list for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable object</typeparam>
        /// <typeparam name="TClass">The ClassMap for the CSV reader</typeparam>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="config">Optional parameter for reader configuration</param>
        /// <returns>Returns null if an error occurs, otherwise returns a List of type T</returns>
        /// <author>Jacob Paulin</author>
        public List<T>? ReadCsv<T, TClass>(string filePath, IReaderConfiguration? config = null)
            // Using generic type parameters we can allow this method to be dynamic to the user's need
            // (I feel like this may useful for future projects)
            // https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2013/512aeb7t(v=vs.120)?redirectedfrom=MSDN
            where T : class
            where TClass : ClassMap
        {
            // Validate the filePath variable
            if (string.IsNullOrWhiteSpace(filePath)) { return null; }

            // Using a try/catch block to handle any errors
            try
            {
                // If the parameter config is supplied use it, otherwise use pre-defined defaults
                // Using the dynamic keyword because the type will either be CultureInfo or ReaderConfiguration
                dynamic cultureConfig = (config == null) ? CultureInfo.InvariantCulture : config;

                Log($"Attempting to open and read from file at path \"{filePath}\"");
                // Utilizing the using statement to automatically dispose once done, even on the occurrence of an exception
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, cultureConfig))
                {
                    Log($"Registering the class map of \"{typeof(TClass).Name}\" for the csv helper");
                    csv.Context.RegisterClassMap<TClass>();
                    Log($"Retrieving records from the csv helper as class \"{typeof(T).Name}\"");
                    var records = csv.GetRecords<T>();
                    Log($"Converting the IEnumerable<{typeof(T).Name}> object to a List<{typeof(T).Name}> object");
                    return records.ToList();
                }
            }
            catch (Exception ex)
            {
                Log($"An error occurred in the ReadCsv method: \"{ex.Message}\"");
                return null;
            }
        }
        #endregion

        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] {msg}");
    }
}
