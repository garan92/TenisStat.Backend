using System.Text.Json;
using TenisStat.Backend.Contracts;
using TenisStat.Backend.Models;
using System.Linq;
using TenisStat.Backend.Models.Responses;

namespace TenisStat.Backend.Repository
{
    public class TenisStatRepository : ITenisStatRepository
    {
        
        public List<Player> Players { get; set;}

        public TenisStatRepository()
        {
            this.Players = new GetDataRepository().GetPlayersData();
        }


        public List<PlayerRanking> GetplayersRanking()
        {
            List<PlayerRanking> playersRankingNames = new List<PlayerRanking>();

            if (Players != null)
            {
                List<Player> playersRanking = Players.OrderBy(player => player.Data.Rank).ToList();
                foreach (Player player in playersRanking)
                {
                    playersRankingNames.Add(new PlayerRanking
                    {
                        Rank = player.Data.Rank,
                        Name = $"{player.Firstname} {player.Lastname}"
                    });
                }
            }

            return playersRankingNames;
        }

        public Player GetPlayerById(int id)
        {
            Player player = Players.FirstOrDefault(player => player.Id == id);
            return player == null ? throw new KeyNotFoundException($"Player with ID {id} not found.") : player;
        }

        public GlobalStatistics GetGlobalStatistics()
        {
            GlobalStatistics globalStatistics = new GlobalStatistics();
            StatisticsRepository statisticsRepository = new StatisticsRepository();
            globalStatistics.BestCountry = statisticsRepository.GetBestCountry();
            globalStatistics.AverageImc = statisticsRepository.GetAverageImc();
            globalStatistics.medianHeight = statisticsRepository.GetMedianHeight();

            return globalStatistics;
        }
    }
}
