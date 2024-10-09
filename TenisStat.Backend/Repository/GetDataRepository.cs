using System.Text.Json;
using TenisStat.Backend.Models;

namespace TenisStat.Backend.Repository
{
    public class GetDataRepository
    {
        /// <summary>
        /// Cette méthode convertir le fichier de données en une liste d'objet. Un objet correspond aux données d'un joueur 
        /// </summary>
        /// <returns>liste de joueurs</returns>
        /// <exception cref="FileNotFoundException">si le fichier n'est pas trouvé</exception>
        public List<Player> GetPlayersData()
        {
            string baseDirectory = AppContext.BaseDirectory;

            string jsonFilePath = Path.Combine(baseDirectory, "Resources", "headtohead.json");

            List<Player> players = new List<Player>();

            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);

                PlayerList? playersList = JsonSerializer.Deserialize<PlayerList>(jsonString);

                players = playersList.Players;
            }
            else
            {
                throw new FileNotFoundException("Le fichier JSON spécifié est introuvable.");
            }
            return players;
        }
    }
}
