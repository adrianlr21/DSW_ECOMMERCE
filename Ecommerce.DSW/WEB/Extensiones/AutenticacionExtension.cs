using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WEB.DTO;

namespace WEB.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _sinInf = new ClaimsPrincipal(new ClaimsIdentity());


        public AutenticacionExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }


        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUser)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesionUser != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUser.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUser.NombreCompleto),
                    new Claim(ClaimTypes.Email, sesionUser.Correo),
                    new Claim(ClaimTypes.Role, sesionUser.Rol)

                }, "JwtAuth"));

                await _localStorageService.SetItemAsync("sesionUser", sesionUser);

            }
            else
            {
                claimsPrincipal = _sinInf;
                await _localStorageService.RemoveItemAsync("sesionUser");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorageService.GetItemAsync<SesionDTO>("sesionUser");

            if (sesionUsuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_sinInf));
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol)

                }, "JwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }
    }
}
