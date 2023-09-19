// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.Group;

internal class Definition : ResourceDefinition
{
    public string Name => "Group";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddGroupByIdFavoriteOperation(),
        new AssignGroupByIdLicenseOperation(),
        new CheckGroupByIdGrantedPermissionsForAppsOperation(),
        new CheckGroupByIdMemberGroupOperation(),
        new CheckGroupByIdMemberObjectOperation(),
        new CreateGroupByIdResetUnseenCountOperation(),
        new CreateGroupByIdRetryServiceProvisioningOperation(),
        new CreateGroupByIdSubscribeByMailOperation(),
        new CreateGroupByIdUnsubscribeByMailOperation(),
        new CreateGroupOperation(),
        new DeleteGroupByIdOperation(),
        new GetGroupByIdMemberGroupOperation(),
        new GetGroupByIdMemberObjectOperation(),
        new GetGroupByIdOperation(),
        new GetGroupCountOperation(),
        new GetGroupsAvailableExtensionPropertiesOperation(),
        new GetGroupsByIdsOperation(),
        new ListGroupsOperation(),
        new RemoveGroupByIdFavoriteOperation(),
        new RenewGroupByIdOperation(),
        new RestoreGroupByIdOperation(),
        new UpdateGroupByIdOperation(),
        new ValidateGroupByIdPropertyOperation(),
        new ValidateGroupsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignGroupByIdLicenseRequestModel),
        typeof(CheckGroupByIdMemberGroupRequestModel),
        typeof(CheckGroupByIdMemberObjectRequestModel),
        typeof(GetGroupByIdMemberGroupRequestModel),
        typeof(GetGroupByIdMemberObjectRequestModel),
        typeof(GetGroupsAvailableExtensionPropertiesRequestModel),
        typeof(GetGroupsByIdsRequestModel),
        typeof(ValidateGroupByIdPropertyRequestModel),
        typeof(ValidateGroupsPropertyRequestModel)
    };
}
