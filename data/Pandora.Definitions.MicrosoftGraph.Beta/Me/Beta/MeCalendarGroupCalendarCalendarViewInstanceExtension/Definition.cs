// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarCalendarViewInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarCalendarViewInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionOperation(),
        new DeleteMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionsOperation(),
        new UpdateMeCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
