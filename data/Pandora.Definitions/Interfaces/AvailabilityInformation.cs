namespace Pandora.Definitions
{
    public class AvailabilityInformation
    {
        public bool Generate { get; protected set; }
        
        public EnvironmentInfo Default { get; set; }
        
        public EnvironmentInfo? China { get; set; }
        public EnvironmentInfo? Germany { get; set; }
        public EnvironmentInfo? Public { get; set; }
        public EnvironmentInfo? USGovernment { get; set; }
    }
}