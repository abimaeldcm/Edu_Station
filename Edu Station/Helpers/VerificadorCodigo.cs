using Edu_Station.Models.Enum;
using Microsoft.Extensions.Caching.Memory;

namespace Edu_Station.Helpers
{
    public class VerificadorCodigo : IVerficadorCodigo
    {
        private readonly IMemoryCache _memoryCache;

        public VerificadorCodigo(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task GuardarEmailCache(string email)
        {
            _memoryCache.Set("EmailCache", email, TimeSpan.FromMinutes(10));
            return Task.CompletedTask;
        }

        public Task GuardarPerfilCache(EPerfil perfil)
        {
            _memoryCache.Set("PerfilCache", perfil);
            return Task.CompletedTask;

        }

        public Task<bool> ValidarEmailCache(string email)
        {
            _memoryCache.TryGetValue("EmailCache", out string storedCode);
            if (storedCode == email)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<string> RecuperarEmailCache()
        {
            _memoryCache.TryGetValue("EmailCache", out string storedCode);
            return Task.FromResult(storedCode);
        }
        public Task<int> RecuperarPerfilCache()
        {
            _memoryCache.TryGetValue("PerfilCache", out int storedCode);
            return Task.FromResult(storedCode);
        }


        public Task<int> GerarCodigo()
        {
            Random rand = new Random();
            int codigo = rand.Next(100000, 999999); // Garantindo um código de 6 dígitos

            _memoryCache.Set("codigoCache", codigo.ToString(), TimeSpan.FromMinutes(10));

            return Task.FromResult(codigo);
        }

        public Task<bool> ValidarCodigoEnviado(string codigo)
        {
            _memoryCache.TryGetValue("codigoCache", out string storedCode);

            // Compare as strings, não os códigos inteiros
            if (storedCode == codigo)
            {
                return Task.FromResult(true); // Os códigos coincidem
            }
            return Task.FromResult(false); // Os códigos não coincidem
        }

    }
}
