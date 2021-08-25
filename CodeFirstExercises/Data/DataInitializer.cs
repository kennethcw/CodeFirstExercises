using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstExercises.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();

            SeedManufacturers(dbContext);
            SeedCars(dbContext);
            SeedLastbilar(dbContext);
            FixManufacturersForBilAndLastbil(dbContext);
            dbContext.SaveChanges();
        }

        private static void FixManufacturersForBilAndLastbil(ApplicationDbContext dbContext)
        {
            var mercedes = dbContext.Manufacturers.First(r => r.Namn == "Mercedes");
            var saab = dbContext.Manufacturers.First(r => r.Namn == "SAAB");
            var ferrari = dbContext.Manufacturers.First(r => r.Namn == "Ferrari");
            dbContext.Lastbilar.First(r => r.Regnummer == "TTT777").Manufacturer = mercedes;
            dbContext.Lastbilar.First(r => r.Regnummer == "OOO999").Manufacturer = saab;
            dbContext.Lastbilar.First(r => r.Regnummer == "HHH111").Manufacturer = ferrari;

            var volvo = dbContext.Manufacturers.First(r => r.Namn == "Volvo");
            var audi = dbContext.Manufacturers.First(r => r.Namn == "Audi");
            var bmw = dbContext.Manufacturers.First(r => r.Namn == "BMW");
            dbContext.Bilar.First(r => r.Regnummer == "AAA313").Manufacturer = volvo;
            dbContext.Bilar.First(r => r.Regnummer == "BBB111").Manufacturer = saab;
            dbContext.Bilar.First(r => r.Regnummer == "PPP222").Manufacturer = mercedes;
            dbContext.Bilar.First(r => r.Regnummer == "HEJ123").Manufacturer = bmw;
            dbContext.Bilar.First(r => r.Regnummer == "POK991").Manufacturer = audi;

            dbContext.SaveChanges();
        }
        
        private static void SeedManufacturers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Manufacturers.Any(r => r.Namn == "SAAB"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "SAAB",
                });
            }

            if (!dbContext.Manufacturers.Any(r => r.Namn == "Volvo"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Volvo",
                });
            }

            if (!dbContext.Manufacturers.Any(r => r.Namn == "Audi"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Audi",
                });
            }

            if (!dbContext.Manufacturers.Any(r => r.Namn == "Mercedes"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Mercedes",
                });
            }

            if (!dbContext.Manufacturers.Any(r => r.Namn == "BMW"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "BMW",
                });
            }

            if (!dbContext.Manufacturers.Any(r => r.Namn == "Ferrari"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Ferrari",
                });
            }
            dbContext.SaveChanges();
        }

        private static void SeedLastbilar(ApplicationDbContext dbContext)
        {
            var mercedes = dbContext.Manufacturers.First(r => r.Namn == "Mercedes");
            var saab = dbContext.Manufacturers.First(r => r.Namn == "SAAB");
            var ferrari = dbContext.Manufacturers.First(r => r.Namn == "Ferrari");

            if (!dbContext.Lastbilar.Any(r => r.Regnummer == "OOO999"))
                dbContext.Lastbilar.Add(new Lastbil
                {
                    Regnummer = "OOO999",
                    Manufacturer = saab,
                    LoadVolumeKvm = 55
                });

            if (!dbContext.Lastbilar.Any(r => r.Regnummer == "TTT777"))
                dbContext.Lastbilar.Add(new Lastbil
                {
                    Regnummer = "TTT777",
                    Manufacturer = mercedes,
                    LoadVolumeKvm = 14
                });

            if (!dbContext.Lastbilar.Any(r => r.Regnummer == "HHH111"))
                dbContext.Lastbilar.Add(new Lastbil
                {
                    Regnummer = "HHH111",
                    Manufacturer = ferrari,
                    LoadVolumeKvm = 94
                });
            dbContext.SaveChanges();
        }

     

        private static void SeedCars(ApplicationDbContext dbContext)
        {
            var volvo = dbContext.Manufacturers.First(r => r.Namn == "Volvo");
            var saab = dbContext.Manufacturers.First(r => r.Namn == "Saab");
            var audi = dbContext.Manufacturers.First(r => r.Namn == "Audi");
            var mercedes = dbContext.Manufacturers.First(r => r.Namn == "Mercedes");
            var bmw = dbContext.Manufacturers.First(r => r.Namn == "BMW");

            //AAA313, BBB111, CCC222
            if (!dbContext.Bilar.Any(r => r.Regnummer == "AAA313"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "AAA313",
                    Manufacturer = volvo,
                    Model = "XC60",
                    Price = 12000,
                    Year = 1999,
                    HasRadio = true
                });
            }

            if (!dbContext.Bilar.Any(r => r.Regnummer == "BBB111"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "BBB111",
                    Manufacturer = saab,
                    Model = "V4",
                    Price = 12000,
                    Year = 1973,
                    HasRadio = false
                });
            }

            if (!dbContext.Bilar.Any(r => r.Regnummer == "PPP222"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "PPP222",
                    Manufacturer = mercedes,
                    Model = "c63",
                    Price = 57000,
                    Year = 2010,
                    HasRadio = false,
                });
            }

            if (!dbContext.Bilar.Any(r => r.Regnummer == "HEJ123"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "HEJ123",
                    Manufacturer = bmw,
                    Model = "428i",
                    Price = 150000,
                    Year = 2008,
                    HasRadio = true
                });
            }

            if (!dbContext.Bilar.Any(r => r.Regnummer == "POK991"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "POK991",
                    Manufacturer = audi,
                    Model = "A6",
                    Price = 89000,
                    Year = 2013,
                    HasRadio = true
                });
                dbContext.SaveChanges();
            }

        }
    }
}
