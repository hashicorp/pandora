using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Namespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAuthorizationRuleOperation(),
        new DeleteOperation(),
        new DeleteAuthorizationRuleOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new ListOperation(),
        new ListAuthorizationRulesOperation(),
        new ListByResourceGroupOperation(),
        new ListKeysOperation(),
        new RegenerateKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(KeyTypeConstant),
        typeof(ProvisioningStateEnumConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
        typeof(UnavailableReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(AuthorizationRuleModel),
        typeof(AuthorizationRulePropertiesModel),
        typeof(CheckNameAvailabilityModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(RegenerateAccessKeyParametersModel),
        typeof(RelayNamespaceModel),
        typeof(RelayNamespacePropertiesModel),
        typeof(RelayUpdateParametersModel),
        typeof(SkuModel),
    };
}
