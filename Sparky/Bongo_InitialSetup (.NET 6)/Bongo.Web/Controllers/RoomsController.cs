using Bongo.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Bongo.Web.Controllers
{
    /// <summary>
    /// Rooms Controller Class
    /// </summary>
    public class RoomsController : Controller
    {

        private readonly IStudyRoomService _studyRoomService;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studyRoomService">Study room service</param>
        public RoomsController(IStudyRoomService studyRoomService)
        {
            // Set the dependency injection.
            _studyRoomService = studyRoomService;

        }

        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // return all rooms
            return View(_studyRoomService.GetAll());
        }

       
    }
}
