// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMobileAppTroubleshootingEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMobileAppTroubleshootingEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMobileAppTroubleshootingEventOperation(),
        new DeleteMeMobileAppTroubleshootingEventByIdOperation(),
        new GetMeMobileAppTroubleshootingEventByIdOperation(),
        new GetMeMobileAppTroubleshootingEventCountOperation(),
        new ListMeMobileAppTroubleshootingEventsOperation(),
        new UpdateMeMobileAppTroubleshootingEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
