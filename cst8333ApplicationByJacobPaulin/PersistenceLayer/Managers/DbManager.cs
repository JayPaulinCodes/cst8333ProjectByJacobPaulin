/* 
 * Author: Jacob Paulin
 * Date: July 19, 2023
 * Modified: July 19, 2023
 */

using MySql.Data.MySqlClient;

namespace cst8333ApplicationByJacobPaulin.PersistenceLayer.Managers
{
    /// <summary>
    /// Manages the database connection and provides 
    /// access to a single instance of DbManager
    /// </summary>
    /// <author>Jacob Paulin</author>
    public class DbManager
    {
        private static DbManager? _instance;

        /// <summary>
        /// Gets the single instance of the DbManager
        /// </summary>
        /// <author>Jacob Paulin</author>
        public static DbManager Instance
        {
            get
            {
                _instance ??= new DbManager();
                return _instance;
            }
            private set { _instance = value; }
        }

        /// <summary>
        /// Gets the MySqlConnection object representing the current DB connection
        /// </summary>
        /// <author>Jacob Paulin</author>
        public MySqlConnection? Connection { get; private set; }

        private DbManager()
        {
        }

        /// <summary>
        /// Checks if a DB connection is established and 
        /// establishes one if there isn't already one
        /// </summary>
        /// <returns>True if the DB connection is established and false if it's not</returns>
        /// <author>Jacob Paulin</author>
        public bool IsConnected()
        {
            if (Connection == null)
            {
                if (string.IsNullOrEmpty(DbConfiguration.Database)) return false;
                string connstring = string.Format(
                    "Server={0}; Port={1}; Database={2}; User ID={3}; Password={4}", 
                    DbConfiguration.Server, 
                    DbConfiguration.Port, 
                    DbConfiguration.Database, 
                    DbConfiguration.Username, 
                    DbConfiguration.Password
                );
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }

        /// <summary>
        /// Closes the current DB connection
        /// </summary>
        /// <author>Jacob Paulin</author>
        public void Close()
        {
            Connection?.Close();
            Connection = null;
        }
    }
}
