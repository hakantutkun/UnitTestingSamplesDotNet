using Bongo.Core.Services.IServices;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using System.Collections.Generic;

namespace Bongo.Core.Services
{
    /// <summary>
    /// Service for the <see cref="StudyRoom"/>
    /// </summary>
    public class StudyRoomService : IStudyRoomService
    {
        /// <summary>
        /// StudyRoom Repository instance
        /// </summary>
        private readonly IStudyRoomRepository _studyRoomRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studyRoomRepository">Room repository injection</param>
        public StudyRoomService(IStudyRoomRepository studyRoomRepository)
        {
            // Set the injection.
            _studyRoomRepository = studyRoomRepository;
        }

        /// <summary>
        /// Gets all study rooms from repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StudyRoom> GetAll()
        {
            // Return all study rooms.
            return _studyRoomRepository.GetAll();
        }

      
    }
}
