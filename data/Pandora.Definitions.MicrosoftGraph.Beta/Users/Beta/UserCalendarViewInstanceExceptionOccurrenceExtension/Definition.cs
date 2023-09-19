// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarViewInstanceExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarViewInstanceExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteUserByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListUserByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateUserByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
