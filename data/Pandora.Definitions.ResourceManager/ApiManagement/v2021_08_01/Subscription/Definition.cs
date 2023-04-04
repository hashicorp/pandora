using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Subscription;

internal class Definition : ResourceDefinition
{
    public string Name => "Subscription";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListOperation(),
        new ListSecretsOperation(),
        new RegeneratePrimaryKeyOperation(),
        new RegenerateSecondaryKeyOperation(),
        new UpdateOperation(),
        new UserSubscriptionGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessIdNameConstant),
        typeof(AppTypeConstant),
        typeof(IdentityProviderTypeConstant),
        typeof(NotificationNameConstant),
        typeof(SubscriptionStateConstant),
        typeof(TemplateNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SubscriptionContractModel),
        typeof(SubscriptionContractPropertiesModel),
        typeof(SubscriptionCreateParameterPropertiesModel),
        typeof(SubscriptionCreateParametersModel),
        typeof(SubscriptionKeysContractModel),
        typeof(SubscriptionUpdateParameterPropertiesModel),
        typeof(SubscriptionUpdateParametersModel),
    };
}
