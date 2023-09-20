// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionDataLossPreventionPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteInformationProtectionDataLossPreventionPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyEvaluateOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyOperation(),
        new DeleteGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyCountOperation(),
        new ListGroupByIdSiteByIdInformationProtectionDataLossPreventionPoliciesOperation(),
        new UpdateGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyEvaluateRequestModel)
    };
}
