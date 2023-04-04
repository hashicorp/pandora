using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Providers;

internal class Definition : ResourceDefinition
{
    public string Name => "Providers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetAtTenantScopeOperation(),
        new ListOperation(),
        new ListAtTenantScopeOperation(),
        new RegisterOperation(),
        new RegisterAtManagementGroupScopeOperation(),
        new UnregisterOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AliasPathAttributesConstant),
        typeof(AliasPathTokenTypeConstant),
        typeof(AliasPatternTypeConstant),
        typeof(AliasTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AliasModel),
        typeof(AliasPathModel),
        typeof(AliasPathMetadataModel),
        typeof(AliasPatternModel),
        typeof(ApiProfileModel),
        typeof(ProviderModel),
        typeof(ProviderResourceTypeModel),
        typeof(ZoneMappingModel),
    };
}
