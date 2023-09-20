// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeUsageRight;

internal class Definition : ResourceDefinition
{
    public string Name => "MeUsageRight";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeUsageRightOperation(),
        new DeleteMeUsageRightByIdOperation(),
        new GetMeUsageRightByIdOperation(),
        new GetMeUsageRightCountOperation(),
        new ListMeUsageRightsOperation(),
        new UpdateMeUsageRightByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
