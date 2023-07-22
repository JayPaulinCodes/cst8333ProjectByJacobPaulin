/* 
 * Author: Jacob Paulin
 * Date: July 19, 2023
 * Modified: July 19, 2023
 */

namespace cst8333ApplicationByJacobPaulin.PersistenceLayer.Managers
{
    /// <summary>
    /// Provides configuration settings for the DB connection
    /// </summary>
    /// <author>Jacob Paulin</author>
    internal static class DbConfiguration
    {
        /// <summary>
        /// Gets the server name or IP address of the DB
        /// </summary>
        /// <author>Jacob Paulin</author>
        public static string Server { get; } = "localhost";

        /// <summary>
        /// Gets the port number for the DB connection
        /// </summary>
        /// <author>Jacob Paulin</author>
        public static int Port { get; } = 3306;

        /// <summary>
        /// Gets the name of the DB to connect to
        /// </summary>
        /// <author>Jacob Paulin</author>
        public static string Database { get; } = "cst8333";

        /// <summary>
        /// Gets the username used to authenticate with the DB
        /// </summary>
        /// <author>Jacob Paulin</author>
        public static string Username { get; } = "cst8333";

        /// <summary>
        /// Gets the password used to authenticate with the DB
        /// </summary>
        /// <author>Jacob Paulin</author>
        public static string Password { get; } = "SlDAzW2Ehp56iF5ONW9ud3W8DRLCigwkRAsQF3bsNDjrsKOECvR96alxooQPQxuvyf7wGvNmi1I0H19ixdV5fstUWzYoDGmJnqA2";
    }
}
