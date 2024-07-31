using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TronScan.Models;
using TronScan.Options;

namespace TronScan
{
    public class TronScan : ITronScan
    {
        public TronScan(
            HttpClient httpClient,
            IOptions<TronScanApiOptions> apiOptions) 
        {
            _httpClient = httpClient;
            _apiOptions = apiOptions.Value;
        }

        public async Task<TransactionData> GetTransactionDetails(string transactionHash)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiOptions.TransactionInfo}hash={transactionHash}");
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TransactionData>(jsonContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private readonly HttpClient _httpClient;
        private readonly TronScanApiOptions _apiOptions;
    }
}
