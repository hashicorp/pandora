// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtection;

internal class Definition : ResourceDefinition
{
    public string Name => "MeInformationProtection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeInformationProtectionDecryptBufferOperation(),
        new CreateMeInformationProtectionEncryptBufferOperation(),
        new CreateMeInformationProtectionSignDigestOperation(),
        new CreateMeInformationProtectionVerifySignatureOperation(),
        new DeleteMeInformationProtectionOperation(),
        new GetMeInformationProtectionOperation(),
        new UpdateMeInformationProtectionOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeInformationProtectionDecryptBufferRequestModel),
        typeof(CreateMeInformationProtectionEncryptBufferRequestModel),
        typeof(CreateMeInformationProtectionSignDigestRequestModel),
        typeof(CreateMeInformationProtectionVerifySignatureRequestModel)
    };
}
