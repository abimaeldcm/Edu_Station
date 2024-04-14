namespace Edu_Station.Repositorio.Interfaces
{
    // Interface genérica para repositórios que lidam com operações CRUD (Create, Read, Update, Delete).
    public interface ICRUDRepository<T> where T : class
    {
        // Obtém todos os itens do tipo T.
        Task<List<T>> GetAll();

        // Busca um item com base no ID.
        Task<T> Buscar(Guid id);

        // Adiciona um novo item.
        Task<T> Adicionar(T adicionar);

        // Edita um item existente.
        Task<T> Editar(T editar);

        // Deleta um item com base no ID.
        Task<bool> Delete(Guid id);
    }
}
