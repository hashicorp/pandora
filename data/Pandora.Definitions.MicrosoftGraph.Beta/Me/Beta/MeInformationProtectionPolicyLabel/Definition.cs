// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionPolicyLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "MeInformationProtectionPolicyLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeInformationProtectionPolicyLabelEvaluateApplicationOperation(),
        new CreateMeInformationProtectionPolicyLabelEvaluateClassificationResultOperation(),
        new CreateMeInformationProtectionPolicyLabelEvaluateRemovalOperation(),
        new CreateMeInformationProtectionPolicyLabelExtractLabelOperation(),
        new CreateMeInformationProtectionPolicyLabelOperation(),
        new DeleteMeInformationProtectionPolicyLabelByIdOperation(),
        new GetMeInformationProtectionPolicyLabelByIdOperation(),
        new GetMeInformationProtectionPolicyLabelCountOperation(),
        new ListMeInformationProtectionPolicyLabelsOperation(),
        new UpdateMeInformationProtectionPolicyLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeInformationProtectionPolicyLabelEvaluateApplicationRequestModel),
        typeof(CreateMeInformationProtectionPolicyLabelEvaluateClassificationResultRequestModel),
        typeof(CreateMeInformationProtectionPolicyLabelEvaluateRemovalRequestModel),
        typeof(CreateMeInformationProtectionPolicyLabelExtractLabelRequestModel)
    };
}
