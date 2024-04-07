using Edu_Station.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Edu_Station.Data.Mapping
{
    public class DocenteMapping : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(d => d.Disciplinas);
            builder.HasMany(d => d.Alunos);
            builder.HasMany(d => d.Turmas);

            builder.Property(x => x.NomeCompleto)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(x => x.DataNascimento)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.Telefone)
                .IsRequired();
        }
    }
}
