using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Microsoft.AspNetCore.Mvc;

namespace Bongo.Web.Controllers
{
    /// <summary>
    /// Room Booking Controller Class
    /// </summary>
    public class RoomBookingController : Controller
    {
        /// <summary>
        /// StudyRoom Booking Service
        /// </summary>
        private IStudyRoomBookingService _studyRoomBookingService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studyRoomBookingService">Service that will be injected.</param>
        public RoomBookingController(IStudyRoomBookingService studyRoomBookingService)
        {
            // Set the dependency injecion.
            _studyRoomBookingService = studyRoomBookingService;
        }

        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // return all bookings
            return View(_studyRoomBookingService.GetAllBooking());

        }

        /// <summary>
        /// Book Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Book()
        {
            return View();
        }

        /// <summary>
        /// Post Method of StudyRoom Booking
        /// </summary>
        /// <param name="studyRoomBooking">Booking model of the room that will be booked.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Book(StudyRoomBooking studyRoomBooking)
        {
            // Set an action result object
            IActionResult actionResult = View("Book");
           
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Book the room
                var result = _studyRoomBookingService.BookStudyRoom(studyRoomBooking);
                
                // Check if the room successfully booked.
                if (result.Code == StudyRoomBookingCode.Success)
                {
                    // If the room booked successfully, redirect to booking confirmation page.
                    actionResult = RedirectToAction("BookingConfirmation", result);
                }
                else if (result.Code == StudyRoomBookingCode.NoRoomAvailable)
                {
                    // Otherwise, show to user an error message.
                    ViewData["Error"] = "No Study Room available for selected date";
                }
            }

            // If model is not valid, return a null action.
            return actionResult;
        }

        /// <summary>
        /// BookingConfirmation Action
        /// </summary>
        /// <param name="studyRoomBooking">The confirmation info.</param>
        /// <returns></returns>
        public IActionResult BookingConfirmation(StudyRoomBookingResult studyRoomBooking)
        {
            // Return the confirmation info
            return View(studyRoomBooking);
        }
    }
}
