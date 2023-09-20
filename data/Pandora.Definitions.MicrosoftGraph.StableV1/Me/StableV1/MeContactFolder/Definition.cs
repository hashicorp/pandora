// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeContactFolder;

internal class Definition : ResourceDefinition
{
    public string Name => "MeContactFolder";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeContactFolderOperation(),
        new DeleteMeContactFolderByIdOperation(),
        new GetMeContactFolderByIdOperation(),
        new GetMeContactFolderCountOperation(),
        new ListMeContactFoldersOperation(),
        new UpdateMeContactFolderByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
