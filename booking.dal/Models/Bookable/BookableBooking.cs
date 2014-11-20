using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.dal.Models
{
    public class BookableBooking
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string ByName { get; set; }
        public string ById { get; set; }

        public string Notes { get; set; }

        public bool Recurring { get; set; }

        public BookingType Type { get; set; }
    }

    public enum BookingType
    {
        Booking,
        Restriction
    }
}