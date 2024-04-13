using Edu_Station.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Data.Mapping
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Docente)
                .WithMany()
                .HasForeignKey(x => x.IdDocente);
            builder.HasData(
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"),
                    Nome = "Português",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb7")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fb8"),
                    Nome = "Matemática",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb8")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fb9"),
                    Nome = "História",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb9")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fba"),
                    Nome = "Geografia",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fba")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbb"),
                    Nome = "Ciências",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbb")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbc"),
                    Nome = "Inglês",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbc")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbd"),
                    Nome = "Educação Física",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbd")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbe"),
                    Nome = "Artes",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbe")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbf"),
                    Nome = "Química",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbf")
                },
                new Disciplina
                {
                    Id = new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fc0"),
                    Nome = "Física",
                    DataCriacao = DateTime.Now,
                    IdDocente = new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fc0")
                });
        }

    }


}
