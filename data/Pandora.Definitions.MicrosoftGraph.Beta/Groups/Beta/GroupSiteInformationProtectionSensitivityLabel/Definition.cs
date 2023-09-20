// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionSensitivityLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteInformationProtectionSensitivityLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdInformationProtectionSensitivityLabelEvaluateOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionSensitivityLabelOperation(),
        new DeleteGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionSensitivityLabelCountOperation(),
        new ListGroupByIdSiteByIdInformationProtectionSensitivityLabelsOperation(),
        new UpdateGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdInformationProtectionSensitivityLabelEvaluateRequestModel)
    };
}
