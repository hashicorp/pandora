using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Subscription;

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
        new WorkspaceSubscriptionCreateOrUpdateOperation(),
        new WorkspaceSubscriptionDeleteOperation(),
        new WorkspaceSubscriptionGetOperation(),
        new WorkspaceSubscriptionGetEntityTagOperation(),
        new WorkspaceSubscriptionListOperation(),
        new WorkspaceSubscriptionListSecretsOperation(),
        new WorkspaceSubscriptionRegeneratePrimaryKeyOperation(),
        new WorkspaceSubscriptionRegenerateSecondaryKeyOperation(),
        new WorkspaceSubscriptionUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AppTypeConstant),
        typeof(SubscriptionStateConstant),
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
