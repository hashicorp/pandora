// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.Application;

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
        new GetApplicationAvailableExtensionPropertiesOperation(),
        new GetApplicationByIdsOperation(),
        new GetApplicationMemberGroupsOperation(),
        new GetApplicationMemberObjectsOperation(),
        new GetApplicationOperation(),
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
        typeof(GetApplicationAvailableExtensionPropertiesRequestModel),
        typeof(GetApplicationByIdsRequestModel),
        typeof(GetApplicationMemberGroupsRequestModel),
        typeof(GetApplicationMemberObjectsRequestModel),
        typeof(RemoveApplicationKeyRequestModel),
        typeof(RemoveApplicationPasswordRequestModel),
        typeof(SetApplicationVerifiedPublisherRequestModel),
        typeof(ValidateApplicationPropertiesRequestModel)
    };
}
