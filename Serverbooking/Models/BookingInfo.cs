
namespace Serverbooking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingInfo
    {
        public int BookingID { get; set; }
        public int ServerID { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> CheckInTime { get; set; }
        public Nullable<System.DateTime> CheckOutTime { get; set; }
    
        public virtual InfoServer InfoServer { get; set; }
    }
}
