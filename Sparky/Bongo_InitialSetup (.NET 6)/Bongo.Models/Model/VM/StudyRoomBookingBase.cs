using Bongo.Models.ModelValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bongo.Models.Model.VM
{
    /// <summary>
    /// Booking base class
    /// </summary>
    public class StudyRoomBookingBase
    {
        /// <summary>
        /// Booking FirstName
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Booking LastName
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Booking Email
        /// </summary>
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Booking Date
        /// </summary>
        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime Date { get; set; }

        
    }
}
