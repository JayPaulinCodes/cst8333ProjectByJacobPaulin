/* 
 * Author: Jacob Paulin
 * Date: July 19, 2023
 * Modified: July 19, 2023
 */

using cst8333ApplicationByJacobPaulin.PersistenceLayer.Daos;
using cst8333ApplicationByJacobPaulin.PersistenceLayer.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace cst8333ApplicationByJacobPaulin.BusinessLayer
{
    /// <summary>
    /// Implementation of the IVegetableRecordDao interface which will be used 
    /// for performing CRUD operations on VegetableRecord records
    /// </summary>
    /// <author>Jacob Paulin</author>
    public class VegetableRecordDaoImpl : IVegetableRecordDao
    {
        private readonly DbManager dbManager;

        /// <summary>
        /// Initializes a new instance of the VegetableRecordDaoImpl class
        /// while also retreiving the instance from the DB Manager
        /// </summary>
        /// <author>Jacob Paulin</author>
        public VegetableRecordDaoImpl()
        {
            dbManager = DbManager.Instance;
        }

        public async Task<IList<string>> GetColumnNamesAsync()
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "SELECT * FROM vegetableRecords";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Execute command
                    MySqlDataReader reader = await sqlCmd.ExecuteReaderAsync(CommandBehavior.SchemaOnly);

                    // Process results
                    DataTable schema = await reader.GetSchemaTableAsync();

                    List<string> results = new List<string>();
                    foreach (DataRow col in schema.Rows)
                    {
                        results.Add(col.Field<string>("ColumnName"));
                    }

                    // Close the reader
                    reader.Close();

                    // Close connection
                    dbManager.Close();

                    // Return results
                    return results;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            return null;
        }

        /// <summary>
        /// Creates a new VegetableRecord record in the DB
        /// </summary>
        /// <param name="item">The VegetableRecord object to create in the DB</param>
        /// <author>Jacob Paulin</author>
        public void Create(VegetableRecord item)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "INSERT INTO vegetableRecords (REF_DATE, GEO, DGUID, Type_of_product, Type_of_storage, UOM, UOM_ID, SCALAR_FACTOR, SCALAR_ID, VECTOR, COORDINATE, VALUE, STATUS, SYMBOL, `TERMINATED`, DECIMALS) VALUES (@REF_DATE, @GEO, @DGUID, @Type_of_product, @Type_of_storage, @UOM, @UOM_ID, @SCALAR_FACTOR, @SCALAR_ID, @VECTOR, @COORDINATE, @VALUE, @STATUS, @SYMBOL, @TERMINATED, @DECIMALS)";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@REF_DATE", item.RefDate);
                    sqlCmd.Parameters.AddWithValue("@GEO", item.Geo);
                    sqlCmd.Parameters.AddWithValue("@DGUID", item.DGUID);
                    sqlCmd.Parameters.AddWithValue("@Type_of_product", item.TypeOfProduct);
                    sqlCmd.Parameters.AddWithValue("@Type_of_storage", item.TypeOfStorage);
                    sqlCmd.Parameters.AddWithValue("@UOM", item.UOM);
                    sqlCmd.Parameters.AddWithValue("@UOM_ID", item.UOMID);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_FACTOR", item.ScalarFactor);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_ID", item.ScalarId);
                    sqlCmd.Parameters.AddWithValue("@VECTOR", item.Vector);
                    sqlCmd.Parameters.AddWithValue("@COORDINATE", item.Coordinate);
                    sqlCmd.Parameters.AddWithValue("@VALUE", item.Value);
                    sqlCmd.Parameters.AddWithValue("@STATUS", item.Status);
                    sqlCmd.Parameters.AddWithValue("@SYMBOL", item.Symbol);
                    sqlCmd.Parameters.AddWithValue("@TERMINATED", item.Terminated);
                    sqlCmd.Parameters.AddWithValue("@DECIMALS", item.Decimals);

                    // Execute command
                    sqlCmd.ExecuteNonQuery();

                    // Close connection
                    dbManager.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Creates a new VegetableRecord record in the DB asynchronously
        /// </summary>
        /// <param name="item">The VegetableRecord object to create in the DB</param>
        /// <author>Jacob Paulin</author>
        public async Task CreateAsync(VegetableRecord item)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "INSERT INTO vegetableRecords (REF_DATE, GEO, DGUID, Type_of_product, Type_of_storage, UOM, UOM_ID, SCALAR_FACTOR, SCALAR_ID, VECTOR, COORDINATE, VALUE, STATUS, SYMBOL, `TERMINATED`, DECIMALS) VALUES (@REF_DATE, @GEO, @DGUID, @Type_of_product, @Type_of_storage, @UOM, @UOM_ID, @SCALAR_FACTOR, @SCALAR_ID, @VECTOR, @COORDINATE, @VALUE, @STATUS, @SYMBOL, @TERMINATED, @DECIMALS)";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@REF_DATE", item.RefDate);
                    sqlCmd.Parameters.AddWithValue("@GEO", item.Geo);
                    sqlCmd.Parameters.AddWithValue("@DGUID", item.DGUID);
                    sqlCmd.Parameters.AddWithValue("@Type_of_product", item.TypeOfProduct);
                    sqlCmd.Parameters.AddWithValue("@Type_of_storage", item.TypeOfStorage);
                    sqlCmd.Parameters.AddWithValue("@UOM", item.UOM);
                    sqlCmd.Parameters.AddWithValue("@UOM_ID", item.UOMID);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_FACTOR", item.ScalarFactor);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_ID", item.ScalarId);
                    sqlCmd.Parameters.AddWithValue("@VECTOR", item.Vector);
                    sqlCmd.Parameters.AddWithValue("@COORDINATE", item.Coordinate);
                    sqlCmd.Parameters.AddWithValue("@VALUE", item.Value);
                    sqlCmd.Parameters.AddWithValue("@STATUS", item.Status);
                    sqlCmd.Parameters.AddWithValue("@SYMBOL", item.Symbol);
                    sqlCmd.Parameters.AddWithValue("@TERMINATED", item.Terminated);
                    sqlCmd.Parameters.AddWithValue("@DECIMALS", item.Decimals);

                    // Execute command
                    await sqlCmd.ExecuteNonQueryAsync();

                    // Close connection
                    dbManager.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
}

        /// <summary>
        /// Retrieves all VegetableRecord records from the DB
        /// </summary>
        /// <returns>An IEnumerable containing all VegetableRecord records from the DB</returns>
        /// <author>Jacob Paulin</author>
        public IEnumerable<VegetableRecord> ReadAll()
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "SELECT * FROM vegetableRecords";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Execute command
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    // Process results
                    List<VegetableRecord> results = new List<VegetableRecord>();
                    while (reader.Read())
                    {
                        results.Add(new VegetableRecord()
                        {
                            Id = reader.GetInt32("id"),
                            RefDate = reader.GetSafeString("REF_DATE"),
                            Geo = reader.GetSafeString("GEO"),
                            DGUID = reader.GetSafeString("DGUID"),
                            TypeOfProduct = reader.GetSafeString("Type_of_product"),
                            TypeOfStorage = reader.GetSafeString("Type_of_storage"),
                            UOM = reader.GetSafeString("UOM"),
                            UOMID = reader.GetSafeInt32("UOMID"),
                            ScalarFactor = reader.GetSafeString("SCALAR_FACTOR"),
                            ScalarId = reader.GetSafeInt32("SCALAR_ID"),
                            Vector = reader.GetSafeString("VECTOR"),
                            Coordinate = reader.GetSafeString("COORDINATE"),
                            Value = reader.GetSafeInt32("VALUE"),
                            Status = reader.GetSafeString("STATUS"),
                            Symbol = reader.GetSafeString("SYMBOL"),
                            Terminated = reader.GetSafeString("TERMINATED"),
                            Decimals = reader.GetSafeInt32("DECIMALS"),
                        });
                    }

                    // Close the reader
                    reader.Close();

                    // Close connection
                    dbManager.Close();

                    // Return results
                    return results;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            // Default return
            return null;
        }

        /// <summary>
        /// Retrieves all VegetableRecord records from the DB asynchronously
        /// </summary>
        /// <returns>An IEnumerable containing all VegetableRecord records from the DB</returns>
        /// <author>Jacob Paulin</author>
        public async Task<IEnumerable<VegetableRecord>> ReadAllAsync()
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "SELECT * FROM vegetableRecords";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Execute command
                    MySqlDataReader reader = await sqlCmd.ExecuteReaderAsync(CommandBehavior.Default);

                    //Debug.WriteLine($"HasRows: {reader.HasRows}");
                    // Process results
                    List<VegetableRecord> results = new List<VegetableRecord>();
                    while (await reader.ReadAsync())
                    {
                        results.Add(new VegetableRecord()
                        {
                            Id = reader.GetInt32("id"),
                            RefDate = reader.GetSafeString("REF_DATE"),
                            Geo = reader.GetSafeString("GEO"),
                            DGUID = reader.GetSafeString("DGUID"),
                            TypeOfProduct = reader.GetSafeString("Type_of_product"),
                            TypeOfStorage = reader.GetSafeString("Type_of_storage"),
                            UOM = reader.GetSafeString("UOM"),
                            UOMID = reader.GetSafeInt32("UOM_ID"),
                            ScalarFactor = reader.GetSafeString("SCALAR_FACTOR"),
                            ScalarId = reader.GetSafeInt32("SCALAR_ID"),
                            Vector = reader.GetSafeString("VECTOR"),
                            Coordinate = reader.GetSafeString("COORDINATE"),
                            Value = reader.GetSafeInt32("VALUE"),
                            Status = reader.GetSafeString("STATUS"),
                            Symbol = reader.GetSafeString("SYMBOL"),
                            Terminated = reader.GetSafeString("TERMINATED"),
                            Decimals = reader.GetSafeInt32("DECIMALS"),
                        });
                    }

                    // Close the reader
                    reader.Close();

                    // Close connection
                    dbManager.Close();

                    // Return results
                    return results;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            // Default return
            return null;
        }

        /// <summary>
        /// Retrieves a VegetableRecord record from the DB using a specified ID
        /// </summary>
        /// <param name="id">The id of the VegetableRecord to retreive</param>
        /// <returns>The VegetableRecord with the specified ID</returns>
        /// <author>Jacob Paulin</author>
        public VegetableRecord ReadById(int id)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "SELECT * FROM vegetableRecords WHERE id = @Id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@Id", id);

                    // Execute command
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    // Process results
                    VegetableRecord result = null;
                    if (reader.Read())
                    {
                        result = new VegetableRecord()
                        {
                            Id = reader.GetInt32("id"),
                            RefDate = reader.GetSafeString("REF_DATE"),
                            Geo = reader.GetSafeString("GEO"),
                            DGUID = reader.GetSafeString("DGUID"),
                            TypeOfProduct = reader.GetSafeString("Type_of_product"),
                            TypeOfStorage = reader.GetSafeString("Type_of_storage"),
                            UOM = reader.GetSafeString("UOM"),
                            UOMID = reader.GetSafeInt32("UOMID"),
                            ScalarFactor = reader.GetSafeString("SCALAR_FACTOR"),
                            ScalarId = reader.GetSafeInt32("SCALAR_ID"),
                            Vector = reader.GetSafeString("VECTOR"),
                            Coordinate = reader.GetSafeString("COORDINATE"),
                            Value = reader.GetSafeInt32("VALUE"),
                            Status = reader.GetSafeString("STATUS"),
                            Symbol = reader.GetSafeString("SYMBOL"),
                            Terminated = reader.GetSafeString("TERMINATED"),
                            Decimals = reader.GetSafeInt32("DECIMALS"),
                        };
                    }

                    // Close the reader
                    reader.Close();

                    // Close connection
                    dbManager.Close();

                    // Return results
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            // Default return
            return null;
        }

        /// <summary>
        /// Retrieves a VegetableRecord record from the DB using a specified ID asynchronously
        /// </summary>
        /// <param name="id">The id of the VegetableRecord to retreive</param>
        /// <returns>The VegetableRecord with the specified ID</returns>
        /// <author>Jacob Paulin</author>
        public async Task<VegetableRecord> ReadByIdAsync(int id)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "SELECT * FROM vegetableRecords WHERE id = @Id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@Id", id);

                    // Execute command
                    MySqlDataReader reader = await sqlCmd.ExecuteReaderAsync(CommandBehavior.Default);

                    // Process results
                    VegetableRecord result = null;
                    if (await reader.ReadAsync())
                    {
                        result = new VegetableRecord()
                        {
                            Id = reader.GetInt32("id"),
                            RefDate = reader.GetSafeString("REF_DATE"),
                            Geo = reader.GetSafeString("GEO"),
                            DGUID = reader.GetSafeString("DGUID"),
                            TypeOfProduct = reader.GetSafeString("Type_of_product"),
                            TypeOfStorage = reader.GetSafeString("Type_of_storage"),
                            UOM = reader.GetSafeString("UOM"),
                            UOMID = reader.GetSafeInt32("UOMID"),
                            ScalarFactor = reader.GetSafeString("SCALAR_FACTOR"),
                            ScalarId = reader.GetSafeInt32("SCALAR_ID"),
                            Vector = reader.GetSafeString("VECTOR"),
                            Coordinate = reader.GetSafeString("COORDINATE"),
                            Value = reader.GetSafeInt32("VALUE"),
                            Status = reader.GetSafeString("STATUS"),
                            Symbol = reader.GetSafeString("SYMBOL"),
                            Terminated = reader.GetSafeString("TERMINATED"),
                            Decimals = reader.GetSafeInt32("DECIMALS"),
                        };
                    }

                    // Close the reader
                    reader.Close();

                    // Close connection
                    dbManager.Close();

                    // Return results
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            // Default return
            return null;
        }

        /// <summary>
        /// Updates an existing VegetableRecord record in the DB
        /// </summary>
        /// <param name="item">The VegetableRecord record to update</param>
        /// <author>Jacob Paulin</author>
        public void Update(VegetableRecord item)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "UPDATE vegetableRecords SET REF_DATE = @REF_DATE, GEO = @GEO, DGUID = @DGUID, Type_of_product = @Type_of_product, Type_of_storage = @Type_of_storage, UOM = @UOM, UOM_ID = @UOM_ID, SCALAR_FACTOR = @SCALAR_FACTOR, SCALAR_ID = @SCALAR_ID, VECTOR = @VECTOR, COORDINATE = @COORDINATE, VALUE = @VALUE, STATUS = @STATUS, SYMBOL = @SYMBOL, `TERMINATED` = @TERMINATED, DECIMALS = @DECIMALS WHERE id = @Id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@REF_DATE", item.RefDate);
                    sqlCmd.Parameters.AddWithValue("@GEO", item.Geo);
                    sqlCmd.Parameters.AddWithValue("@DGUID", item.DGUID);
                    sqlCmd.Parameters.AddWithValue("@Type_of_product", item.TypeOfProduct);
                    sqlCmd.Parameters.AddWithValue("@Type_of_storage", item.TypeOfStorage);
                    sqlCmd.Parameters.AddWithValue("@UOM", item.UOM);
                    sqlCmd.Parameters.AddWithValue("@UOM_ID", item.UOMID);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_FACTOR", item.ScalarFactor);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_ID", item.ScalarId);
                    sqlCmd.Parameters.AddWithValue("@VECTOR", item.Vector);
                    sqlCmd.Parameters.AddWithValue("@COORDINATE", item.Coordinate);
                    sqlCmd.Parameters.AddWithValue("@VALUE", item.Value);
                    sqlCmd.Parameters.AddWithValue("@STATUS", item.Status);
                    sqlCmd.Parameters.AddWithValue("@SYMBOL", item.Symbol);
                    sqlCmd.Parameters.AddWithValue("@TERMINATED", item.Terminated);
                    sqlCmd.Parameters.AddWithValue("@DECIMALS", item.Decimals);
                    sqlCmd.Parameters.AddWithValue("@Id", item.Id);

                    // Execute command
                    sqlCmd.ExecuteNonQuery();

                    // Close connection
                    dbManager.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Updates an existing VegetableRecord record in the DB asynchronously
        /// </summary>
        /// <param name="item">The VegetableRecord record to update</param>
        /// <author>Jacob Paulin</author>
        public async Task UpdateAsync(VegetableRecord item)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "UPDATE vegetableRecords SET REF_DATE = @REF_DATE, GEO = @GEO, DGUID = @DGUID, Type_of_product = @Type_of_product, Type_of_storage = @Type_of_storage, UOM = @UOM, UOM_ID = @UOM_ID, SCALAR_FACTOR = @SCALAR_FACTOR, SCALAR_ID = @SCALAR_ID, VECTOR = @VECTOR, COORDINATE = @COORDINATE, VALUE = @VALUE, STATUS = @STATUS, SYMBOL = @SYMBOL, `TERMINATED` = @TERMINATED, DECIMALS = @DECIMALS WHERE id = @Id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@REF_DATE", item.RefDate);
                    sqlCmd.Parameters.AddWithValue("@GEO", item.Geo);
                    sqlCmd.Parameters.AddWithValue("@DGUID", item.DGUID);
                    sqlCmd.Parameters.AddWithValue("@Type_of_product", item.TypeOfProduct);
                    sqlCmd.Parameters.AddWithValue("@Type_of_storage", item.TypeOfStorage);
                    sqlCmd.Parameters.AddWithValue("@UOM", item.UOM);
                    sqlCmd.Parameters.AddWithValue("@UOM_ID", item.UOMID);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_FACTOR", item.ScalarFactor);
                    sqlCmd.Parameters.AddWithValue("@SCALAR_ID", item.ScalarId);
                    sqlCmd.Parameters.AddWithValue("@VECTOR", item.Vector);
                    sqlCmd.Parameters.AddWithValue("@COORDINATE", item.Coordinate);
                    sqlCmd.Parameters.AddWithValue("@VALUE", item.Value);
                    sqlCmd.Parameters.AddWithValue("@STATUS", item.Status);
                    sqlCmd.Parameters.AddWithValue("@SYMBOL", item.Symbol);
                    sqlCmd.Parameters.AddWithValue("@TERMINATED", item.Terminated);
                    sqlCmd.Parameters.AddWithValue("@DECIMALS", item.Decimals);
                    sqlCmd.Parameters.AddWithValue("@Id", item.Id);

                    // Execute command
                    await sqlCmd.ExecuteNonQueryAsync();

                    // Close connection
                    dbManager.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Deletes a VegetableRecord record from the DB
        /// </summary>
        /// <param name="item">The VegetableRecord record to delete</param>
        /// <author>Jacob Paulin</author>
        public void Delete(VegetableRecord item)
        {
            if (item.Id.Equals(null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            Delete(item.Id);
        }

        /// <summary>
        /// Deletes a VegetableRecord record from the DB asynchronously
        /// </summary>
        /// <param name="item">The VegetableRecord record to delete</param>
        /// <author>Jacob Paulin</author>
        public async Task DeleteAsync(VegetableRecord item)
        {
            if (item.Id.Equals(null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            await DeleteAsync(item.Id);
        }

        /// <summary>
        /// Deletes a VegetableRecord record from the DB using a specified ID 
        /// </summary>
        /// <param name="id">The ID of the VegetableRecord record to delete</param>
        /// <author>Jacob Paulin</author>
        public void Delete(int id)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "DELETE FROM vegetableRecords WHERE id = @Id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@Id", id);

                    // Execute command
                    sqlCmd.ExecuteNonQuery();

                    // Close connection
                    dbManager.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Deletes a VegetableRecord record from the DB using a specified ID asynchronously
        /// </summary>
        /// <param name="id">The ID of the VegetableRecord record to delete</param>
        /// <author>Jacob Paulin</author>
        public async Task DeleteAsync(int id)
        {
            try
            {
                // Create connection
                if (dbManager.IsConnected())
                {
                    // Define query & command
                    string query = "DELETE FROM vegetableRecords WHERE id = @Id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, dbManager.Connection);

                    // Inject parameters
                    sqlCmd.Parameters.AddWithValue("@Id", id);

                    // Execute command
                    await sqlCmd.ExecuteNonQueryAsync();

                    // Close connection
                    dbManager.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
