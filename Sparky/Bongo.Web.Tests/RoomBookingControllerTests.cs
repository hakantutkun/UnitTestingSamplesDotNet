using Bongo.Core.Services.IServices;
using Bongo.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Bongo.Web.Tests
{
    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingService;
        private RoomBookingController _bookingController;

        [SetUp] 
        public void SetUp()
        {
            _studyRoomBookingService = new Mock<IStudyRoomBookingService>();
            _bookingController = new RoomBookingController(_studyRoomBookingService.Object);
        }

        [Test]
        public void IndexPage_CallRequest_VerifyAllInvoked()
        {
            _bookingController.Index();
            _studyRoomBookingService.Verify(x=> x.GetAllBooking(), Times.Once);
        }
    }
}
