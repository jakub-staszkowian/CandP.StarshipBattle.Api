using StarshipBattle.Logic.DTOs;
using System.Collections.Generic;

namespace StarshipBattle.Logic.Services.Interfaces
{
    /// <summary>
    /// Interface for services responsible for read-only operations on Starship entity in persitent storage
    /// </summary>
    public interface IStarshipReadService
    {
        /// <summary>
        /// Returns all existing Starships
        /// </summary>
        /// <returns>Collection of Starships existing in database</returns>
        IEnumerable<StarshipDto> GetAll();

        /// <summary>
        /// Returns Starship having provided id 
        /// </summary>
        /// <param name="id">Unique identifier assigned to specific Starship user want to access</param>
        /// <returns>Starship object if exists, otherwise null</returns>
        StarshipDto GetById(int id);

        /// <summary>
        /// Returns random Starship existing on database
        /// </summary>
        /// <returns>Starship object if at least one exists in database, otherwise null</returns>
        StarshipDto GetRandom();
    }
}
