// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.Group;

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
        new CreateGroupByIdEvaluateDynamicMembershipOperation(),
        new CreateGroupByIdResetUnseenCountOperation(),
        new CreateGroupByIdRetryServiceProvisioningOperation(),
        new CreateGroupByIdSubscribeByMailOperation(),
        new CreateGroupByIdUnsubscribeByMailOperation(),
        new CreateGroupEvaluateDynamicMembershipOperation(),
        new CreateGroupOperation(),
        new DeleteGroupByIdOperation(),
        new GetGroupByIdMemberGroupOperation(),
        new GetGroupByIdMemberObjectOperation(),
        new GetGroupByIdOperation(),
        new GetGroupCountOperation(),
        new GetGroupsByIdsOperation(),
        new GetGroupsUserOwnedObjectOperation(),
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
        typeof(CreateGroupByIdEvaluateDynamicMembershipRequestModel),
        typeof(CreateGroupEvaluateDynamicMembershipRequestModel),
        typeof(GetGroupByIdMemberGroupRequestModel),
        typeof(GetGroupByIdMemberObjectRequestModel),
        typeof(GetGroupsByIdsRequestModel),
        typeof(GetGroupsUserOwnedObjectRequestModel),
        typeof(ValidateGroupByIdPropertyRequestModel),
        typeof(ValidateGroupsPropertyRequestModel)
    };
}
