using Bongo.Models.Model;
using System.Collections.Generic;

namespace Bongo.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Study Room Repository Interface
    /// </summary>
    public interface IStudyRoomRepository
    {
        /// <summary>
        /// Gets all rooms from the database.
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudyRoom> GetAll();
    }
}
