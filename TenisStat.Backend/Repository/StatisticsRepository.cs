using TenisStat.Backend.Contracts;
using TenisStat.Backend.Models;

namespace TenisStat.Backend.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private List<Player> Players { get; set; }

        public StatisticsRepository() 
        {
            this.Players = new GetDataRepository().GetPlayersData();
        }


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

        public double GetAverageImc()
        {
            double totalImc = 0;
            double WeightKg = 0;
            double HeightM = 0;
            foreach (var player in this.Players)
            {
                WeightKg = player.Data.Weight / 1000.0;
                HeightM = player.Data.Height / 100.0;
                totalImc += WeightKg / (HeightM * HeightM);
            }

            return Math.Round(totalImc / this.Players.Count, 1);

        }

        public double GetMedianHeight()
        {
            double median;

            List<int> heightList = Players.Select(player => player.Data.Height).ToList();
            heightList.Sort();
            int count = heightList.Count;

            if (count % 2 == 0) // if players are inpair
            {
                
                median = (heightList[count / 2 - 1] + heightList[count / 2]) / 2.0;
            }
            else // if players are pair
            {
                
                median = heightList[count / 2];
            }

            return median;
        }
    }
}
