using System.Collections.Generic;
using System.Threading.Tasks;
using LighthouseData.ConfigurationModel;
using LighthouseData.Model;
using MongoDB.Driver;
using System.Linq;

namespace LighthouseData.Repository
{
    public class HelpReportRepository : IRepositoryBase<LighthouseHelpReport>
    {
        private readonly IMongoCollection<LighthouseHelpReport> _helpReports;

        public HelpReportRepository(ILighthouseDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _helpReports = database.GetCollection<LighthouseHelpReport>(settings.ReportCollectionName);
        }

        public async Task<LighthouseHelpReport> Create(LighthouseHelpReport obj)
        {
            await _helpReports.InsertOneAsync(obj);
            return obj;
        }

        public async Task<LighthouseHelpReport> Get(string id)
        {
            var helpReportFind = await _helpReports.FindAsync<LighthouseHelpReport>(
                helpReport => helpReport.ReportId == id
            );

            return await helpReportFind.FirstOrDefaultAsync();
        }

        public async Task<List<LighthouseHelpReport>> GetAll()
        {
            var helpReportFind = await _helpReports.FindAsync<LighthouseHelpReport>(
                helpReport => true
            );

            return await helpReportFind.ToListAsync();
        }
    }
}