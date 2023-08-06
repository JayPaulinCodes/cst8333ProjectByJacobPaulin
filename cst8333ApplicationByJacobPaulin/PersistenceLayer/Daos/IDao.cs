/* 
 * Author: Jacob Paulin
 * Date: July 19, 2023
 * Modified: July 19, 2023
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace cst8333ApplicationByJacobPaulin.PersistenceLayer.Daos
{    
    /// <summary>
    /// Represents a data access object interface for CRUD 
    /// operations on entities of generic type T
    /// </summary>
    /// <typeparam name="T">The type of entity</typeparam>
    /// <author>Jacob Paulin</author>
    public interface IDao<T>
    {
        /// <summary>
        /// (C)RUD - Creates a new entity
        /// </summary>
        /// <param name="item">The entity to create</param>
        /// <author>Jacob Paulin</author>
        void Create(T item);

        /// <summary>
        /// (C)RUD - Creates a new entity asynchronously
        /// </summary>
        /// <param name="item">The entity to create</param>
        /// <author>Jacob Paulin</author>
        Task CreateAsync(T item);


        /// <summary>
        /// C(R)UD - Retrieves all entities of type T
        /// </summary>
        /// <returns>An IEnumerable containing all entities of type T</returns>
        /// <author>Jacob Paulin</author>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// C(R)UD - Retrieves all entities of type T asynchronously
        /// </summary>
        /// <returns>An IEnumerable containing all entities of type T</returns>
        /// <author>Jacob Paulin</author>
        Task<IEnumerable<T>> ReadAllAsync();

        /// <summary>
        /// C(R)UD - Retrieves an entity of type T by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID.</returns>
        /// <author>Jacob Paulin</author>
        T ReadById(int id);

        /// <summary>
        /// C(R)UD - Retrieves an entity of type T asynchronously by its ID
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve</param>
        /// <returns>The entity with the specified ID</returns>
        /// <author>Jacob Paulin</author>
        Task<T> ReadByIdAsync(int id);

        /// <summary>
        /// CR(U)D - Updates an existing entity
        /// </summary>
        /// <param name="item">The entity to update</param>
        /// <author>Jacob Paulin</author>
        void Update(T item);

        /// <summary>
        /// CR(U)D - Updates an existing entity asynchronously
        /// </summary>
        /// <param name="item">The entity to update</param>
        /// <author>Jacob Paulin</author>
        Task UpdateAsync(T item);

        /// <summary>
        /// CRU(D) - Deletes an entity by its ID
        /// </summary>
        /// <param name="id">The ID of the entity to delete</param>
        /// <author>Jacob Paulin</author>
        void Delete(int id);

        /// <summary>
        /// CRU(D) - Deletes an entity by its ID asynchronously
        /// </summary>
        /// <param name="id">The ID of the entity to delete</param>
        /// <author>Jacob Paulin</author>
        Task DeleteAsync(int id);

        /// <summary>
        /// CRU(D) - Deletes an entity
        /// </summary>
        /// <param name="item">The entity to delete</param>
        /// <author>Jacob Paulin</author>
        void Delete(T item);

        /// <summary>
        /// CRU(D) - Deletes an entity asynchronously
        /// </summary>
        /// <param name="item">The entity to delete</param>
        /// <author>Jacob Paulin</author>
        Task DeleteAsync(T item);

        Task<IList<string>> GetColumnNamesAsync();
    }
}
