// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionPolicyLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "UserInformationProtectionPolicyLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdInformationProtectionPolicyLabelEvaluateApplicationOperation(),
        new CreateUserByIdInformationProtectionPolicyLabelEvaluateClassificationResultOperation(),
        new CreateUserByIdInformationProtectionPolicyLabelEvaluateRemovalOperation(),
        new CreateUserByIdInformationProtectionPolicyLabelExtractLabelOperation(),
        new CreateUserByIdInformationProtectionPolicyLabelOperation(),
        new DeleteUserByIdInformationProtectionPolicyLabelByIdOperation(),
        new GetUserByIdInformationProtectionPolicyLabelByIdOperation(),
        new GetUserByIdInformationProtectionPolicyLabelCountOperation(),
        new ListUserByIdInformationProtectionPolicyLabelsOperation(),
        new UpdateUserByIdInformationProtectionPolicyLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdInformationProtectionPolicyLabelEvaluateApplicationRequestModel),
        typeof(CreateUserByIdInformationProtectionPolicyLabelEvaluateClassificationResultRequestModel),
        typeof(CreateUserByIdInformationProtectionPolicyLabelEvaluateRemovalRequestModel),
        typeof(CreateUserByIdInformationProtectionPolicyLabelExtractLabelRequestModel)
    };
}
