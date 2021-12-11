using Bongo.Models.Model;
using System;
using System.Collections.Generic;

namespace Bongo.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Study room booking interface.
    /// </summary>
    public interface IStudyRoomBookingRepository
    {
        /// <summary>
        /// Books a new study room
        /// </summary>
        /// <param name="booking">Booking information</param>
        void Book(StudyRoomBooking booking);

        /// <summary>
        /// Gets all bookings from the database
        /// </summary>
        /// <param name="dateTime">Date parameter</param>
        /// <returns></returns>
        IEnumerable<StudyRoomBooking> GetAll(DateTime? dateTime);
        
    }
}
