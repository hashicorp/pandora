using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01
{
    public class Resources : ApiVersionDefinition
    {
        public string ApiVersion => "2018-05-01";
        public bool Generate => true;
        public AvailabilityInfo AvailabilityInfo => new AvailabilityInfo
        {
            Generate = true,
        };
       
        public bool Preview => false;
        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new ResourceGroup.Definition()
        };
    }

    public class AvailabilityInfo
    {
        public bool Generate { get; set; }
        public EnvironmentInfo Default { get; set; }
        
        public EnvironmentInfo? China { get; set; }
        public EnvironmentInfo? Germany { get; set; }
        public EnvironmentInfo? Public { get; set; }
        public EnvironmentInfo? USGovernment { get; set; }
    }
}