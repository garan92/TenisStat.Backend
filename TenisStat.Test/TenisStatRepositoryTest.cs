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


        /// <summary>
        /// création des objets 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {

            _tenisStatRepository = new TenisStatRepository();
            _statisticsRepository = new StatisticsRepository();
        }


        /// <summary>
        /// vérifie si le classement est correct
        /// </summary>
        [TestMethod]
        public void GetRank()
        {
            List<PlayerRanking> result = _tenisStatRepository.GetplayersRanking();
            Assert.AreEqual(5, result.Count, "Le nombre de joueurs dans le classement doit être de 5");
            Assert.AreEqual(1, result[0].Rank, "Le premier joueur doit être premier");
            Assert.AreEqual("Rafael Nadal", result[0].Name, "Le premier joueur doit être Rafael Nadal");
            Assert.AreEqual(2, result[1].Rank, "Le deuxième joueur doit être deuxième");
            Assert.AreEqual("Novak Djokovic", result[1].Name, "Le deuxième joueur doit être Novak Djokovic");
            Assert.AreEqual(10, result[2].Rank, "Le troisième joueur doit être trosième");
            Assert.AreEqual("Serena Williams", result[2].Name, "Le troisième joueur doit être Serena Williams");
        }



        /// <summary>
        /// vérifie que l'id 65 correspond bien a Stan Wawrinka
        /// </summary>
        [TestMethod]
        public void GetPlayerById65()
        {
            Player result = _tenisStatRepository.GetPlayerById(65);
            Assert.AreEqual("Stan", result.Firstname, "Le prénom du joueur doit être Stan");
            Assert.AreEqual("Wawrinka", result.Lastname, "Le nom du joueur doit être Wawrinka");
            Assert.AreEqual("SUI", result.Country.Code, "Son country code doit etre SUI");
            Assert.AreEqual(33, result.Data.Age, "Le joueur doit avoir 33 ans");
        }



        /// <summary>
        /// vérifie qu'on renvoie bien une erreur id non trouvé si on fournit un id qui n'est pas dans la liste des joueurs
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetPlayerByUnknownId()
        {
            var result = _tenisStatRepository.GetPlayerById(404);
        }


        /// <summary>
        /// vérifie que le pays avec le plus de victoire est bien les USA
        /// </summary>
        [TestMethod]
        public void GetBestCountry()
        {
            GlobalStatistics result = _tenisStatRepository.GetGlobalStatistics();
            Assert.AreEqual("USA", result.BestCountry, "Le meilleur pays doit être USA");
        }

        [TestMethod]
        public void GetAverageImc()
        {
            double result = _statisticsRepository.GetAverageImc();
            Assert.AreEqual(23.4, result, "L'IMC moyen doit être de 23.4");
        }
        [TestMethod]
        public void GetMedianHeight()
        {
            double result = _statisticsRepository.GetMedianHeight();
            Assert.AreEqual(185, result, 0.1, "La taille médiane doit être de 185");
        }
    }
}