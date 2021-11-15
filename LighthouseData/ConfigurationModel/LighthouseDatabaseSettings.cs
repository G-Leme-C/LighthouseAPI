namespace LighthouseData.ConfigurationModel
{
    public class LighthouseDatabaseSettings : ILighthouseDatabaseSettings
    {
        public string ReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface ILighthouseDatabaseSettings
    {
        string ReportCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}