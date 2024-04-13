using Edu_Station.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
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

            builder.HasData(
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                        NomeCompleto = "José da Silva Santos",
                        CPF = "03223652566",
                        DataNascimento = new DateTime(1980, 1, 1),
                        Email = "jose@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "123",
                        Telefone = "86995522588",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb8"),
                        NomeCompleto = "Maria Oliveira",
                        CPF = "12345678910",
                        DataNascimento = new DateTime(1975, 5, 15),
                        Email = "maria@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "456",
                        Telefone = "86998877441",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb9"),
                        NomeCompleto = "João Pereira",
                        CPF = "98765432100",
                        DataNascimento = new DateTime(1990, 10, 30),
                        Email = "joao@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "789",
                        Telefone = "869977336699",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fba"),
                        NomeCompleto = "Ana Souza",
                        CPF = "55544433322",
                        DataNascimento = new DateTime(1985, 3, 20),
                        Email = "ana@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "abc",
                        Telefone = "869911223344",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbb"),
                        NomeCompleto = "Pedro Santos",
                        CPF = "11223344556",
                        DataNascimento = new DateTime(1978, 7, 8),
                        Email = "pedro@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "def",
                        Telefone = "869922334455",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbc"),
                        NomeCompleto = "Mariana Costa",
                        CPF = "99887766554",
                        DataNascimento = new DateTime(1982, 9, 12),
                        Email = "mariana@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "ghi",
                        Telefone = "869933445566",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbd"),
                        NomeCompleto = "Carlos Oliveira",
                        CPF = "77665544332",
                        DataNascimento = new DateTime(1970, 11, 25),
                        Email = "carlos@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "jkl",
                        Telefone = "869944556677",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbe"),
                        NomeCompleto = "Aline Pereira",
                        CPF = "33445566778",
                        DataNascimento = new DateTime(1995, 4, 18),
                        Email = "aline@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "mno",
                        Telefone = "869955667788",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbf"),
                        NomeCompleto = "Marcos Silva",
                        CPF = "22334455667",
                        DataNascimento = new DateTime(1987, 6, 5),
                        Email = "marcos@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "pqr",
                        Telefone = "869966778899",
                    },
                    new Docente
                    {
                        Id = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fc0"),
                        NomeCompleto = "Laura Santos",
                        CPF = "77889900123",
                        DataNascimento = new DateTime(1983, 8, 29),
                        Email = "laura@email.com",
                        Perfil = Models.Enum.EPerfil.Docente,
                        Senha = "stu",
                        Telefone = "869977889900",
                    });
        }

    }
}
