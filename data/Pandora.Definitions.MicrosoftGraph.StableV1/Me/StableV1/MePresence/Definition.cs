// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MePresence;

internal class Definition : ResourceDefinition
{
    public string Name => "MePresence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePresenceClearPresenceOperation(),
        new CreateMePresenceClearUserPreferredPresenceOperation(),
        new DeleteMePresenceOperation(),
        new GetMePresenceOperation(),
        new SetMePresencePresenceOperation(),
        new SetMePresenceStatusMessageOperation(),
        new SetMePresenceUserPreferredPresenceOperation(),
        new UpdateMePresenceOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMePresenceClearPresenceRequestModel),
        typeof(SetMePresencePresenceRequestModel),
        typeof(SetMePresenceStatusMessageRequestModel),
        typeof(SetMePresenceUserPreferredPresenceRequestModel)
    };
}
