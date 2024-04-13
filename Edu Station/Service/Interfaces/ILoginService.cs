namespace Edu_Station.Service.Interfaces
{
    public interface ILoginService<T, U> where T : class where U : class
    {
        Task<T> Logar(U login);
        Task<T> BuscarPorEmail(string email);
        Task AlterarSenha(T pessoa, string novaSenha);
    }
}
