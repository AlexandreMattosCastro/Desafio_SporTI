using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioSporTI.Service
{
    public class DataService
    {
        public async Task<string> GetInfoData()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetAsync("http://tst.sportibrasil.com.br/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2");
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro: {e}");
                return "";
            }

        }
    }
}
