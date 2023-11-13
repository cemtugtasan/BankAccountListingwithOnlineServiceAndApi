using BankAccountProject.Dtos.TokenDtos;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BankAccountProject.Presentation.ApiConnection
{
    public class TokenService
    {
        private readonly string _apiEndpoint = "https://efatura.etrsoft.com/fmi/data/v1/databases/testdb/sessions";
 
        public async Task<TokenResponse> GetTokenAsync()
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                // SSL sertifikası doğrulamasını devre dışı bırak
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{TokenRequest.Username}:{TokenRequest.Password}")));

                    HttpResponseMessage responseMessage;
                    try
                    {
                        responseMessage = await client.PostAsync($"{_apiEndpoint}", new StringContent("{}", Encoding.UTF8, "application/json"));
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var result = await responseMessage.Content.ReadFromJsonAsync<TokenResponse>();
                        
                        return result;
                    }

                    throw new HttpRequestException($"Failed to get token. Status code: {responseMessage.StatusCode}");
                }
            }
        }
    }
}
