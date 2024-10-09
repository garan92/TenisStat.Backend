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


        /// <summary>
        /// Le constructeur recupère les données des joueurs sous forme d'objets
        /// </summary>
        public TenisStatRepository()
        {
            this.Players = new GetDataRepository().GetPlayersData();
        }

        /// <summary>
        /// classe les joueurs dans une liste selon leur classement
        /// </summary>
        /// <returns>liste de (classement,nom)</returns>
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
                        Id = player.Id,
                        Name = $"{player.Firstname} {player.Lastname}"
                    });
                }
            }

            return playersRankingNames;
        }

        /// <summary>
        /// fournit les informations du jeoueur selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">renvoie que l'id n'a pas été trouvé dans la liste </exception>
        public Player GetPlayerById(int id)
        {
            Player player = Players.FirstOrDefault(player => player.Id == id);
            return player == null ? throw new KeyNotFoundException($"Player with ID {id} not found.") : player;
        }


        /// <summary>
        /// Récupère les statistiques générales 
        /// </summary>
        /// <returns></returns>
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
