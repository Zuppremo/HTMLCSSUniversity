using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkingLotMotorbikeUninpahu.Data;
using System;
using System.Linq;

namespace ParkingLotMotorbikeUninpahu.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPersonContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcPersonContext>>()))
            {
                if (context.Person.Any())
                {
                    return; // DB has been seeded
                }
                context.Person.AddRange(
                    new Person
                    {
                        Name = "Juan Baquero",
                        Email = "juanbaquero@gmail.com",
                        IdentificationNumber = "1000321222",
                        Phone = "3140239422"
                    },
                    new Person
                    {
                        Name = "Sara Rosas",
                        Email = "sararosas@gmail.com",
                        IdentificationNumber = "10002365522",
                        Phone = "3154856525"
                    },
                    new Person
                    {
                        Name = "Deybi Montenegro",
                        Email = "deibymontenegrob@gmail.com",
                        IdentificationNumber = "1000578612",
                        Phone = "3160474606"
                    },
                    new Person
                    {
                        Name = "Daniel Melo",
                        Email = "danielmelo@gmail.com",
                        IdentificationNumber = "100478811",
                        Phone = "3195212356"
                    },
                    new Person
                    {
                        Name = "Leyla Bahamon",
                        Email = "leylita@gmail.com",
                        IdentificationNumber = "39652968",
                        Phone = "3195763562"
                    },
                    new Person
                    {
                        Name = "Alberto Fernandez",
                        Email = "albertofernandez@gmail.com",
                        IdentificationNumber = "100586223",
                        Phone = "3185475522"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
