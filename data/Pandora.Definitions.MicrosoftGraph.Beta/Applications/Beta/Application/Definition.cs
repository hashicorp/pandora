// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.Application;

internal class Definition : ResourceDefinition
{
    public string Name => "Application";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddApplicationKeyOperation(),
        new AddApplicationPasswordOperation(),
        new CheckApplicationMemberGroupsOperation(),
        new CheckApplicationMemberObjectsOperation(),
        new CreateApplicationOperation(),
        new DeleteApplicationOperation(),
        new GetApplicationByIdsOperation(),
        new GetApplicationMemberGroupsOperation(),
        new GetApplicationMemberObjectsOperation(),
        new GetApplicationOperation(),
        new GetApplicationUserOwnedObjectsOperation(),
        new GetApplicationsCountOperation(),
        new ListApplicationsOperation(),
        new RemoveApplicationKeyOperation(),
        new RemoveApplicationPasswordOperation(),
        new RestoreApplicationOperation(),
        new SetApplicationVerifiedPublisherOperation(),
        new UnsetApplicationVerifiedPublisherOperation(),
        new UpdateApplicationOperation(),
        new ValidateApplicationPropertiesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddApplicationKeyRequestModel),
        typeof(AddApplicationPasswordRequestModel),
        typeof(CheckApplicationMemberGroupsRequestModel),
        typeof(CheckApplicationMemberObjectsRequestModel),
        typeof(GetApplicationByIdsRequestModel),
        typeof(GetApplicationMemberGroupsRequestModel),
        typeof(GetApplicationMemberObjectsRequestModel),
        typeof(GetApplicationUserOwnedObjectsRequestModel),
        typeof(RemoveApplicationKeyRequestModel),
        typeof(RemoveApplicationPasswordRequestModel),
        typeof(SetApplicationVerifiedPublisherRequestModel),
        typeof(ValidateApplicationPropertiesRequestModel)
    };
}
