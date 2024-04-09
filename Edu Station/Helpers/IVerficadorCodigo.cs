using Edu_Station.Models.Enum;

namespace Edu_Station.Helpers
{
    public interface IVerficadorCodigo
    {
        Task GuardarEmailCache(string email);
        Task GuardarPerfilCache(EPerfil perfil);
        Task<bool> ValidarEmailCache(string email);
        Task<string> RecuperarEmailCache();
        Task<int> RecuperarPerfilCache();
        Task<int> GerarCodigo();
        Task<bool> ValidarCodigoEnviado(string codigo);
    }
}
