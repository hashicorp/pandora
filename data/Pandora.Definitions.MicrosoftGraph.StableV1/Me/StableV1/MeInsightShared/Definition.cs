// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeInsightShared;

internal class Definition : ResourceDefinition
{
    public string Name => "MeInsightShared";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeInsightSharedOperation(),
        new DeleteMeInsightSharedByIdOperation(),
        new GetMeInsightSharedByIdOperation(),
        new GetMeInsightSharedCountOperation(),
        new ListMeInsightSharedsOperation(),
        new UpdateMeInsightSharedByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
