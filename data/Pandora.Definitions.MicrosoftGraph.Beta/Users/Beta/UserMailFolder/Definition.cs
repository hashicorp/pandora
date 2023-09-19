// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolder;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolder";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdMailFolderByIdCopyOperation(),
        new CreateUserByIdMailFolderByIdMoveOperation(),
        new CreateUserByIdMailFolderOperation(),
        new DeleteUserByIdMailFolderByIdOperation(),
        new GetUserByIdMailFolderByIdOperation(),
        new GetUserByIdMailFolderCountOperation(),
        new ListUserByIdMailFoldersOperation(),
        new UpdateUserByIdMailFolderByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdMailFolderByIdCopyRequestModel),
        typeof(CreateUserByIdMailFolderByIdMoveRequestModel)
    };
}
