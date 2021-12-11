using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using System.Collections.Generic;

namespace Bongo.Core.Services.IServices
{
    /// <summary>
    /// StudyRoom booking service
    /// </summary>
    public interface IStudyRoomBookingService
    {
        /// <summary>
        /// Books a study room
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        StudyRoomBookingResult BookStudyRoom(StudyRoomBooking request);
        
        /// <summary>
        /// Gets all book
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudyRoomBooking> GetAllBooking();
    }
}
