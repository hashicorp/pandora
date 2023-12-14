// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExtensionOperation(),
        new CreateMeCalendarCalendarViewByIdExtensionOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdExtensionByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExtensionCountOperation(),
        new GetMeCalendarCalendarViewByIdExtensionByIdOperation(),
        new GetMeCalendarCalendarViewByIdExtensionCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExtensionsOperation(),
        new ListMeCalendarCalendarViewByIdExtensionsOperation(),
        new UpdateMeCalendarByIdCalendarViewByIdExtensionByIdOperation(),
        new UpdateMeCalendarCalendarViewByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
