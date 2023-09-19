// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeChatPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckMeChatByIdPermissionGrantByIdMemberGroupOperation(),
        new CheckMeChatByIdPermissionGrantByIdMemberObjectOperation(),
        new CreateMeChatByIdPermissionGrantOperation(),
        new DeleteMeChatByIdPermissionGrantByIdOperation(),
        new GetMeChatByIdPermissionGrantByIdMemberGroupOperation(),
        new GetMeChatByIdPermissionGrantByIdMemberObjectOperation(),
        new GetMeChatByIdPermissionGrantByIdOperation(),
        new GetMeChatByIdPermissionGrantCountOperation(),
        new GetMeChatByIdPermissionGrantsAvailableExtensionPropertiesOperation(),
        new GetMeChatByIdPermissionGrantsByIdsOperation(),
        new ListMeChatByIdPermissionGrantsOperation(),
        new RestoreMeChatByIdPermissionGrantByIdOperation(),
        new UpdateMeChatByIdPermissionGrantByIdOperation(),
        new ValidateMeChatByIdPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckMeChatByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckMeChatByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetMeChatByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetMeChatByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetMeChatByIdPermissionGrantsAvailableExtensionPropertiesRequestModel),
        typeof(GetMeChatByIdPermissionGrantsByIdsRequestModel),
        typeof(ValidateMeChatByIdPermissionGrantsPropertyRequestModel)
    };
}
