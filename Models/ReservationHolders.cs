﻿namespace ConferenceRoomBooking.Models
{
    public class ReservationHolders
    {
        public int Id { get; set; }
        public int IdCardNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int BookingId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
