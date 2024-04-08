namespace Edu_Station.Repositorio.Interfaces
{
    public interface ICRUDRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Buscar(Guid id);
        Task<T> Adicionar(T adicionar);
        Task<T> Editar(T editar);
        Task<bool> Delete(Guid id);

    }
}
