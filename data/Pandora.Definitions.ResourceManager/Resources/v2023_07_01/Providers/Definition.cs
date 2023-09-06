using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_07_01.Providers;

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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AliasPathAttributesConstant),
        typeof(AliasPathTokenTypeConstant),
        typeof(AliasPatternTypeConstant),
        typeof(AliasTypeConstant),
        typeof(ProviderAuthorizationConsentStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AliasModel),
        typeof(AliasPathModel),
        typeof(AliasPathMetadataModel),
        typeof(AliasPatternModel),
        typeof(ApiProfileModel),
        typeof(PermissionModel),
        typeof(ProviderModel),
        typeof(ProviderConsentDefinitionModel),
        typeof(ProviderExtendedLocationModel),
        typeof(ProviderPermissionModel),
        typeof(ProviderPermissionListResultModel),
        typeof(ProviderRegistrationRequestModel),
        typeof(ProviderResourceTypeModel),
        typeof(ProviderResourceTypeListResultModel),
        typeof(RoleDefinitionModel),
        typeof(ZoneMappingModel),
    };
}
