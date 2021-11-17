using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LighthouseAPI.InputModel;
using LighthouseData.Model;
using LighthouseData.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LighthouseAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HelpReportController : ControllerBase
    {
        private readonly HelpReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public HelpReportController(HelpReportRepository reportRepository,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._reportRepository = reportRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateHelpReport(CreateHelpReportInputModel helpReportCreationModel)
        {
            var helpReport = _mapper.Map<CreateHelpReportInputModel, LighthouseHelpReport>(helpReportCreationModel);

            var createdHelpReport = await _reportRepository.Create(helpReport);

            return CreatedAtAction(nameof(GetReportById), new { id = createdHelpReport.ReportId }, createdHelpReport);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReports() {
            var reports = await _reportRepository.GetAll();

            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReportById(string id) {
            if(string.IsNullOrEmpty(id)) 
                return BadRequest();

            var helpReportById = await _reportRepository.Get(id);

            if(helpReportById == null) {
                return NotFound();
            }

            return Ok(helpReportById);
        }
    }
}