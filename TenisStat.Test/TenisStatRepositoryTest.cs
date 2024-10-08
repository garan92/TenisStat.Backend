using System.Runtime.CompilerServices;
using TenisStat.Backend.Contracts;
using TenisStat.Backend.Models;
using TenisStat.Backend.Models.Responses;
using TenisStat.Backend.Repository;

namespace TenisStat.Test
{
    [TestClass]
    public class TenisStatRepositoryTest
    {
        private ITenisStatRepository _tenisStatRepository;
        private IStatisticsRepository _statisticsRepository;

        [TestInitialize]
        public void TestInitialize()
        {

            _tenisStatRepository = new TenisStatRepository();
            _statisticsRepository = new StatisticsRepository();
        }

        [TestMethod]
        public void GetRank()
        {
            List<PlayerRanking> result = _tenisStatRepository.GetplayersRanking();
            Assert.AreEqual(5, result.Count, "Le nombre de joueurs dans le classement doit �tre de 5");
            Assert.AreEqual(1, result[0].Rank, "Le premier joueur doit �tre premier");
            Assert.AreEqual("Rafael Nadal", result[0].Name, "Le premier joueur doit �tre Rafael Nadal");
            Assert.AreEqual(2, result[1].Rank, "Le deuxi�me joueur doit �tre deuxi�me");
            Assert.AreEqual("Novak Djokovic", result[1].Name, "Le deuxi�me joueur doit �tre Novak Djokovic");
            Assert.AreEqual(10, result[2].Rank, "Le troisi�me joueur doit �tre trosi�me");
            Assert.AreEqual("Serena Williams", result[2].Name, "Le troisi�me joueur doit �tre Serena Williams");
        }

        [TestMethod]
        public void GetPlayerById()
        {
            Player result = _tenisStatRepository.GetPlayerById(65);
            Assert.AreEqual("Stan", result.Firstname, "Le pr�nom du joueur doit �tre Stan");
            Assert.AreEqual("Wawrinka", result.Lastname, "Le nom du joueur doit �tre Wawrinka");
            Assert.AreEqual("SUI", result.Country.Code, "Son country code doit etre SUI");
            Assert.AreEqual(33, result.Data.Age, "Le joueur doit avoir 33 ans");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetPlayerByUnknownId()
        {
            var result = _tenisStatRepository.GetPlayerById(404);
        }

        [TestMethod]
        public void GetBestCountry()
        {
            GlobalStatistics result = _tenisStatRepository.GetGlobalStatistics();
            Assert.AreEqual("USA", result.BestCountry, "Le meilleur pays doit �tre USA");
        }

        [TestMethod]
        public void GetAverageImc()
        {
            double result = _statisticsRepository.GetAverageImc();
            Assert.AreEqual(23.4, result, "L'IMC moyen doit �tre de 23.4");
        }
        [TestMethod]
        public void GetMedianHeight()
        {
            double result = _statisticsRepository.GetMedianHeight();
            Assert.AreEqual(185, result, 0.1, "La taille m�diane doit �tre de 185");
        }
    }
}