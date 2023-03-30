using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using OtoServisSatis.Entities;

namespace OtoServisSatis.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Arac { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                //if (!context.Kullanicilar.Any())
                //{
                //    context.Kullanicilar.Add(new Entities.Kullanici()
                //    {
                //        Aktifmi = true,
                //        Adi = "Admin",
                //        EklenmeTarihi = DateTime.Now,
                //        Email = "admin@otoservis.com",
                //        KullaniciAdi = "admin",
                //        Sifre = "123456"
                //    });
                //    context.SaveChanges();
                //}
                base.Seed(context);
            }
        }

        public DatabaseContext():base("DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
    }

}