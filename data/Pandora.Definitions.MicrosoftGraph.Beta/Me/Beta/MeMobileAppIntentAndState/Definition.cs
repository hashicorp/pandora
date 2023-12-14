// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMobileAppIntentAndState;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMobileAppIntentAndState";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMobileAppIntentAndStateOperation(),
        new DeleteMeMobileAppIntentAndStateByIdOperation(),
        new GetMeMobileAppIntentAndStateByIdOperation(),
        new GetMeMobileAppIntentAndStateCountOperation(),
        new ListMeMobileAppIntentAndStatesOperation(),
        new UpdateMeMobileAppIntentAndStateByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
