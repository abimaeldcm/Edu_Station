

using Edu_Station.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu_Station.Data.Mapping
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Turma)
                .WithMany()
                .HasForeignKey(x => x.IdTurma);

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
            builder.HasData(
                new Aluno
                {
                    Id = new Guid("f12bc8d1-4e2b-4b7d-af42-b858bb362cf9"),
                    NomeCompleto = "Fernando Lima",
                    CPF = "09876543210",
                    DataNascimento = new DateTime(2005, 02, 28),
                    Email = "fernandolima@mail.com",
                    Telefone = "86996655443",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                });
        }
    }
}