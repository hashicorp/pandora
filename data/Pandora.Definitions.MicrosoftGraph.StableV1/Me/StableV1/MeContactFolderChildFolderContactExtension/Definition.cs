// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeContactFolderChildFolderContactExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeContactFolderChildFolderContactExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeContactFolderByIdChildFolderByIdContactByIdExtensionOperation(),
        new DeleteMeContactFolderByIdChildFolderByIdContactByIdExtensionByIdOperation(),
        new GetMeContactFolderByIdChildFolderByIdContactByIdExtensionByIdOperation(),
        new GetMeContactFolderByIdChildFolderByIdContactByIdExtensionCountOperation(),
        new ListMeContactFolderByIdChildFolderByIdContactByIdExtensionsOperation(),
        new UpdateMeContactFolderByIdChildFolderByIdContactByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
