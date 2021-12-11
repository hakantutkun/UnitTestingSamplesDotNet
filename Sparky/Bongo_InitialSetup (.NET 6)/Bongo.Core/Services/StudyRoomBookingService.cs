using Bongo.Core.Services.IServices;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bongo.Core.Services
{
    /// <summary>
    /// Study Room Booking Service
    /// </summary>
    public class StudyRoomBookingService : IStudyRoomBookingService
    {
        /// <summary>
        /// StudyRoom Booking Repository Object
        /// </summary>
        private readonly IStudyRoomBookingRepository _studyRoomBookingRepository;
        
        /// <summary>
        /// StudyRoom Repository Object
        /// </summary>
        private readonly IStudyRoomRepository _studyRoomRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studyRoomBookingRepository">StudyRoom Booking Repository Injection</param>
        /// <param name="studyRoomRepository">Study Room Repository Injection</param>
        public StudyRoomBookingService(IStudyRoomBookingRepository studyRoomBookingRepository,IStudyRoomRepository studyRoomRepository)
        {
            // Set the injections
            _studyRoomRepository = studyRoomRepository;
            _studyRoomBookingRepository = studyRoomBookingRepository;
        }

        /// <summary>
        /// Books a study room.
        /// </summary>
        /// <param name="request">Received request information</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public StudyRoomBookingResult BookStudyRoom(StudyRoomBooking request)
        {
            // Check if request is null
            if (request == null)
            {
                //If so, throw an exception.
                throw new ArgumentNullException(nameof(request));
            }

            // Set a new result object 
            StudyRoomBookingResult result = new() {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };

            // Get all booked rooms from database
            IEnumerable<int> bookedRooms = _studyRoomBookingRepository.GetAll(request.Date).Select(u=>u.StudyRoomId);
            
            // Get all available rooms from the database
            IEnumerable<StudyRoom> availableRooms = _studyRoomRepository.GetAll().Where(u => !bookedRooms.Contains(u.Id));
            
            // Check if any rooms available
            if (availableRooms.Any())
            {
                // Set a new instance of studyroom booking.
                StudyRoomBooking studyRoomBooking = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Date = request.Date
                };

                // Set the id of instace to id of one of the available rooms.
                studyRoomBooking.StudyRoomId = availableRooms.FirstOrDefault().Id;


                _studyRoomBookingRepository.Book(studyRoomBooking);
                result.BookingId = studyRoomBooking.BookingId;
                result.Code = StudyRoomBookingCode.Success;
            }
            else
            {
                result.Code = StudyRoomBookingCode.NoRoomAvailable;
            }

            return result;
        }

        public IEnumerable<StudyRoomBooking> GetAllBooking()
        {
            return _studyRoomBookingRepository.GetAll(null);
        }

    
    }

}
