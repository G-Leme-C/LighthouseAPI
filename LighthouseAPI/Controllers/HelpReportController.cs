using System.Threading.Tasks;
using LighthouseData.Model;
using LighthouseData.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LighthouseAPI
{

    [ApiController]
    [Route("[controller]")]
    public class HelpReportController : ControllerBase
    {

        private readonly HelpReportRepository _reportRepository;

        public HelpReportController(HelpReportRepository reportRepository)
        {
            this._reportRepository = reportRepository;

        }


        [HttpPost]
        public async Task<IActionResult> CreateHelpReport(LighthouseHelpReport helpReport) {
            
            await _reportRepository.Create(helpReport);

            return Ok();

        }
    }
}