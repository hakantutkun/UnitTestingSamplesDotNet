using Bongo.Models.Model;
using System.Collections.Generic;

namespace Bongo.Core.Services.IServices
{
    /// <summary>
    /// Study room service interface
    /// </summary>
    public interface IStudyRoomService
    {
        /// <summary>
        /// Gets all study room
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudyRoom> GetAll();
        

    }
}
