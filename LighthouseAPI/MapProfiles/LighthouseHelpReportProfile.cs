using LighthouseData.Model;
using AutoMapper;
using LighthouseAPI.InputModel;

namespace LighthouseAPI.MapProfiles
{
    public class LighthouseHelpReportProfile : Profile
    {
        public LighthouseHelpReportProfile()
        {
            CreateMap<CreateHelpReportInputModel, LighthouseHelpReport>();
        }
    }
}