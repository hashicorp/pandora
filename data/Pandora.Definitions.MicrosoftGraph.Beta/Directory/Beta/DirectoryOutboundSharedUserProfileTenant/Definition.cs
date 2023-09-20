// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryOutboundSharedUserProfileTenant;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryOutboundSharedUserProfileTenant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryOutboundSharedUserProfileByIdTenantOperation(),
        new DeleteDirectoryOutboundSharedUserProfileByIdTenantByIdOperation(),
        new GetDirectoryOutboundSharedUserProfileByIdTenantByIdOperation(),
        new GetDirectoryOutboundSharedUserProfileByIdTenantCountOperation(),
        new ListDirectoryOutboundSharedUserProfileByIdTenantsOperation(),
        new RemoveDirectoryOutboundSharedUserProfileByIdTenantByIdPersonalDataOperation(),
        new UpdateDirectoryOutboundSharedUserProfileByIdTenantByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
