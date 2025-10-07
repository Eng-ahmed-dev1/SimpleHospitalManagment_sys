using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_man_sys.Model
{
    internal class HospitalDB : DbContext
    {
        public HospitalDB() { }
        public HospitalDB(DbContextOptions<HospitalDB> options) : base(options){ }

        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2008HFE\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }

    }
}
