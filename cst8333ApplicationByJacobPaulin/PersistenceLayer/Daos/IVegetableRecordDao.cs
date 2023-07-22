/* 
 * Author: Jacob Paulin
 * Date: July 19, 2023
 * Modified: July 19, 2023
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer;

namespace cst8333ApplicationByJacobPaulin.PersistenceLayer.Daos
{
    /// <summary>
    /// Represents a DAO interface for VegetableRecord class
    /// Inherits from the generic IDao interface with VegetableRecord as the generic type
    /// </summary>
    /// <author>Jacob Paulin</author>
    public interface IVegetableRecordDao : IDao<VegetableRecord>
    {
    }
}
