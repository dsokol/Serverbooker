using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serverbooking.Models
{
    public class BookingInfo
    {
        public int BookingID { get; set; }
        public int ServerID { get; set; }
        public string UserID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set;  } 
    }
}