using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Entities.Interfaces
{
    public interface IGame
    {
        public string InternalName { get; set; }
        public string Title { get; set; }
        public string MetacriticLink { get; set; }
        public string DealID { get; set; }
        public int StoreID { get; set; }
        public int GameID { get; set; }
        public float SalePrice { get; set; }
        public float NormalPrice { get; set; }
        public float Savings { get; set; }
        public int MetacriticScore { get; set; }
        public string SteamRatingText { get; set; }
        public int SteamRatingPercent { get; set; }
        public int SteamRatingCount { get; set; }
        public string SteamAppID { get; set; }
        public int ReleaseDate { get; set; }
        public int LastChange { get; set; }
        public float DealRating { get; set; }
        public string Thumb { get; set; }
    }
}
