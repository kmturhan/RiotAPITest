using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiotApiTest.Models
{
    public class Root
    {
        public UserInformation UI { get; set; }
        public UserMatches.GeneralMatchesInfo UM { get; set; }
        public UserMatches.Match UMDetail { get; set; }
        public class UserInformation
        {
            public string id { get; set; }//SummonerID 
            public string accountId { get; set; }//Match tarafında kullanılacak olan parametre.
            public string puuid { get; set; }
            public string name { get; set; }
            public int profileIconId { get; set; }
            public long revisionDate { get; set; }
            public int summonerLevel { get; set; }
        }
        public class UserMatches
        {
            public class Match
            {
                public string lane { get; set; }
                public int gameId { get; set; }
                public int champion { get; set; }
                public string platformId { get; set; }
                public object timestamp { get; set; }
                public int queue { get; set; }
                public string role { get; set; }
                public int season { get; set; }
                public string ChampionName { get; set; }
            }
            public class GeneralMatchesInfo
            {
                public IList<Match> matches { get; set; }
                public int endIndex { get; set; }
                public int startIndex { get; set; }
                public int totalGames { get; set; }
            }
        }
    }
}