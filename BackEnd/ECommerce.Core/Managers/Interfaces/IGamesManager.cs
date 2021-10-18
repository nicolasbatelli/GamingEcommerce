using ECommerce.Core.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Core.Managers.Interfaces
{
    public interface IGamesManager
    {
        public Task<IEnumerable<IGame>> GetGamesAsync(string searchCondition);
    }
}
