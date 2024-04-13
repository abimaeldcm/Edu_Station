

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
                    Id = new Guid("f12bc8d1-4e2b-4b5d-af42-b858bb362cf9"),
                    NomeCompleto = "Fernando Lima",
                    CPF = "09876543210",
                    DataNascimento = new DateTime(2005, 02, 28),
                    Email = "fernandolima@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "86996655443",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("f12bc8d1-4e2b-4b7d-af42-b858bb362cf9"),
                    NomeCompleto = "Fernando Lima",
                    CPF = "09876543210",
                    DataNascimento = new DateTime(2005, 02, 28),
                    Email = "fernandolima@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "86996655443",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("98bc7d6e-5a1f-4c7c-bddb-93733fb6d4d1"),
                    NomeCompleto = "Maria Silva",
                    CPF = "01234567890",
                    DataNascimento = new DateTime(2003, 04, 15),
                    Email = "mariasilva@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "85997766554",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("a2e1b68e-f2d8-4e33-9cbf-9fe5125aeff7"),
                    NomeCompleto = "João Oliveira",
                    CPF = "12345678901",
                    DataNascimento = new DateTime(2004, 07, 20),
                    Email = "joaooliveira@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "81998877665",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("fb9c8a3b-4dc7-4981-b38f-9a50031e5b84"),
                    NomeCompleto = "Ana Souza",
                    CPF = "23456789012",
                    DataNascimento = new DateTime(2003, 12, 10),
                    Email = "anasouza@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "11997766554",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("ec1f4354-865e-47a1-8c6f-31f69360b97d"),
                    NomeCompleto = "Pedro Santos",
                    CPF = "34567890123",
                    DataNascimento = new DateTime(2004, 05, 25),
                    Email = "pedrosantos@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "21998877665",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("6d1cb8d4-4c70-44e8-8e58-b1c378c5271b"),
                    NomeCompleto = "Mariana Costa",
                    CPF = "45678901234",
                    DataNascimento = new DateTime(2005, 09, 18),
                    Email = "marianacosta@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "31997766554",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("314eb2b5-20ef-4ba4-853c-0b5acfaa45dc"),
                    NomeCompleto = "Carlos Oliveira",
                    CPF = "56789012345",
                    DataNascimento = new DateTime(2004, 02, 10),
                    Email = "carlosoliveira@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "11998877665",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("54b13b24-bc53-4826-9f9e-b5b75bca12c0"),
                    NomeCompleto = "Juliana Lima",
                    CPF = "67890123456",
                    DataNascimento = new DateTime(2003, 07, 28),
                    Email = "julianalima@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "85998877665",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                },
                new Aluno
                {
                    Id = new Guid("a2d6d6b8-6eb6-40a2-978d-ae48fd5f7f6d"),
                    NomeCompleto = "Lucas Ferreira",
                    CPF = "78901234567",
                    DataNascimento = new DateTime(2005, 11, 15),
                    Email = "lucasferreira@mail.com",
                    Perfil = Models.Enum.EPerfil.Aluno,
                    Telefone = "81998877665",
                    IdTurma = new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Senha = "123"
                }
            );
        }
    }
}
