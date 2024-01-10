// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdAcceptOperation(),
        new CreateMeEventByIdCancelOperation(),
        new CreateMeEventByIdDeclineOperation(),
        new CreateMeEventByIdDismissReminderOperation(),
        new CreateMeEventByIdForwardOperation(),
        new CreateMeEventByIdSnoozeReminderOperation(),
        new CreateMeEventByIdTentativelyAcceptOperation(),
        new CreateMeEventOperation(),
        new DeleteMeEventByIdOperation(),
        new GetMeEventByIdOperation(),
        new GetMeEventCountOperation(),
        new ListMeEventsOperation(),
        new UpdateMeEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeEventByIdAcceptRequestModel),
        typeof(CreateMeEventByIdCancelRequestModel),
        typeof(CreateMeEventByIdDeclineRequestModel),
        typeof(CreateMeEventByIdForwardRequestModel),
        typeof(CreateMeEventByIdSnoozeReminderRequestModel),
        typeof(CreateMeEventByIdTentativelyAcceptRequestModel)
    };
}
