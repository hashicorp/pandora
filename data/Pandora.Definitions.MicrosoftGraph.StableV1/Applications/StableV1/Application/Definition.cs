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
        new AddApplicationByIdKeyOperation(),
        new AddApplicationByIdPasswordOperation(),
        new CheckApplicationByIdMemberGroupOperation(),
        new CheckApplicationByIdMemberObjectOperation(),
        new CreateApplicationOperation(),
        new DeleteApplicationByIdOperation(),
        new GetApplicationByIdMemberGroupOperation(),
        new GetApplicationByIdMemberObjectOperation(),
        new GetApplicationByIdOperation(),
        new GetApplicationCountOperation(),
        new GetApplicationsAvailableExtensionPropertiesOperation(),
        new GetApplicationsByIdsOperation(),
        new ListApplicationsOperation(),
        new RemoveApplicationByIdKeyOperation(),
        new RemoveApplicationByIdPasswordOperation(),
        new RestoreApplicationByIdOperation(),
        new SetApplicationByIdVerifiedPublisherOperation(),
        new UnsetApplicationByIdVerifiedPublisherOperation(),
        new UpdateApplicationByIdOperation(),
        new ValidateApplicationsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddApplicationByIdKeyRequestModel),
        typeof(AddApplicationByIdPasswordRequestModel),
        typeof(CheckApplicationByIdMemberGroupRequestModel),
        typeof(CheckApplicationByIdMemberObjectRequestModel),
        typeof(GetApplicationByIdMemberGroupRequestModel),
        typeof(GetApplicationByIdMemberObjectRequestModel),
        typeof(GetApplicationsAvailableExtensionPropertiesRequestModel),
        typeof(GetApplicationsByIdsRequestModel),
        typeof(RemoveApplicationByIdKeyRequestModel),
        typeof(RemoveApplicationByIdPasswordRequestModel),
        typeof(SetApplicationByIdVerifiedPublisherRequestModel),
        typeof(ValidateApplicationsPropertyRequestModel)
    };
}
