using ClienteCore.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository.Configuracion
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.IdCliente);
            entity.Property(e => e.IdCliente).HasColumnName("IdCliente");
            entity.Property(e => e.Nombre).HasColumnName("Nombre");
            entity.Property(e => e.Apellidos).HasColumnName("Apellidos");
            entity.Property(e => e.Edad).HasColumnName("Edad");
        }
    }    
}
