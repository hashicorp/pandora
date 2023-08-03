using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2023_06_01.Accounts;

internal class Definition : ResourceDefinition
{
    public string Name => "Accounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListSasOperation(),
        new RegenerateKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IdentityTypeConstant),
        typeof(InfrastructureEncryptionConstant),
        typeof(KeyTypeConstant),
        typeof(KindConstant),
        typeof(NameConstant),
        typeof(SigningKeyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountSasParametersModel),
        typeof(CorsRuleModel),
        typeof(CorsRulesModel),
        typeof(CustomerManagedKeyEncryptionModel),
        typeof(CustomerManagedKeyEncryptionKeyEncryptionKeyIdentityModel),
        typeof(EncryptionModel),
        typeof(LinkedResourceModel),
        typeof(MapsAccountModel),
        typeof(MapsAccountKeysModel),
        typeof(MapsAccountPropertiesModel),
        typeof(MapsAccountSasTokenModel),
        typeof(MapsAccountUpdateParametersModel),
        typeof(MapsKeySpecificationModel),
        typeof(SkuModel),
    };
}
