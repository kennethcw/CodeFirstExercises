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
            SeedCars(dbContext);
        }

        private static void SeedCars(ApplicationDbContext dbContext)
        {
            //AAA313, BBB111, CCC222
            if (!dbContext.Bilar.Any(r => r.Regnummer == "AAA313"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "AAA313",
                    Manufacturer = "Volvo",
                    Model = "XC60",
                    Price = 12000,
                    Year = 1999
                });
            }

            if (!dbContext.Bilar.Any(r => r.Regnummer == "BBB111"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    Regnummer = "BBB111",
                    Manufacturer = "Saab",
                    Model = "V4",
                    Price = 12000,
                    Year = 1973
                });
            }
            
            dbContext.SaveChanges();
        }
    }
}
