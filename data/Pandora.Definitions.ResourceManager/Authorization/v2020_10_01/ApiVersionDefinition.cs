using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new EligibleChildResources.Definition(),
        new RoleAssignmentScheduleInstances.Definition(),
        new RoleAssignmentScheduleRequests.Definition(),
        new RoleAssignmentSchedules.Definition(),
        new RoleEligibilityScheduleInstances.Definition(),
        new RoleEligibilityScheduleRequests.Definition(),
        new RoleEligibilitySchedules.Definition(),
        new RoleManagementPolicies.Definition(),
        new RoleManagementPolicyAssignments.Definition(),
    };
}
