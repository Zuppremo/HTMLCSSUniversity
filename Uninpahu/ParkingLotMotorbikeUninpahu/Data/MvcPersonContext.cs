using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingLotMotorbikeUninpahu.Models;

namespace ParkingLotMotorbikeUninpahu.Data
{
    public class MvcPersonContext : DbContext
    {
        public MvcPersonContext (DbContextOptions<MvcPersonContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingLotMotorbikeUninpahu.Models.Person> Person { get; set; } = default!;
    }
}
