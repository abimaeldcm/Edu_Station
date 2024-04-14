namespace Edu_Station.Repositorio.Interfaces
{
    // Interface genérica para repositórios que lidam com operações de login.
    public interface ILoginRepository<T, U> where T : class where U : class
    {
        // Método para realizar login com base nas credenciais fornecidas.
        Task<T> Logar(U login);

        // Método para buscar uma entidade com base no email.
        Task<T> BuscarPorEmail(string email);
    }
}
