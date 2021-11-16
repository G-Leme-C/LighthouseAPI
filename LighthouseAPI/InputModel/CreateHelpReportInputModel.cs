using LighthouseData.Model;

namespace LighthouseAPI.InputModel
{
    public class CreateHelpReportInputModel
    {
        public UserReporter UserReporter { get; set; }
        public Location Location { get; set; }

        public int NumberOfPeople { get; set; }
        public YesNoAnswerType IsThereChildren { get; set; }
        public YesNoAnswerType IsThereWomen { get; set; }

        public YesNoAnswerType IsThereVisibleShelter { get; set; }
        public YesNoAnswerType IsThereThermalProtectionFromCold { get; set; }
        public YesNoAnswerType IsThereThermalProtectionFromHeat { get; set; }

        public bool IsThereNeedForMedicalCare { get; set; }
        public string MedicalCareNeedsDescription { get; set; }
        public YesNoAnswerType IsThereNeedForFood { get; set; }
        public UrgencyLevel UrgencyLevel { get; set; }
    }
}