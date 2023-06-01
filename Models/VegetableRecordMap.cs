/* Author: Jacob Paulin
 * Date: May 17, 2023
 * Modified: May 17, 2023
 */

using CsvHelper.Configuration;

namespace cst8333ProjectByJacobPaulin.Models
{
    /// <summary>
    /// A class used to map to the csv reader the parameters of the VegetableRecord class
    /// </summary>
    internal class VegetableRecordMap : ClassMap<VegetableRecord>
    {
        public VegetableRecordMap()
        {
            Map(v => v.RefDate).Index(0);
            Map(v => v.Geo).Index(1);
            Map(v => v.DGUID).Index(2);
            Map(v => v.TypeOfProduct).Index(3);
            Map(v => v.TypeOfStorage).Index(4);
            Map(v => v.UOM).Index(5);
            Map(v => v.UOMID).Index(6);
            Map(v => v.ScalarFactor).Index(7);
            Map(v => v.ScalarId).Index(8);
            Map(v => v.Vector).Index(9);
            Map(v => v.Coordinate).Index(10);
            Map(v => v.Value).Index(11);
            Map(v => v.Status).Index(12);
            Map(v => v.Symbol).Index(13);
            Map(v => v.Terminated).Index(14);
            Map(v => v.Decimals).Index(15);
        }
    }
}
