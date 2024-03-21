namespace OSSApi.Models
{
    public class CompatibilityResponseModel
    {
        public CompatibilityResultE? CompatibilityResult { get; set; }
    }

    // This enum is defined similarly to the screenshot provided
    public enum CompatibilityResultE
    {
        /// <summary>
        /// Compatible license result
        /// </summary>
        Yes,
        
        /// <summary>
        /// Incompatible licenses
        /// </summary>
        No,
        
        /// <summary>
        /// Same licenses, thus compatible
        /// </summary>
        Same,
        
        /// <summary>
        /// We do not know ...
        /// </summary>
        Unknown
    }
}