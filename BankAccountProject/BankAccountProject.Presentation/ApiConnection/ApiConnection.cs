using System.Text;
using BankAccountProject.Dtos;
using BankAccountProject.Presentation.ApiConnection.ApiInterface;
using Newtonsoft.Json;

namespace BankAccountProject.Presentation.ApiConnection
{
    public class ApiConnection :IApiConnection
    {

        private readonly string _apiEndpoint = "https://efatura.etrsoft.com/fmi/data/v1/databases/testdb/layouts/testdb/records/1";
 
        public async Task<List<BankAccountDto>> GetBankAccounts()
        {
            TokenService tokenService = new TokenService();
            var token = await tokenService.GetTokenAsync();
            
            if (string.IsNullOrEmpty(token.Response.Token))
            {
                throw new Exception(message: "Token was not Found!");
            }

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                // SSL sertifikası doğrulamasını devre dışı bırak
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Response.Token);

                    var requestData = new
                    {
                        fieldData = new { },
                        script = "getData"
                    };

                    var response = await client.PatchAsync($"{_apiEndpoint}", new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                        return JsonConvert.DeserializeObject <List<BankAccountDto>>(result?.Response?.ScriptResult);
                    }

                    throw new HttpRequestException($"Failed to get data. Status code: {response.StatusCode}");
                }
            }

        }
    }
}
