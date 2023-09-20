// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.DirectoryObjects.StableV1.DirectoryObject;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryObject";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckDirectoryObjectByIdMemberGroupOperation(),
        new CheckDirectoryObjectByIdMemberObjectOperation(),
        new CreateDirectoryObjectOperation(),
        new DeleteDirectoryObjectByIdOperation(),
        new GetDirectoryObjectByIdMemberGroupOperation(),
        new GetDirectoryObjectByIdMemberObjectOperation(),
        new GetDirectoryObjectByIdOperation(),
        new GetDirectoryObjectCountOperation(),
        new GetDirectoryObjectsAvailableExtensionPropertiesOperation(),
        new GetDirectoryObjectsByIdsOperation(),
        new ListDirectoryObjectsOperation(),
        new RestoreDirectoryObjectByIdOperation(),
        new UpdateDirectoryObjectByIdOperation(),
        new ValidateDirectoryObjectsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckDirectoryObjectByIdMemberGroupRequestModel),
        typeof(CheckDirectoryObjectByIdMemberObjectRequestModel),
        typeof(GetDirectoryObjectByIdMemberGroupRequestModel),
        typeof(GetDirectoryObjectByIdMemberObjectRequestModel),
        typeof(GetDirectoryObjectsAvailableExtensionPropertiesRequestModel),
        typeof(GetDirectoryObjectsByIdsRequestModel),
        typeof(ValidateDirectoryObjectsPropertyRequestModel)
    };
}
