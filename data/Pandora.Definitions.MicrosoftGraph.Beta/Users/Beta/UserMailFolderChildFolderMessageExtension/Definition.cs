// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolderChildFolderMessageExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderChildFolderMessageExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdExtensionOperation(),
        new DeleteUserByIdMailFolderByIdChildFolderByIdMessageByIdExtensionByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdExtensionByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdExtensionCountOperation(),
        new ListUserByIdMailFolderByIdChildFolderByIdMessageByIdExtensionsOperation(),
        new UpdateUserByIdMailFolderByIdChildFolderByIdMessageByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
