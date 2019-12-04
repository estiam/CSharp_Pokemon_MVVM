using Newtonsoft.Json;
using PokemonMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.DAL
{
    public static class PokemonAPIDAL
    {
        const string POKEMON_API_URL = "https://pokeapi.co/api/v2/pokemon/?limit=151";
        public static async Task<List<Pokemon>> LoadPokemonsAsync()
        {

            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(POKEMON_API_URL));
            string json = Encoding.UTF8.GetString(data);
            PokemonData result = JsonConvert.DeserializeObject<PokemonData>(json);

            return result.Results;
        }

        public async static Task<Pokemon> LoadPokemonAsync(string pokeUrl)
        {
            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(pokeUrl));
            string json = Encoding.UTF8.GetString(data);
            Pokemon result = JsonConvert.DeserializeObject<Pokemon>(json);

            return result;
        }
    }
}
