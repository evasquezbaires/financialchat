using Blazored.LocalStorage;
using FinancialChat.App.Constants;
using FinancialChat.App.Contracts;
using FinancialChat.App.Models;
using FinancialChat.App.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.App.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IConfiguration _configuration;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _configuration = configuration;
        }

        public async Task<int> Register(RegisterModel registerModel)
        {
            var json = JsonConvert.SerializeObject(registerModel);
            var uri = string.Concat(_configuration["FinancialChat.API:AuthEndpoint"], ChatMessage.PATH_REGISTER);
            var response = await _httpClient.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

            return (int)result["data"]["userId"];
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var json = JsonConvert.SerializeObject(loginModel);
            var uri = string.Concat(_configuration["FinancialChat.API:AuthEndpoint"], ChatMessage.PATH_LOGIN);
            var response = await _httpClient.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

            if (string.IsNullOrEmpty((string)result["data"]["username"]))
            {
                return string.Empty;
            }

            var token = (string)result["data"]["token"];
            await _localStorage.SetItemAsync(ChatMessage.AUTH_KEY, token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Name);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ChatMessage.AUTH_HEADER, token);

            return token;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(ChatMessage.AUTH_KEY);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
