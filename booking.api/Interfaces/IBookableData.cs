using booking.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.api.Interfaces
{
    public interface IBookableData
    {
        List<BookableBooking> Bookings { get; set; }
    }
}
