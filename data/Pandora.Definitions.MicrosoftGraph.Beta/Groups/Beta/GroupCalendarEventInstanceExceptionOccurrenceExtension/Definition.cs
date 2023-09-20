// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarEventInstanceExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarEventInstanceExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateGroupByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
