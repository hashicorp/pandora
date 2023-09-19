// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowLanguageDefaultPage;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowLanguageDefaultPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityB2xUserFlowByIdLanguageByIdDefaultPageOperation(),
        new CreateUpdateIdentityB2xUserFlowByIdLanguageByIdDefaultPageByIdValueOperation(),
        new DeleteIdentityB2xUserFlowByIdLanguageByIdDefaultPageByIdOperation(),
        new GetIdentityB2xUserFlowByIdLanguageByIdDefaultPageByIdOperation(),
        new GetIdentityB2xUserFlowByIdLanguageByIdDefaultPageByIdValueOperation(),
        new GetIdentityB2xUserFlowByIdLanguageByIdDefaultPageCountOperation(),
        new ListIdentityB2xUserFlowByIdLanguageByIdDefaultPagesOperation(),
        new UpdateIdentityB2xUserFlowByIdLanguageByIdDefaultPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
