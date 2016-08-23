
namespace Serverbooking.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ServerInfoEntities : DbContext
    {
        public ServerInfoEntities()
            : base("name=ServerInfoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookingInfo> BookingInfo { get; set; }
        public virtual DbSet<InfoServer> InfoServers { get; set; }
    }
}
