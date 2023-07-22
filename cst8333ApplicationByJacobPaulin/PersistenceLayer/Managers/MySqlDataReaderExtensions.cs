/* 
 * Author: Jacob Paulin
 * Date: July 19, 2023
 * Modified: July 19, 2023
 */

using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;

namespace cst8333ApplicationByJacobPaulin.PersistenceLayer.Managers
{
    /// <summary>
    /// Provides extension methods for safely 
    /// retrieving nullable values from a MySqlDataReader
    /// 
    /// The methods in this class check for DBNull values 
    /// and return null when appropriate, ensuring that the 
    /// program doesn't crash due to exeptions when trying 
    /// to retreive nullable values
    /// </summary>
    /// <author>Jacob Paulin</author>
    public static class MySqlDataReaderExtensions
    {
        /// <summary>
        /// Safely retrieves a nullable boolean value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired boolean otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static bool? GetSafeBoolean(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetBoolean(column);

        /// <summary>
        /// Safely retrieves a nullable byte value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired byte otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static byte? GetSafeByte(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetByte(column);

        /// <summary>
        /// Safely retrieves a nullable sbyte value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired sbyte otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static sbyte? GetSafeSByte(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetSByte(column);

        /// <summary>
        /// Safely retrieves a nullable MySqlDateTime value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired MySqlDateTime otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static MySqlDateTime? GetSafeMySqlDateTime(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetMySqlDateTime(column);

        /// <summary>
        /// Safely retrieves a nullable MySqlDecimal value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired MySqlDecimal otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static MySqlDecimal? GetSafeMySqlDecimal(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetMySqlDecimal(column);

        /// <summary>
        /// Safely retrieves a nullable double value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired double otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static double? GetSafeDouble(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetDouble(column);

        /// <summary>
        /// Safely retrieves a nullable type value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired type otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static Type? GetSafeFieldType(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetFieldType(column);

        /// <summary>
        /// Safely retrieves a nullable float value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired float otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static float? GetSafeFloat(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetFloat(column);

        /// <summary>
        /// Safely retrieves a nullable guid value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired guid otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static Guid? GetSafeGuid(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetGuid(column);

        /// <summary>
        /// Safely retrieves a nullable short value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired short otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static short? GetSafeInt16(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetInt16(column);

        /// <summary>
        /// Safely retrieves a nullable int value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired int otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static int? GetSafeInt32(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetInt32(column);

        /// <summary>
        /// Safely retrieves a nullable long value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired long otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static long? GetSafeInt64(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetInt64(column);

        /// <summary>
        /// Safely retrieves a nullable DateTime value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired DateTime otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static DateTime? GetSafeDateTime(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetDateTime(column);

        /// <summary>
        /// Safely retrieves a nullable decimal value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired decimal otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static decimal? GetSafeDecimal(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetDecimal(column);

        /// <summary>
        /// Safely retrieves a nullable char value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired char otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static char? GetSafeChar(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetChar(column);

        /// <summary>
        /// Safely retrieves a nullable string value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired string otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static string? GetSafeString(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetString(column);

        /// <summary>
        /// Safely retrieves a nullable TimeSpan value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired TimeSpan otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static TimeSpan? GetSafeTimeSpan(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetTimeSpan(column);

        /// <summary>
        /// Safely retrieves a nullable ushort value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired ushort otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static ushort? GetSafeUInt16(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetUInt16(column);

        /// <summary>
        /// Safely retrieves a nullable uint value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired uint otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static uint? GetSafeUInt32(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetUInt32(column);

        /// <summary>
        /// Safely retrieves a nullable ulong value from 
        /// the specified column in the MySqlDataReader
        /// </summary>
        /// <returns>The desired ulong otherwise null</returns>
        /// <author>Jacob Paulin</author>
        public static ulong? GetSafeUInt64(this MySqlDataReader reader, string column)
            => reader.IsDBNull(reader.GetOrdinal(column)) ? null : reader.GetUInt64(column);
    }
}
