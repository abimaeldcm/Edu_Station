namespace Edu_Station.Repositorio.Interfaces
{
    public interface ILoginRepository<T, U> where T : class where U : class
    {
        Task<T> Logar(U login);
        Task<T> BuscarPorEmail(string email);
    }
}
