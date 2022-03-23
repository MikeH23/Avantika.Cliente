using ClienteCore.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository.Configuracion
{
    public class CuentaConfig : IEntityTypeConfiguration<Cuentas>
    {
        public void Configure(EntityTypeBuilder<Cuentas> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.IdCliente).HasColumnName("IdCliente");
            entity.Property(e => e.NumeroCuenta).HasColumnName("NumeroCuenta");
            entity.Property(e => e.Saldo).HasColumnName("Saldo");
        }
    }
}
