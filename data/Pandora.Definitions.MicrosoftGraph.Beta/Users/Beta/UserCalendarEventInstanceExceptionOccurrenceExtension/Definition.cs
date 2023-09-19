// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventInstanceExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventInstanceExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new ListUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
