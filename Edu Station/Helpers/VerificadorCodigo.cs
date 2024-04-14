using Edu_Station.Models.Enum;
using Microsoft.Extensions.Caching.Memory;

namespace Edu_Station.Helpers
{
    // Serviço para verificar e armazenar códigos e informações em cache
    public class VerificadorCodigo : IVerficadorCodigo
    {
        private readonly IMemoryCache _memoryCache;

        // Construtor que injeta uma instância do IMemoryCache
        public VerificadorCodigo(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // Método para armazenar o e-mail em cache
        public Task GuardarEmailCache(string email)
        {
            _memoryCache.Set("EmailCache", email, TimeSpan.FromMinutes(10)); // Armazena o e-mail em cache por 10 minutos
            return Task.CompletedTask;
        }

        // Método para armazenar o perfil em cache
        public Task GuardarPerfilCache(EPerfil perfil)
        {
            _memoryCache.Set("PerfilCache", perfil); // Armazena o perfil em cache
            return Task.CompletedTask;
        }

        // Método para validar se o e-mail está em cache
        public Task<bool> ValidarEmailCache(string email)
        {
            _memoryCache.TryGetValue("EmailCache", out string storedCode);
            if (storedCode == email)
            {
                return Task.FromResult(true); // Retorna true se o e-mail estiver em cache
            }
            return Task.FromResult(false); // Retorna false se o e-mail não estiver em cache
        }

        // Método para recuperar o e-mail do cache
        public Task<string> RecuperarEmailCache()
        {
            _memoryCache.TryGetValue("EmailCache", out string storedCode); // Tenta obter o e-mail do cache
            return Task.FromResult(storedCode); // Retorna o e-mail recuperado
        }

        // Método para recuperar o perfil do cache
        public Task<int> RecuperarPerfilCache()
        {
            _memoryCache.TryGetValue("PerfilCache", out int storedCode); // Tenta obter o perfil do cache
            return Task.FromResult(storedCode); // Retorna o perfil recuperado
        }

        // Método para gerar um código aleatório de 6 dígitos e armazená-lo em cache
        public Task<int> GerarCodigo()
        {
            Random rand = new Random();
            int codigo = rand.Next(100000, 999999); // Gera um código de 6 dígitos

            _memoryCache.Set("codigoCache", codigo.ToString(), TimeSpan.FromMinutes(10)); // Armazena o código em cache por 10 minutos

            return Task.FromResult(codigo); // Retorna o código gerado
        }

        // Método para validar se o código enviado coincide com o código armazenado em cache
        public Task<bool> ValidarCodigoEnviado(string codigo)
        {
            _memoryCache.TryGetValue("codigoCache", out string storedCode); // Tenta obter o código do cache

            // Compara as strings, não os códigos inteiros
            if (storedCode == codigo)
            {
                return Task.FromResult(true); // Retorna true se os códigos coincidirem
            }
            return Task.FromResult(false); // Retorna false se os códigos não coincidirem
        }
    }
}
