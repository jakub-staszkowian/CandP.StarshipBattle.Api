using StarshipBattle.Logic.DTOs;

namespace StarshipBattle.Logic.Services.Interfaces
{
    /// <summary>
    /// Interface for services responsible for write-only operations on Starship entity in persitent storage
    /// </summary>
    public interface IStarshipWriteService
    {
        /// <summary>
        /// Creates new Starship and saves it in database
        /// </summary>
        /// <param name="starshipDto">Required Starship data</param>
        /// <returns>Id of newly created Starship</returns>
        int Add(UpsertStarshipDto starshipDto);

        /// <summary>
        /// Edits existing Starship
        /// </summary>
        /// <param name="id">Identifier of Starship user wants to modify</param>
        /// <param name="starshipDto">Required Starship data</param>
        /// <returns>True in case of successfull edit, otherwise false</returns>
        bool Edit(int id, UpsertStarshipDto starshipDto);

        /// <summary>
        /// Removes existing starship
        /// </summary>
        /// <param name="id">Identifier of Starship user wants to remove</param>
        /// <returns>True in case of successfull removal, otherwise false</returns>
        bool Remove(int id);
    }
}
