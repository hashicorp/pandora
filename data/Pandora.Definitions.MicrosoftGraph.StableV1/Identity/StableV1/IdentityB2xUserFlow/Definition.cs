// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlow;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlow";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityB2xUserFlowOperation(),
        new DeleteIdentityB2xUserFlowByIdOperation(),
        new GetIdentityB2xUserFlowByIdOperation(),
        new GetIdentityB2xUserFlowCountOperation(),
        new ListIdentityB2xUserFlowsOperation(),
        new UpdateIdentityB2xUserFlowByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
