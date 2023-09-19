// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionPolicyLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteInformationProtectionPolicyLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdInformationProtectionPolicyLabelEvaluateApplicationOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionPolicyLabelEvaluateClassificationResultOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionPolicyLabelEvaluateRemovalOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionPolicyLabelExtractLabelOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionPolicyLabelOperation(),
        new DeleteGroupByIdSiteByIdInformationProtectionPolicyLabelByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionPolicyLabelByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionPolicyLabelCountOperation(),
        new ListGroupByIdSiteByIdInformationProtectionPolicyLabelsOperation(),
        new UpdateGroupByIdSiteByIdInformationProtectionPolicyLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdInformationProtectionPolicyLabelEvaluateApplicationRequestModel),
        typeof(CreateGroupByIdSiteByIdInformationProtectionPolicyLabelEvaluateClassificationResultRequestModel),
        typeof(CreateGroupByIdSiteByIdInformationProtectionPolicyLabelEvaluateRemovalRequestModel),
        typeof(CreateGroupByIdSiteByIdInformationProtectionPolicyLabelExtractLabelRequestModel)
    };
}
