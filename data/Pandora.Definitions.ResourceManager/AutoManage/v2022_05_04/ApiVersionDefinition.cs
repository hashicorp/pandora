using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AutoManage.v2022_05_04;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-05-04";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BestPractices.Definition(),
        new BestPracticesVersions.Definition(),
        new ConfigurationProfileAssignments.Definition(),
        new ConfigurationProfileHCIAssignments.Definition(),
        new ConfigurationProfileHCRPAssignments.Definition(),
        new ConfigurationProfiles.Definition(),
        new ConfigurationProfilesVersions.Definition(),
        new HCIReports.Definition(),
        new HCRPReports.Definition(),
        new Reports.Definition(),
        new ServicePrincipals.Definition(),
    };
}
