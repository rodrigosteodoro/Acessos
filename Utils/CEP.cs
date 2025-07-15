using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Acessos
{
    internal class CEP
    {
        #region Métodos de API - CEP

       internal  async Task<EnderecoInfo> BuscarEnderecoPorCEP(string cep)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(10);

                    var url = $"https://viacep.com.br/ws/{cep}/json/";
                    var response = await httpClient.GetStringAsync(url);

                    var enderecoInfo = JsonConvert.DeserializeObject<EnderecoInfo>(response);

                    if (enderecoInfo != null && !enderecoInfo.Erro)
                    {
                        return enderecoInfo;
                    }

                    return null;
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Erro de conexão ao buscar CEP. Verifique sua conexão com a internet.",
                    "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Tempo limite excedido ao buscar CEP. Tente novamente.",
                    "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado ao buscar CEP: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion
    }
    internal class EnderecoInfo
    {
        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("regiao")]
        public string Regiao { get; set; }

        [JsonProperty("ibge")]
        public string IBGE { get; set; }

        [JsonProperty("gia")]
        public string GIA { get; set; }

        [JsonProperty("ddd")]
        public string DDD { get; set; }

        [JsonProperty("siafi")]
        public string SIAFI { get; set; }

        [JsonProperty("erro")]
        public bool Erro { get; set; }
    }
}
