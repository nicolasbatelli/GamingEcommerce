using ECommerce.Core.Entities.FilterEntities;
using ECommerce.Core.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Core.Data.Interfaces
{
    public interface IDataProvider
    {
        public Task<IEnumerable<IGame>> GetGamesAsync(FilterModel filterModel);
    }
}

