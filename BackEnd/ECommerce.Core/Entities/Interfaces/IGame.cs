using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Entities.Interfaces
{
    public interface IGame
    {
        public string internalName { get; set; }
        public string title { get; set; }
        public string metacriticLink { get; set; }
        public string dealID { get; set; }
        public int storeID { get; set; }
        public int gameID { get; set; }
        public float salePrice { get; set; }
        public float normalPrice { get; set; }
        public float savings { get; set; }
        public int metacriticScore { get; set; }
        public string steamRatingText { get; set; }
        public int steamRatingPercent { get; set; }
        public int steamRatingCount { get; set; }
        public string steamAppID { get; set; }
        public int releaseDate { get; set; }
        public int lastChange { get; set; }
        public float dealRating { get; set; }
        public string thumb { get; set; }
    }
}
