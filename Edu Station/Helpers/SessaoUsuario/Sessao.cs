using Edu_Station.Models;
using Newtonsoft.Json;

namespace Edu_Station.SessaoUsuario
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Task CriarSessaoDoUsuario(Pessoa usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuario", valor);

            return Task.CompletedTask;
        }

        public async Task<Pessoa> BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuario");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }
            return await Task.FromResult(JsonConvert.DeserializeObject<Pessoa>(sessaoUsuario));
        }

        public Task RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuario");
            return Task.CompletedTask;
        }
    }
}
