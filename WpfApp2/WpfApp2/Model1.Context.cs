﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToursBaseEntities3 : DbContext
    {
        public ToursBaseEntities3()
            : base("name=ToursBaseEntities3")
        {
        }

        private static ToursBaseEntities3 _context;
        public static ToursBaseEntities3 GetContext()
        {
            if (_context == null)
                _context = new ToursBaseEntities3();
            return _context;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelComment> HotelComments { get; set; }
        public virtual DbSet<HotelImage> HotelImages { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<TypeOfUser> TypeOfUsers { get; set; }
        public virtual DbSet<TourAndHotel> TourAndHotels { get; set; }
        public virtual DbSet<USERDATA> USERDATAs { get; set; }
    }
}