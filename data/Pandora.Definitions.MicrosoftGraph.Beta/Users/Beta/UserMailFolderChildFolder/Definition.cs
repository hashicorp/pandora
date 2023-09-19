// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolderChildFolder;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderChildFolder";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdMailFolderByIdChildFolderByIdCopyOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMoveOperation(),
        new CreateUserByIdMailFolderByIdChildFolderOperation(),
        new DeleteUserByIdMailFolderByIdChildFolderByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderCountOperation(),
        new ListUserByIdMailFolderByIdChildFoldersOperation(),
        new UpdateUserByIdMailFolderByIdChildFolderByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdCopyRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMoveRequestModel)
    };
}
