﻿namespace ConferenceRoomBooking.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int NumPeople { get; set; }
        public bool IsConfirmed { get; set; }
        public string RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
