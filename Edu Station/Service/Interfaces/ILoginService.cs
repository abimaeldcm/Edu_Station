using Edu_Station.Models;

namespace Edu_Station.Service.Interfaces
{
    public interface ILoginService
    {
        Task<Login> Logar(Login login);
    }
}
