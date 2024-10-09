namespace TenisStat.Backend.Contracts
{
    public interface IStatisticsRepository
    {
        public string GetBestCountry();

        public double GetAverageImc();

        public double GetMedianHeight();
    }
}
