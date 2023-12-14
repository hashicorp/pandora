// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionSensitivityLabelSublabel;

internal class Definition : ResourceDefinition
{
    public string Name => "MeInformationProtectionSensitivityLabelSublabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeInformationProtectionSensitivityLabelByIdSublabelEvaluateOperation(),
        new CreateMeInformationProtectionSensitivityLabelByIdSublabelOperation(),
        new DeleteMeInformationProtectionSensitivityLabelByIdSublabelByIdOperation(),
        new GetMeInformationProtectionSensitivityLabelByIdSublabelByIdOperation(),
        new GetMeInformationProtectionSensitivityLabelByIdSublabelCountOperation(),
        new ListMeInformationProtectionSensitivityLabelByIdSublabelsOperation(),
        new UpdateMeInformationProtectionSensitivityLabelByIdSublabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeInformationProtectionSensitivityLabelByIdSublabelEvaluateRequestModel)
    };
}
