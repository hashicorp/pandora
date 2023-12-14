using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ContainerApps;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerApps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListSecretsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActiveRevisionsModeConstant),
        typeof(ContainerAppProvisioningStateConstant),
        typeof(IngressTransportMethodConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigurationModel),
        typeof(ContainerModel),
        typeof(ContainerAppModel),
        typeof(ContainerAppPropertiesModel),
        typeof(ContainerAppSecretModel),
        typeof(ContainerResourcesModel),
        typeof(CustomScaleRuleModel),
        typeof(DaprModel),
        typeof(DaprComponentModel),
        typeof(DaprMetadataModel),
        typeof(EnvironmentVarModel),
        typeof(HTTPScaleRuleModel),
        typeof(IngressModel),
        typeof(QueueScaleRuleModel),
        typeof(RegistryCredentialsModel),
        typeof(ScaleModel),
        typeof(ScaleRuleModel),
        typeof(ScaleRuleAuthModel),
        typeof(SecretModel),
        typeof(SecretsCollectionModel),
        typeof(TemplateModel),
        typeof(TrafficWeightModel),
    };
}
