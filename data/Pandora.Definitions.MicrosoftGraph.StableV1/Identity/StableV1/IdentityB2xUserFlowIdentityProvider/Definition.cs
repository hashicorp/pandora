// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowIdentityProvider;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowIdentityProvider";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetIdentityB2xUserFlowByIdIdentityProviderByIdOperation(),
        new GetIdentityB2xUserFlowByIdIdentityProviderCountOperation(),
        new ListIdentityB2xUserFlowByIdIdentityProvidersOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
