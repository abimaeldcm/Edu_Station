

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
                    Id = new Guid("bd923fe1-3e73-4dda-ae5c-c27588ab08db"),
                    NomeCompleto = "José de Arimateia",
                    CPF = "06445225447",
                    DataNascimento = new DateTime(1999, 04, 25),
                    Email = "josearimateia@mail.com",
                    Telefone = "86995258775",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("e3f72cbf-35ed-4f7e-8476-72ba3c3cc5e3"),
                    NomeCompleto = "Maria da Silva",
                    CPF = "12345678901",
                    DataNascimento = new DateTime(2000, 07, 15),
                    Email = "mariasilva@mail.com",
                    Telefone = "86991234567",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("963c7e5d-2f0e-45ec-8d4e-1216f62627d7"),
                    NomeCompleto = "João da Silva",
                    CPF = "98765432109",
                    DataNascimento = new DateTime(1998, 10, 31),
                    Email = "joaosilva@mail.com",
                    Telefone = "86997654321",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("a3c750e3-3d79-4d3e-923e-2fcd52794c0c"),
                    NomeCompleto = "Ana Souza",
                    CPF = "45678912345",
                    DataNascimento = new DateTime(2001, 03, 20),
                    Email = "anasouza@mail.com",
                    Telefone = "86999887766",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("e5b01b44-32b8-4c5d-8090-23c2d0a0c6cb"),
                    NomeCompleto = "Pedro Oliveira",
                    CPF = "98765432198",
                    DataNascimento = new DateTime(2002, 05, 18),
                    Email = "pedrooliveira@mail.com",
                    Telefone = "86994433221",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("94d7934e-3462-4b97-91c7-6a7d16d456ad"),
                    NomeCompleto = "Carla Santos",
                    CPF = "01234567890",
                    DataNascimento = new DateTime(2003, 08, 05),
                    Email = "carlasantos@mail.com",
                    Telefone = "86995544333",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("fb03391d-6223-4a4c-87f6-ec131dbbd99d"),
                    NomeCompleto = "Mariana Oliveira",
                    CPF = "10293847560",
                    DataNascimento = new DateTime(2004, 11, 12),
                    Email = "marianaoliveira@mail.com",
                    Telefone = "86993322111",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Aluno
                {
                    Id = new Guid("f12bc8d1-4e2b-4b7d-af42-b858bb362cf9"),
                    NomeCompleto = "Fernando Lima",
                    CPF = "09876543210",
                    DataNascimento = new DateTime(2005, 02, 28),
                    Email = "fernandolima@mail.com",
                    Telefone = "86996655443",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                });
        }
    }
}