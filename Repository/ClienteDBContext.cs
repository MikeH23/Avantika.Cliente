using ClienteCore.Models.Entity;
using ClienteCore.Repository.Configuracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository
{
    public partial class ClienteDBContext : DbContext
    {
        //------------------------------------------------------------------------
        public virtual DbSet<Cliente> cliente { get; set; }
        public virtual DbSet<Cuentas> cuentas { get; set; }
        //------------------------------------------------------------------------

        //------------------------------------------------------------------------
        public ClienteDBContext(DbContextOptions<ClienteDBContext> options)
          : base(options)
        {

        }
        //------------------------------------------------------------------------

        //------------------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new CuentaConfig());
            OnModelCreatingPartial(modelBuilder);
        }
        //------------------------------------------------------------------------
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        //------------------------------------------------------------------------
    }
}
