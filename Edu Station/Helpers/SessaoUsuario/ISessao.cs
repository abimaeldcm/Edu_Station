using Edu_Station.Models;

namespace Edu_Station.SessaoUsuario
{
    public interface ISessao
    {
        Task CriarSessaoDoUsuario(Pessoa usuario);
        Task RemoverSessaoUsuario();
        Task<Pessoa> BuscarSessaoDoUsuario();
    }
}
