// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdInstanceByIdExtensionOperation(),
        new DeleteGroupByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdExtensionCountOperation(),
        new ListGroupByIdCalendarViewByIdInstanceByIdExtensionsOperation(),
        new UpdateGroupByIdCalendarViewByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
