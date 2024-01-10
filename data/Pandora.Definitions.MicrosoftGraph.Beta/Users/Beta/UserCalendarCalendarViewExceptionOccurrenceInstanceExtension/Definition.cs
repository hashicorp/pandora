// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewExceptionOccurrenceInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewExceptionOccurrenceInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new ListUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
