namespace Edu_Station.Service.Interface
    {
    public interface ICRUDService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Buscar(Guid id);
        Task<T> Adicionar(T adicionar);
        Task<T> Editar(T editar);
        Task Delete(Guid id);

    }
}
