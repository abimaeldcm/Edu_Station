using Edu_Station.Models;

namespace Edu_Station.SessaoUsuario
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Enum usuario);
        void RemoverSessaoUsuario();
        Enum BuscarSessaoDoUsuario();
    }
}
