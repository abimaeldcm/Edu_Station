using Edu_Station.Models;

namespace Edu_Station.SessaoUsuario
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Login usuario);
        void RemoverSessaoUsuario();
        Login BuscarSessaoDoUsuario();
    }
}
