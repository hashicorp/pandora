// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtection;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteInformationProtection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdInformationProtectionDecryptBufferOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionEncryptBufferOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionSignDigestOperation(),
        new CreateGroupByIdSiteByIdInformationProtectionVerifySignatureOperation(),
        new DeleteGroupByIdSiteByIdInformationProtectionOperation(),
        new GetGroupByIdSiteByIdInformationProtectionOperation(),
        new UpdateGroupByIdSiteByIdInformationProtectionOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdInformationProtectionDecryptBufferRequestModel),
        typeof(CreateGroupByIdSiteByIdInformationProtectionEncryptBufferRequestModel),
        typeof(CreateGroupByIdSiteByIdInformationProtectionSignDigestRequestModel),
        typeof(CreateGroupByIdSiteByIdInformationProtectionVerifySignatureRequestModel)
    };
}
