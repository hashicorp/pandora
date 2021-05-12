namespace Pandora.Definitions
{
    public class EnvironmentInfo
    {
        public EnvironmentInfo(AvailabilityInformation status)
        {
            Status = status;
        }

        public AvailabilityInformation Status { get; private set; }
    }
}