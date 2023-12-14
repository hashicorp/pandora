// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileInterest;

internal class Definition : ResourceDefinition
{
    public string Name => "MeProfileInterest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeProfileInterestOperation(),
        new DeleteMeProfileInterestByIdOperation(),
        new GetMeProfileInterestByIdOperation(),
        new GetMeProfileInterestCountOperation(),
        new ListMeProfileInterestsOperation(),
        new UpdateMeProfileInterestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
