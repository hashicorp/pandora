// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryOutboundSharedUserProfile;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryOutboundSharedUserProfile";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryOutboundSharedUserProfileOperation(),
        new DeleteDirectoryOutboundSharedUserProfileByIdOperation(),
        new GetDirectoryOutboundSharedUserProfileByIdOperation(),
        new GetDirectoryOutboundSharedUserProfileCountOperation(),
        new ListDirectoryOutboundSharedUserProfilesOperation(),
        new UpdateDirectoryOutboundSharedUserProfileByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
