namespace QuestRooms.DAL
{
    using QuestRooms.DAL.Configuration;
    using QuestRooms.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RoomsContext : DbContext
    {
        public RoomsContext()
            : base("name=RoomsContext")
        {
            Database.SetInitializer(new RoomsContextInitializer());
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<QuestRoom> QuestRooms { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}