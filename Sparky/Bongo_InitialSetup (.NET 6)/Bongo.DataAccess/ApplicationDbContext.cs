using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Bongo.DataAccess
{
    /// <summary>
    /// Booking Application Database Context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Application DBContext Options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// DBSet for StudyRooms
        /// </summary>
        public DbSet<StudyRoom> StudyRooms { get; set; }
        
        /// <summary>
        /// DBSet For StudyRoomBookings
        /// </summary>
        public DbSet<StudyRoomBooking> StudyRoomBookings { get; set; }

        /// <summary>
        /// Define some pre build information while creating the database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id=1,
                    RoomName="Everest",
                    RoomNumber="A101"
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 2,
                    RoomName = "Superior",
                    RoomNumber = "A201"
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 3,
                    RoomName = "Victoria",
                    RoomNumber = "A301"
                }
            );
        }
    }
}
