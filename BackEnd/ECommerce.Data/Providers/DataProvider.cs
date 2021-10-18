using ECommerce.Core.Data.Interfaces;
using ECommerce.Data.Constants;
using ECommerce.Core.Entities;
using ECommerce.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ECommerce.Core.Entities.FilterEntities;
using ECommerce.Core.Constants;

namespace ECommerce.Data.Providers
{
    public class DataProvider : IDataProvider
    {
        private string _path = Directory.GetCurrentDirectory() + "/Files/deals.json";

        public async Task<IEnumerable<IGame>> GetGamesAsync(FilterModel condition)
        {
            var _gamesDeals = await ReadGamesDealsFromFile();

            return filterGames(_gamesDeals, condition);
        }

        private List<Game> filterGames(IEnumerable<IGame> _games, FilterModel condition)
        {
            var filteredGames = new List<Game>((List<Game>)_games);

            if (condition.MinPriceFilter.filterCriteria == FilterConstants.LESS_THAN)
                filteredGames = filteredGames.Where(game => game.SalePrice > float.Parse(condition.MinPriceFilter.amount)).ToList();

            if (condition.MaxPriceFilter.filterCriteria == FilterConstants.GRATER_THAN)
                filteredGames = filteredGames.Where(game => game.SalePrice < float.Parse(condition.MaxPriceFilter.amount)).ToList();

            if(condition.TitleFilter.FilterCase == FilterConstants.CONTAINS)
                filteredGames = filteredGames.Where(game => game.Title.Contains(condition.TitleFilter.SearchValue, StringComparison.OrdinalIgnoreCase)).ToList();

            if (condition.TitleFilter.FilterCase == FilterConstants.EQUALS)
                filteredGames = filteredGames.Where(game => game.Title == condition.TitleFilter.SearchValue.Trim()).ToList();

            return filteredGames;
        }
        private async Task<IEnumerable<IGame>> ReadGamesDealsFromFile()
        {
            using (FileStream fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read))
            using (StreamReader r = new StreamReader(fileStream))
            {
                string json = await r.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Game>>(json);
            }
        }
    }
}
