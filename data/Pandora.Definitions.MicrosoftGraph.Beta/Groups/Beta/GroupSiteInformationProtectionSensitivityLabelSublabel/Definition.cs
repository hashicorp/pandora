// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionSensitivityLabelSublabel;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteInformationProtectionSensitivityLabelSublabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelEvaluateOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelOperation(),
        new DeleteGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelByIdOperation(),
        new GetGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelCountOperation(),
        new ListGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelsOperation(),
        new UpdateGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdInformationProtectionSensitivityLabelByIdSublabelEvaluateRequestModel)
    };
}
