// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserSecurityInformationProtectionSensitivityLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "UserSecurityInformationProtectionSensitivityLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdSecurityInformationProtectionSensitivityLabelOperation(),
        new CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityEvaluateApplicationOperation(),
        new CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityEvaluateClassificationResultOperation(),
        new CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityEvaluateRemovalOperation(),
        new CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityExtractContentLabelOperation(),
        new DeleteUserByIdSecurityInformationProtectionSensitivityLabelByIdOperation(),
        new GetUserByIdSecurityInformationProtectionSensitivityLabelByIdOperation(),
        new GetUserByIdSecurityInformationProtectionSensitivityLabelCountOperation(),
        new ListUserByIdSecurityInformationProtectionSensitivityLabelsOperation(),
        new UpdateUserByIdSecurityInformationProtectionSensitivityLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityEvaluateApplicationRequestModel),
        typeof(CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityEvaluateClassificationResultRequestModel),
        typeof(CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityEvaluateRemovalRequestModel),
        typeof(CreateUserByIdSecurityInformationProtectionSensitivityLabelSecurityExtractContentLabelRequestModel)
    };
}
