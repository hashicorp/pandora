// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdInstanceByIdAcceptOperation(),
        new CreateMeEventByIdInstanceByIdCancelOperation(),
        new CreateMeEventByIdInstanceByIdDeclineOperation(),
        new CreateMeEventByIdInstanceByIdDismissReminderOperation(),
        new CreateMeEventByIdInstanceByIdForwardOperation(),
        new CreateMeEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateMeEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetMeEventByIdInstanceByIdOperation(),
        new GetMeEventByIdInstanceCountOperation(),
        new ListMeEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateMeEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateMeEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateMeEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateMeEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateMeEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
