// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeSecurityInformationProtectionSensitivityLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "MeSecurityInformationProtectionSensitivityLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeSecurityInformationProtectionSensitivityLabelOperation(),
        new CreateMeSecurityInformationProtectionSensitivityLabelSecurityEvaluateApplicationOperation(),
        new CreateMeSecurityInformationProtectionSensitivityLabelSecurityEvaluateClassificationResultOperation(),
        new CreateMeSecurityInformationProtectionSensitivityLabelSecurityEvaluateRemovalOperation(),
        new CreateMeSecurityInformationProtectionSensitivityLabelSecurityExtractContentLabelOperation(),
        new DeleteMeSecurityInformationProtectionSensitivityLabelByIdOperation(),
        new GetMeSecurityInformationProtectionSensitivityLabelByIdOperation(),
        new GetMeSecurityInformationProtectionSensitivityLabelCountOperation(),
        new ListMeSecurityInformationProtectionSensitivityLabelsOperation(),
        new UpdateMeSecurityInformationProtectionSensitivityLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeSecurityInformationProtectionSensitivityLabelSecurityEvaluateApplicationRequestModel),
        typeof(CreateMeSecurityInformationProtectionSensitivityLabelSecurityEvaluateClassificationResultRequestModel),
        typeof(CreateMeSecurityInformationProtectionSensitivityLabelSecurityEvaluateRemovalRequestModel),
        typeof(CreateMeSecurityInformationProtectionSensitivityLabelSecurityExtractContentLabelRequestModel)
    };
}
