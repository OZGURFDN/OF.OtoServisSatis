namespace OtoServisSatis.DAL.Migrations
{
    using OtoServisSatis.Entities;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OtoServisSatis.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OtoServisSatis.DAL.DatabaseContext context)
        {
            if (!context.Kullanicilar.Any())
            {
                var rol = context.Roller.Add(new Rol()
                {
                    Adi = "Admin"
                });

                context.Kullanicilar.Add(new Kullanici()
                {
                    Aktifmi = true,
                    Adi = "Admin",
                    EklenmeTarihi = DateTime.Now,
                    Email = "admin@otoservis.com",
                    KullaniciAdi = "admin",
                    Sifre = "123456",
                    Rol = rol,
                    RolId = rol.Id
                });
                context.SaveChanges();
            }

            base.Seed(context);
        }
    }
}
