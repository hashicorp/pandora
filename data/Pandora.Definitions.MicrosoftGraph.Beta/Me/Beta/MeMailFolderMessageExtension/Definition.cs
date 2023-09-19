// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMailFolderMessageExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolderMessageExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdMessageByIdExtensionOperation(),
        new DeleteMeMailFolderByIdMessageByIdExtensionByIdOperation(),
        new GetMeMailFolderByIdMessageByIdExtensionByIdOperation(),
        new GetMeMailFolderByIdMessageByIdExtensionCountOperation(),
        new ListMeMailFolderByIdMessageByIdExtensionsOperation(),
        new UpdateMeMailFolderByIdMessageByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
