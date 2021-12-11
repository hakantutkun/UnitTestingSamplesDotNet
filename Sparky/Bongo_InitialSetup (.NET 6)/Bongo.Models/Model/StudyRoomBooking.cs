using Bongo.Models.Model.VM;
using System.ComponentModel.DataAnnotations;

namespace Bongo.Models.Model
{
    /// <summary>
    /// StudyRoom Booking Model
    /// </summary>
    public class StudyRoomBooking : StudyRoomBookingBase
    {
        /// <summary>
        /// Booking ID
        /// </summary>
        [Key]
        public int BookingId { get; set; }

        /// <summary>
        /// Study Room Id
        /// </summary>
        public int StudyRoomId { get; set; }
    }
}
