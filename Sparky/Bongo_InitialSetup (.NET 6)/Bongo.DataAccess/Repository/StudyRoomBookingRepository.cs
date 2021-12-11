using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bongo.DataAccess.Repository
{
    /// <summary>
    /// Repository for <see cref="StudyRoomBooking"/>
    /// </summary>
    public class StudyRoomBookingRepository : IStudyRoomBookingRepository
    {
        /// <summary>
        /// Database Context Object
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database Context injection</param>
        public StudyRoomBookingRepository(ApplicationDbContext context)
        {
            // Set the injection
            _context = context;
        }

        /// <summary>
        /// Gets all bookings from the database
        /// </summary>
        /// <param name="date">Date parameter</param>
        /// <returns></returns>
        public IEnumerable<StudyRoomBooking> GetAll(DateTime? date)
        {
            // Check if the date parameter is null
            if (date != null)
            {
                // If not, return date filtered data.
                return _context.StudyRoomBookings.Where(x => x.Date == date).OrderBy(x => x.BookingId).ToList();
            }

            // Otherwise, return all the study room bookings.
            return _context.StudyRoomBookings.OrderBy(x => x.BookingId).ToList();
        }

        /// <summary>
        /// Adds a new study room booking to the database.
        /// </summary>
        /// <param name="booking"></param>
        public void Book(StudyRoomBooking booking)
        {
            // Add the booking to the database
            _context.StudyRoomBookings.Add(booking);
           
            // Save the changes.
            _context.SaveChanges();
        }
    }
}
