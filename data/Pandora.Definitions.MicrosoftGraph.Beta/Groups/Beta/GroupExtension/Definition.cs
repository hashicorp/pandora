// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdExtensionOperation(),
        new DeleteGroupByIdExtensionByIdOperation(),
        new GetGroupByIdExtensionByIdOperation(),
        new GetGroupByIdExtensionCountOperation(),
        new ListGroupByIdExtensionsOperation(),
        new UpdateGroupByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
