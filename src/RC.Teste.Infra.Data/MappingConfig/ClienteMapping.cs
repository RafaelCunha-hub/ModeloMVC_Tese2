using RC.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Infra.Data.MappingConfig
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapping()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(150);

            Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(100);

            Property(c => c.Sexo)
              .IsRequired()
              .HasColumnType("char")
              .HasMaxLength(1);

            Property(c => c.Cpf)
               .IsRequired()
               .HasMaxLength(11)
               .IsFixedLength()
               .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            Property(c => c.DataNascimento)
               .IsRequired()
               .HasColumnType("date");

            Ignore(c => c.ValidationResult);

            ToTable("Clientes");
        }
    }
}
