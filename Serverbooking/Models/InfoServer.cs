
namespace Serverbooking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InfoServer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InfoServer()
        {
            this.BookingInfo = new HashSet<BookingInfo>();
        }
    
        public int ServerID { get; set; }
        public string Status { get; set; }
        public string ServerName { get; set; }
        public string Environment { get; set; }
        public Nullable<int> ActiveBookingID { get; set; }
        public string UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingInfo> BookingInfo { get; set; }
    }
}
