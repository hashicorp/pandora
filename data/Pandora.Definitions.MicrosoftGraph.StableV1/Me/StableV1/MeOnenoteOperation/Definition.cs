// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnenoteOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnenoteOperation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnenoteOperationOperation(),
        new DeleteMeOnenoteOperationByIdOperation(),
        new GetMeOnenoteOperationByIdOperation(),
        new GetMeOnenoteOperationCountOperation(),
        new ListMeOnenoteOperationsOperation(),
        new UpdateMeOnenoteOperationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
