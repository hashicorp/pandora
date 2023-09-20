// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMailFolder;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolder";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdCopyOperation(),
        new CreateMeMailFolderByIdMoveOperation(),
        new CreateMeMailFolderOperation(),
        new DeleteMeMailFolderByIdOperation(),
        new GetMeMailFolderByIdOperation(),
        new GetMeMailFolderCountOperation(),
        new ListMeMailFoldersOperation(),
        new UpdateMeMailFolderByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeMailFolderByIdCopyRequestModel),
        typeof(CreateMeMailFolderByIdMoveRequestModel)
    };
}
