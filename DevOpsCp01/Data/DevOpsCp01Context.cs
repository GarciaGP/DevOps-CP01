using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevOpsCp01.Models;

namespace DevOpsCp01.Data
{
    public class DevOpsCp01Context : DbContext
    {
        public DevOpsCp01Context (DbContextOptions<DevOpsCp01Context> options)
            : base(options)
        {
        }

        public DbSet<DevOpsCp01.Models.Cliente> Clientes { get; set; }
        public DbSet<DevOpsCp01.Models.Cartao> Cartoes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(key => key.Id).HasName("id_cliente");
            });

            modelbuilder.Entity<Cartao>();

        }
    }
}
