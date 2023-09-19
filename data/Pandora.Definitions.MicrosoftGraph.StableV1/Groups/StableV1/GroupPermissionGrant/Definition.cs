// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckGroupByIdPermissionGrantByIdMemberGroupOperation(),
        new CheckGroupByIdPermissionGrantByIdMemberObjectOperation(),
        new CreateGroupByIdPermissionGrantOperation(),
        new DeleteGroupByIdPermissionGrantByIdOperation(),
        new GetGroupByIdPermissionGrantByIdMemberGroupOperation(),
        new GetGroupByIdPermissionGrantByIdMemberObjectOperation(),
        new GetGroupByIdPermissionGrantByIdOperation(),
        new GetGroupByIdPermissionGrantCountOperation(),
        new GetGroupByIdPermissionGrantsAvailableExtensionPropertiesOperation(),
        new GetGroupByIdPermissionGrantsByIdsOperation(),
        new ListGroupByIdPermissionGrantsOperation(),
        new RestoreGroupByIdPermissionGrantByIdOperation(),
        new UpdateGroupByIdPermissionGrantByIdOperation(),
        new ValidateGroupByIdPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckGroupByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckGroupByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetGroupByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetGroupByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetGroupByIdPermissionGrantsAvailableExtensionPropertiesRequestModel),
        typeof(GetGroupByIdPermissionGrantsByIdsRequestModel),
        typeof(ValidateGroupByIdPermissionGrantsPropertyRequestModel)
    };
}
