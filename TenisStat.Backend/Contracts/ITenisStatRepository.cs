using TenisStat.Backend.Models;
using TenisStat.Backend.Models.Responses;

namespace TenisStat.Backend.Contracts
{
    public interface ITenisStatRepository
    {
        public List<PlayerRanking> GetplayersRanking();

        public Player GetPlayerById(int id);

        public GlobalStatistics GetGlobalStatistics();
    }
}
