// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarEventExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExtensionOperation(),
        new CreateMeCalendarEventByIdExtensionOperation(),
        new DeleteMeCalendarByIdEventByIdExtensionByIdOperation(),
        new DeleteMeCalendarEventByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdExtensionCountOperation(),
        new GetMeCalendarEventByIdExtensionByIdOperation(),
        new GetMeCalendarEventByIdExtensionCountOperation(),
        new ListMeCalendarByIdEventByIdExtensionsOperation(),
        new ListMeCalendarEventByIdExtensionsOperation(),
        new UpdateMeCalendarByIdEventByIdExtensionByIdOperation(),
        new UpdateMeCalendarEventByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
