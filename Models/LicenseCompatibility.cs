namespace OSSApi.Models
{
    // Represents the compatibility between two licenses
    public class LicenseCompatibility
    {
        // Represents the unique identifier for the compatibility record
        public int Id { get; set; }
        
        // Represents the name of the first license
        public string? License1 { get; set; }
        
        // Represents the name of the second license
        public string? License2 { get; set; }
        
        // Represents the compatibility status between the two licenses
        public string? Compatibility { get; set; }
    }
}