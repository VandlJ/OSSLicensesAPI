namespace OSSApi.Models
{
    public class CompatibilityResponseModel
    {
        public CompatibilityResultE? CompatibilityResult { get; set; }
    }

    public class CompatibilityResultE
    {
        public bool Yes { get; set; }
        public bool No { get; set; }
        public bool Same { get; set; }
        public bool Unknown { get; set; }
    }
}