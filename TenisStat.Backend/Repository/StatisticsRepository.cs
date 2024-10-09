using TenisStat.Backend.Contracts;
using TenisStat.Backend.Models;

namespace TenisStat.Backend.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private List<Player> Players { get; set; }

        /// <summary>
        /// Le constructeur recupère les données des joueurs sous forme d'objets
        /// </summary>
        public StatisticsRepository() 
        {
            this.Players = new GetDataRepository().GetPlayersData();
        }

        /// <summary>
        /// Fait la somme des points des joueurs par pays d'origine
        /// </summary>
        /// <returns>Le pays avec le plus de points</returns>
        public string GetBestCountry()
        {
            Dictionary<string, int> pointsByCountries = new Dictionary<string, int>();

            foreach(var player in this.Players) {
                if (pointsByCountries.ContainsKey(player.Country.Code))
                {
                    pointsByCountries[player.Country.Code] += player.Data.Points;
                }
                else
                {
                    pointsByCountries[player.Country.Code] = player.Data.Points;
                }
            }
            var bestCountry = pointsByCountries.OrderByDescending(cp => cp.Value).FirstOrDefault();
            return bestCountry.Key;
        }


        /// <summary>
        /// Réalise la moyenne des IMC des joueurs
        /// </summary>
        /// <returns></returns>
        public double GetAverageImc()
        {
            double totalImc = 0;
            double WeightKg = 0;
            double HeightM = 0;
            foreach (var player in this.Players)
            {
                WeightKg = player.Data.Weight / 1000.0;
                HeightM = player.Data.Height / 100.0;
                totalImc += WeightKg / (HeightM * HeightM); // IMC = poids(kg)/taille²(m)
            }

            return Math.Round(totalImc / this.Players.Count, 1);

        }



        /// <summary>
        /// Calcul la médiane des tailles des joueurs, le calcul dépend nu nombre de joueurs (pair ou impair)
        /// </summary>
        /// <returns></returns>
        public double GetMedianHeight()
        {
            double median;

            List<int> heightList = Players.Select(player => player.Data.Height).ToList();
            heightList.Sort();
            int count = heightList.Count;

            if (count % 2 == 0) // si la somme est paire 
            {
                
                median = (heightList[count / 2 - 1] + heightList[count / 2]) / 2.0;
            }
            else // si la somme est impaire
            {
                
                median = heightList[count / 2];
            }

            return median;
        }
    }
}
