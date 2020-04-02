using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidCharts
{
    internal static class CsvStreamUtility
    {
        internal static async Task<Stream> GetCsvStream(string url)
        {
            HttpClient client = new HttpClient();
            var andamentoNazionaleResponse = await client.GetAsync(url);
            return await andamentoNazionaleResponse.Content.ReadAsStreamAsync();
        }
    }
}
