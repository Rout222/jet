using XF_JetAPI.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.ObjectModel;

namespace XF_JetAPI.Services
{
    public class DataService
    {
        public HttpClient client = new HttpClient();
        public DataService(){
        }
        public async Task<ObservableCollection<Produto>> GetProdutosAsync()
        {
            var response = await client.GetStringAsync("https://192.168.0.104:44326/api/");
            var produtos = JsonConvert.DeserializeObject<ObservableCollection<Produto>> (response);
            return produtos;
        }
        /// <summary>
        /// Adiciona um item de produto
        /// </summary>
        /// <param name="p">Item a adicionar.</param>
        public async Task<int> AddProdutoAsync(Produto p)
        {
            var data = JsonConvert.SerializeObject(p);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://192.168.0.104:44326/api/", content);
            var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
            return result;
        }
        /// <summary>
        /// Atualiza um item
        /// </summary>
        /// <param name="id"> do Item.</param>
        /// <param name="p">Item a atualizar.</param>
        public async Task<int> UpdateProdutoAsync(int id, Produto p)
        {
            var data = JsonConvert.SerializeObject(p);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(string.Concat("https://192.168.0.104:44326/api/",
 id), content);
            return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
