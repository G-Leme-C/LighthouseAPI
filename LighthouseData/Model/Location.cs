namespace LighthouseData.Model
{
    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string AddressType { get; set; }
        public string Address { get; set; }
        public string AddressAproximateNumber { get; set; }
        public string Neighborhood { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string AdditionalLocationInfo { get; set; }
        public string ReferencePoints { get; set; }
    }
}