// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowUserFlowIdentityProvider;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowUserFlowIdentityProvider";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddIdentityB2xUserFlowByIdUserFlowIdentityProviderRefOperation(),
        new GetIdentityB2xUserFlowByIdUserFlowIdentityProviderCountOperation(),
        new ListIdentityB2xUserFlowByIdUserFlowIdentityProviderRefsOperation(),
        new ListIdentityB2xUserFlowByIdUserFlowIdentityProvidersOperation(),
        new RemoveIdentityB2xUserFlowByIdUserFlowIdentityProviderByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
