using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).IsRequired();
            builder.Property(x => x.RazaoSocial).IsRequired();
            builder.Property(x => x.UltimaCompra).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Telefone2).IsRequired(false);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();

        }
    }
}
