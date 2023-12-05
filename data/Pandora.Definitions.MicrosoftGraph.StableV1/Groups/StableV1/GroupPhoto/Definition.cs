// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPhoto;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupPhoto";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateGroupByIdPhotoByIdValueOperation(),
        new CreateUpdateGroupByIdPhotoValueOperation(),
        new DeleteGroupByIdPhotoOperation(),
        new GetGroupByIdPhotoByIdOperation(),
        new GetGroupByIdPhotoByIdValueOperation(),
        new GetGroupByIdPhotoOperation(),
        new GetGroupByIdPhotoValueOperation(),
        new ListGroupByIdPhotosOperation(),
        new UpdateGroupByIdPhotoOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
