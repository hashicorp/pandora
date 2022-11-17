using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Providers;

internal class Definition : ResourceDefinition
{
    public string Name => "Providers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetAtTenantScopeOperation(),
        new ListOperation(),
        new ListAtTenantScopeOperation(),
        new ProviderPermissionsOperation(),
        new ProviderResourceTypesListOperation(),
        new RegisterOperation(),
        new RegisterAtManagementGroupScopeOperation(),
        new UnregisterOperation(),
    };
}
