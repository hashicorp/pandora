// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarEventInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdInstanceByIdExtensionOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExtensionOperation(),
        new DeleteMeCalendarByIdEventByIdInstanceByIdExtensionByIdOperation(),
        new DeleteMeCalendarEventByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdExtensionCountOperation(),
        new GetMeCalendarEventByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarEventByIdInstanceByIdExtensionCountOperation(),
        new ListMeCalendarByIdEventByIdInstanceByIdExtensionsOperation(),
        new ListMeCalendarEventByIdInstanceByIdExtensionsOperation(),
        new UpdateMeCalendarByIdEventByIdInstanceByIdExtensionByIdOperation(),
        new UpdateMeCalendarEventByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
