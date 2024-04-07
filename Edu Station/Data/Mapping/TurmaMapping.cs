using Edu_Station.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Edu_Station.Data.Mapping
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(t => t.Alunos)
                .WithOne(a => a.Turma)
                .HasForeignKey(a => a.IdTurma);
            builder.HasData(
                new Turma
                {
                    Id = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Nome = "1A",
                    Ano = "2024",
                    DataCriacao = DateTime.Now
                }
            );

        }
    }
}
