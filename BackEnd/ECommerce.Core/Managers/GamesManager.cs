using ECommerce.Core.Constants;
using ECommerce.Core.Data.Interfaces;
using ECommerce.Core.Entities.FilterEntities;
using ECommerce.Core.Entities.Interfaces;
using ECommerce.Core.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Core.Managers
{
    public class GamesManager : IGamesManager
    {
        private readonly IDataProvider _dataProvider;

        public GamesManager(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public async Task<IEnumerable<IGame>> GetGamesAsync(string searchCondition)
        {
            TitleFilter titleFilter = new TitleFilter()
            {
                FilterCase = FilterConstants.NOT_FILTERING
            };
            PriceFilter minPriceFilter = new PriceFilter()
            {
                filterCriteria = FilterConstants.NOT_FILTERING
            };
            PriceFilter maxPriceFilter = new PriceFilter()
            {
                filterCriteria = FilterConstants.NOT_FILTERING
            };

            if (string.IsNullOrEmpty(searchCondition))
            {
                titleFilter.FilterCase = FilterConstants.NOT_FILTERING;
            }
            else
            {
                var conditions = searchCondition.Split(',');

                if(!conditions[0].Contains("salePrice", System.StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(conditions[0]))
                {
                    titleFilter.FilterCase = conditions[0].Contains('=') ? FilterConstants.EQUALS : FilterConstants.CONTAINS; // busco que contenga coincidencia exacta, sino es parcial 
                    titleFilter.SearchValue = conditions[0].Contains('=') ? conditions[0].Split('=')[1] : (conditions[0].Contains(':') ? conditions[0].Split(':')[1].Trim() : conditions[0].Trim());  // obtengo el texto a buscar
                }

                foreach (var condition in conditions)
                {
                    if (condition.Contains('<'))
                    {
                        minPriceFilter.filterCriteria = FilterConstants.LESS_THAN;
                        minPriceFilter.amount = condition.Split('<')[1];
                    }
                    else if (condition.Contains('>'))
                    {
                        maxPriceFilter.filterCriteria = FilterConstants.GRATER_THAN;
                        maxPriceFilter.amount = condition.Split('>')[1];
                    }
                }
            }

            var filterModel = new FilterModel()
            {
                TitleFilter = titleFilter,
                MinPriceFilter = minPriceFilter,
                MaxPriceFilter = maxPriceFilter
            };

            return await _dataProvider.GetGamesAsync(filterModel);
        }
    }
}
