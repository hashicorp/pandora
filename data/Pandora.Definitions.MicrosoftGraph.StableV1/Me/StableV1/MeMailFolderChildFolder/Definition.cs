// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMailFolderChildFolder;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolderChildFolder";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdChildFolderByIdCopyOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMoveOperation(),
        new CreateMeMailFolderByIdChildFolderOperation(),
        new DeleteMeMailFolderByIdChildFolderByIdOperation(),
        new GetMeMailFolderByIdChildFolderByIdOperation(),
        new GetMeMailFolderByIdChildFolderCountOperation(),
        new ListMeMailFolderByIdChildFoldersOperation(),
        new UpdateMeMailFolderByIdChildFolderByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeMailFolderByIdChildFolderByIdCopyRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMoveRequestModel)
    };
}
