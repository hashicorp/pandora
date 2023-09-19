// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesAuthenticationStrength;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityConditionalAccesAuthenticationStrength";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteIdentityConditionalAccesAuthenticationStrengthOperation(),
        new GetIdentityConditionalAccesAuthenticationStrengthOperation(),
        new UpdateIdentityConditionalAccesAuthenticationStrengthOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
