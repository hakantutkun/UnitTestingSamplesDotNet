using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using System.Collections.Generic;
using System.Linq;

namespace Bongo.DataAccess.Repository
{
    /// <summary>
    /// Repository Foor <see cref="StudyRoom"/>
    /// </summary>
    public class StudyRoomRepository : IStudyRoomRepository
    {
        /// <summary>
        /// Database Object
        /// </summary>
        private readonly ApplicationDbContext _db;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">Database Injection</param>
        public StudyRoomRepository(ApplicationDbContext db)
        {
            // Set the injection
            _db = db;
        }
      
        /// <summary>
        /// Gets all the studyRooms from the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StudyRoom> GetAll()
        {
            // Return all the study rooms.
            return  _db.StudyRooms.ToList();
        }


    }
}
