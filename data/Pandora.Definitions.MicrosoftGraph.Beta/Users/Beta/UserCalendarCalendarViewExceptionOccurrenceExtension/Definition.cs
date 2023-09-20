// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionsOperation(),
        new ListUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
