using TenisStat.Backend.Models;
using TenisStat.Backend.Models.Responses;

namespace TenisStat.Backend.Contracts
{
    public interface ITenisStatRepository
    {
        //public void TenisStatRepository();
        //public void GetplayersRanking();
        public List<PlayerRanking> GetplayersRanking();

        public Player GetPlayerById(int id);

        public GlobalStatistics GetGlobalStatistics();


    }
}
