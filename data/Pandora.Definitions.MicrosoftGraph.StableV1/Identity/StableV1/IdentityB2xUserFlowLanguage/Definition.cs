// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowLanguage;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowLanguage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityB2xUserFlowByIdLanguageOperation(),
        new DeleteIdentityB2xUserFlowByIdLanguageByIdOperation(),
        new GetIdentityB2xUserFlowByIdLanguageByIdOperation(),
        new GetIdentityB2xUserFlowByIdLanguageCountOperation(),
        new ListIdentityB2xUserFlowByIdLanguagesOperation(),
        new UpdateIdentityB2xUserFlowByIdLanguageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
