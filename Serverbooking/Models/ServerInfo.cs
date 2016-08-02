using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serverbooking.Models
{
    public class ServerInfo
    {
        public int ServerID { get; set; }
        public string Status { get; set; }
        public string ServerName { get; set; }
        public string Environment { get; set; }
        public int ActiveBookingID { get; set; }

        internal static ServerInfo Find(int? serverID)
        {
            throw new NotImplementedException();
        }
    }
    
}