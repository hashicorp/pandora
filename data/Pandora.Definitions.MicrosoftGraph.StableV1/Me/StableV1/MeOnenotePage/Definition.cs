// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnenotePage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnenotePage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnenotePageByIdCopyToSectionOperation(),
        new CreateMeOnenotePageByIdOnenotePatchContentOperation(),
        new CreateMeOnenotePageOperation(),
        new DeleteMeOnenotePageByIdOperation(),
        new GetMeOnenotePageByIdOperation(),
        new GetMeOnenotePageCountOperation(),
        new ListMeOnenotePagesOperation(),
        new UpdateMeOnenotePageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOnenotePageByIdCopyToSectionRequestModel),
        typeof(CreateMeOnenotePageByIdOnenotePatchContentRequestModel)
    };
}
