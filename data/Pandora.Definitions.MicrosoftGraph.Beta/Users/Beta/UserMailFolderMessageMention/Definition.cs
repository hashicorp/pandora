// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolderMessageMention;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderMessageMention";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdMailFolderByIdMessageByIdMentionOperation(),
        new DeleteUserByIdMailFolderByIdMessageByIdMentionByIdOperation(),
        new GetUserByIdMailFolderByIdMessageByIdMentionByIdOperation(),
        new GetUserByIdMailFolderByIdMessageByIdMentionCountOperation(),
        new ListUserByIdMailFolderByIdMessageByIdMentionsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
