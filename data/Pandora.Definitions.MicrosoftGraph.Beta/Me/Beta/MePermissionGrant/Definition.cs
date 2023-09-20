// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "MePermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckMePermissionGrantByIdMemberGroupOperation(),
        new CheckMePermissionGrantByIdMemberObjectOperation(),
        new CreateMePermissionGrantOperation(),
        new DeleteMePermissionGrantByIdOperation(),
        new GetMePermissionGrantByIdMemberGroupOperation(),
        new GetMePermissionGrantByIdMemberObjectOperation(),
        new GetMePermissionGrantByIdOperation(),
        new GetMePermissionGrantCountOperation(),
        new GetMePermissionGrantsByIdsOperation(),
        new GetMePermissionGrantsUserOwnedObjectOperation(),
        new ListMePermissionGrantsOperation(),
        new RestoreMePermissionGrantByIdOperation(),
        new UpdateMePermissionGrantByIdOperation(),
        new ValidateMePermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckMePermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckMePermissionGrantByIdMemberObjectRequestModel),
        typeof(GetMePermissionGrantByIdMemberGroupRequestModel),
        typeof(GetMePermissionGrantByIdMemberObjectRequestModel),
        typeof(GetMePermissionGrantsByIdsRequestModel),
        typeof(GetMePermissionGrantsUserOwnedObjectRequestModel),
        typeof(ValidateMePermissionGrantsPropertyRequestModel)
    };
}
