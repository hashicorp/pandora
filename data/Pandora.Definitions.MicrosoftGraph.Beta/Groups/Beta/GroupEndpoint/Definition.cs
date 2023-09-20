// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEndpoint;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEndpoint";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEndpointOperation(),
        new DeleteGroupByIdEndpointByIdOperation(),
        new GetGroupByIdEndpointByIdOperation(),
        new GetGroupByIdEndpointCountOperation(),
        new ListGroupByIdEndpointsOperation(),
        new UpdateGroupByIdEndpointByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
