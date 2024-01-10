// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileWebsite;

internal class Definition : ResourceDefinition
{
    public string Name => "MeProfileWebsite";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeProfileWebsiteOperation(),
        new DeleteMeProfileWebsiteByIdOperation(),
        new GetMeProfileWebsiteByIdOperation(),
        new GetMeProfileWebsiteCountOperation(),
        new ListMeProfileWebsitesOperation(),
        new UpdateMeProfileWebsiteByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
