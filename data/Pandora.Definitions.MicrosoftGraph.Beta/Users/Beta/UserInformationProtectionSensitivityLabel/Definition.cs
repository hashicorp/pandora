// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionSensitivityLabel;

internal class Definition : ResourceDefinition
{
    public string Name => "UserInformationProtectionSensitivityLabel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdInformationProtectionSensitivityLabelEvaluateOperation(),
        new CreateUserByIdInformationProtectionSensitivityLabelOperation(),
        new DeleteUserByIdInformationProtectionSensitivityLabelByIdOperation(),
        new GetUserByIdInformationProtectionSensitivityLabelByIdOperation(),
        new GetUserByIdInformationProtectionSensitivityLabelCountOperation(),
        new ListUserByIdInformationProtectionSensitivityLabelsOperation(),
        new UpdateUserByIdInformationProtectionSensitivityLabelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdInformationProtectionSensitivityLabelEvaluateRequestModel)
    };
}
