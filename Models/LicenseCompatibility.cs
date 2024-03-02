using System.ComponentModel.DataAnnotations;

namespace OSSApi.Models
{
    public class LicenseCompatibility
    {
        public int Id { get; set; }
        public string License1 { get; set; }

        public string License2 { get; set; }
        
        public string Compatibility { get; set; }
    }
}
