using ECommerce.Core.Entities.Interfaces;
using Newtonsoft.Json;

namespace ECommerce.Core.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Game : IGame
    {
        [JsonProperty]
        public string InternalName { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public string MetacriticLink { get; set; }
        [JsonProperty]
        public string DealID { get; set; }
        [JsonProperty]
        public int StoreID { get; set; }
        [JsonProperty]
        public int GameID { get; set; }
        [JsonProperty]
        public float SalePrice { get; set; }
        [JsonProperty]
        public float NormalPrice { get; set; }
        [JsonProperty]
        public float Savings { get; set; }
        [JsonProperty]
        public int MetacriticScore { get; set; }
        [JsonProperty]
        public string SteamRatingText { get; set; }
        [JsonProperty]
        public int SteamRatingPercent { get; set; }
        [JsonProperty]
        public int SteamRatingCount { get; set; }
        [JsonProperty]
        public string SteamAppID { get; set; }
        [JsonProperty]
        public int ReleaseDate { get; set; }
        [JsonProperty]
        public int LastChange { get; set; }
        [JsonProperty]
        public float DealRating { get; set; }
        [JsonProperty]
        public string Thumb { get; set; }
    }
}
