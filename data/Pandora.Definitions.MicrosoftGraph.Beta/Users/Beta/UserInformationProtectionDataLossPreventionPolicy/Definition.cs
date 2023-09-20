// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionDataLossPreventionPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "UserInformationProtectionDataLossPreventionPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdInformationProtectionDataLossPreventionPolicyEvaluateOperation(),
        new CreateUserByIdInformationProtectionDataLossPreventionPolicyOperation(),
        new DeleteUserByIdInformationProtectionDataLossPreventionPolicyByIdOperation(),
        new GetUserByIdInformationProtectionDataLossPreventionPolicyByIdOperation(),
        new GetUserByIdInformationProtectionDataLossPreventionPolicyCountOperation(),
        new ListUserByIdInformationProtectionDataLossPreventionPoliciesOperation(),
        new UpdateUserByIdInformationProtectionDataLossPreventionPolicyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdInformationProtectionDataLossPreventionPolicyEvaluateRequestModel)
    };
}
