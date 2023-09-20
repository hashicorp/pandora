// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupPermissionGrant;

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
        new GetGroupByIdPermissionGrantsByIdsOperation(),
        new GetGroupByIdPermissionGrantsUserOwnedObjectOperation(),
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
        typeof(GetGroupByIdPermissionGrantsByIdsRequestModel),
        typeof(GetGroupByIdPermissionGrantsUserOwnedObjectRequestModel),
        typeof(ValidateGroupByIdPermissionGrantsPropertyRequestModel)
    };
}
