using ECommerce.Core.Entities.Interfaces;
using Newtonsoft.Json;

namespace ECommerce.Core.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Game : IGame
    {
        [JsonProperty]
        public string internalName { get; set; }
        [JsonProperty]
        public string title { get; set; }
        [JsonProperty]
        public string metacriticLink { get; set; }
        [JsonProperty]
        public string dealID { get; set; }
        [JsonProperty]
        public int storeID { get; set; }
        [JsonProperty]
        public int gameID { get; set; }
        [JsonProperty]
        public float salePrice { get; set; }
        [JsonProperty]
        public float normalPrice { get; set; }
        [JsonProperty]
        public float savings { get; set; }
        [JsonProperty]
        public int metacriticScore { get; set; }
        [JsonProperty]
        public string steamRatingText { get; set; }
        [JsonProperty]
        public int steamRatingPercent { get; set; }
        [JsonProperty]
        public int steamRatingCount { get; set; }
        [JsonProperty]
        public string steamAppID { get; set; }
        [JsonProperty]
        public int releaseDate { get; set; }
        [JsonProperty]
        public int lastChange { get; set; }
        [JsonProperty]
        public float dealRating { get; set; }
        [JsonProperty]
        public string thumb { get; set; }
    }
}
