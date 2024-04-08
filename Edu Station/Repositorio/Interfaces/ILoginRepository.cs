namespace Edu_Station.Repositorio.Interfaces
{
    public interface ILoginRepository<T> where T : class
    {
        Task<T> Logar(T login);
    }
}
