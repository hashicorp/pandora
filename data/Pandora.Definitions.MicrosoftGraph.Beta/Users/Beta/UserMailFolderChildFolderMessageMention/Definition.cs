// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolderChildFolderMessageMention;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderChildFolderMessageMention";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdMentionOperation(),
        new DeleteUserByIdMailFolderByIdChildFolderByIdMessageByIdMentionByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdMentionByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdMentionCountOperation(),
        new ListUserByIdMailFolderByIdChildFolderByIdMessageByIdMentionsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
