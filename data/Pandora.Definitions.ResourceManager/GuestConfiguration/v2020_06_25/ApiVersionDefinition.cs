using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-06-25";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new GuestConfigurationAssignmentHCRPReports.Definition(),
        new GuestConfigurationAssignmentReports.Definition(),
        new GuestConfigurationAssignments.Definition(),
        new GuestConfigurationConnectedVMwarevSphereAssignments.Definition(),
        new GuestConfigurationConnectedVMwarevSphereAssignmentsReports.Definition(),
        new GuestConfigurationHCRPAssignments.Definition(),
    };
}
