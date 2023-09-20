// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExtensionOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExtensionOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdExtensionCountOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdExtensionCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdInstanceByIdExtensionsOperation(),
        new ListMeCalendarCalendarViewByIdInstanceByIdExtensionsOperation(),
        new UpdateMeCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new UpdateMeCalendarCalendarViewByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
