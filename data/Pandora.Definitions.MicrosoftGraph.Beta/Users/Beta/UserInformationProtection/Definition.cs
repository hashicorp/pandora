// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtection;

internal class Definition : ResourceDefinition
{
    public string Name => "UserInformationProtection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdInformationProtectionDecryptBufferOperation(),
        new CreateUserByIdInformationProtectionEncryptBufferOperation(),
        new CreateUserByIdInformationProtectionSignDigestOperation(),
        new CreateUserByIdInformationProtectionVerifySignatureOperation(),
        new DeleteUserByIdInformationProtectionOperation(),
        new GetUserByIdInformationProtectionOperation(),
        new UpdateUserByIdInformationProtectionOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdInformationProtectionDecryptBufferRequestModel),
        typeof(CreateUserByIdInformationProtectionEncryptBufferRequestModel),
        typeof(CreateUserByIdInformationProtectionSignDigestRequestModel),
        typeof(CreateUserByIdInformationProtectionVerifySignatureRequestModel)
    };
}
