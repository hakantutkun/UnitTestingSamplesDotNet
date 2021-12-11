namespace Bongo.Models.Model.VM
{
    /// <summary>
    /// Booking Result Model
    /// </summary>
    public class StudyRoomBookingResult : StudyRoomBookingBase
    {
        /// <summary>
        /// Room booking return code
        /// </summary>
        public StudyRoomBookingCode Code { get; set; }

        /// <summary>
        /// The id of the booking
        /// </summary>
        public int BookingId { get; set; }
    }
}
