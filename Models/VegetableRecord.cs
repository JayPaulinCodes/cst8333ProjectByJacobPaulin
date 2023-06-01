/* Author: Jacob Paulin
 * Date: May 17, 2023
 * Modified: May 17, 2023
 */

namespace cst8333ProjectByJacobPaulin.Models
{
    /// <summary>
    /// A simple class that represents a entry in the csv dataset
    /// </summary>
    internal class VegetableRecord
    {
        public string? RefDate { get; set; }
        public string? Geo { get; set; }
        public string? DGUID { get; set; }
        public string? TypeOfProduct { get; set; }
        public string? TypeOfStorage { get; set; }
        public string? UOM { get; set; }
        public int? UOMID { get; set; }
        public string? ScalarFactor { get; set; }
        public int? ScalarId { get; set; }
        public string? Vector { get; set; }
        public string? Coordinate { get; set; }
        public int? Value { get; set; }
        public string? Status { get; set; }
        public string? Symbol { get; set; }
        public string? Terminated { get; set; }
        public int? Decimals { get; set; }

        public override string ToString()
        {
            List<string> fields = new List<string>()
            {
                !string.IsNullOrEmpty(RefDate) ? RefDate : "\"\"",
                !string.IsNullOrEmpty(Geo) ? Geo : "\"\"",
                !string.IsNullOrEmpty(DGUID) ? DGUID : "\"\"",
                !string.IsNullOrEmpty(TypeOfProduct) ? TypeOfProduct : "\"\"",
                !string.IsNullOrEmpty(TypeOfStorage) ? TypeOfStorage : "\"\"",
                !string.IsNullOrEmpty(UOM) ? UOM : "\"\"",
                UOMID != null ? $"{UOMID}" : "\"\"",
                !string.IsNullOrEmpty(ScalarFactor) ? ScalarFactor : "\"\"",
                ScalarId != null ? $"{ScalarId}" : "\"\"",
                !string.IsNullOrEmpty(Vector) ? Vector : "\"\"",
                !string.IsNullOrEmpty(Coordinate) ? Coordinate : "\"\"",
                Value != null ? $"{Value}" : "\"\"",
                !string.IsNullOrEmpty(Status) ? Status : "\"\"",
                !string.IsNullOrEmpty(Symbol) ? Symbol : "\"\"",
                !string.IsNullOrEmpty(Terminated) ? Terminated : "\"\"",
                Decimals != null ? $"{Decimals}" : "\"\""
            };

            return string.Join(", ", fields);
        }

        public string ToPrettyString()
        {
            List<string> fields = new List<string>()
            {
                string.Concat("RefDate: ", !string.IsNullOrEmpty(RefDate) ? RefDate : "\"\""),
                string.Concat("Geo: ", !string.IsNullOrEmpty(Geo) ? Geo : "\"\""),
                string.Concat("DGUID: ", !string.IsNullOrEmpty(DGUID) ? DGUID : "\"\""),
                string.Concat("TypeOfProduct: ", !string.IsNullOrEmpty(TypeOfProduct) ? TypeOfProduct : "\"\""),
                string.Concat("TypeOfStorage: ", !string.IsNullOrEmpty(TypeOfStorage) ? TypeOfStorage : "\"\""),
                string.Concat("UOM: ", !string.IsNullOrEmpty(UOM) ? UOM : "\"\""),
                string.Concat("UOMID: ", UOMID != null ? $"{UOMID}" : "\"\""),
                string.Concat("ScalarFactor: ", !string.IsNullOrEmpty(ScalarFactor) ? ScalarFactor : "\"\""),
                string.Concat("ScalarId: ", ScalarId != null ? $"{ScalarId}" : "\"\""),
                string.Concat("Vector: ", !string.IsNullOrEmpty(Vector) ? Vector : "\"\""),
                string.Concat("Coordinate: ", !string.IsNullOrEmpty(Coordinate) ? Coordinate : "\"\""),
                string.Concat("Value: ", Value != null ? $"{Value}" : "\"\""),
                string.Concat("Status: ", !string.IsNullOrEmpty(Status) ? Status : "\"\""),
                string.Concat("Symbol: ", !string.IsNullOrEmpty(Symbol) ? Symbol : "\"\""),
                string.Concat("Terminated: ", !string.IsNullOrEmpty(Terminated) ? Terminated : "\"\""),
                string.Concat("Decimals: ", Decimals != null ? $"{Decimals}" : "\"\"")
            };

            return string.Join(", ", fields);
        }
    }
}
