using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerApps;

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
        new ListCustomHostNameAnalysisOperation(),
        new ListSecretsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActiveRevisionsModeConstant),
        typeof(AppProtocolConstant),
        typeof(BindingTypeConstant),
        typeof(ContainerAppProvisioningStateConstant),
        typeof(DnsVerificationTestResultConstant),
        typeof(IngressTransportMethodConstant),
        typeof(SchemeConstant),
        typeof(StorageTypeConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigurationModel),
        typeof(ContainerModel),
        typeof(ContainerAppModel),
        typeof(ContainerAppProbeModel),
        typeof(ContainerAppProbeHTTPGetModel),
        typeof(ContainerAppProbeHTTPGetHTTPHeadersInlinedModel),
        typeof(ContainerAppProbeTcpSocketModel),
        typeof(ContainerAppPropertiesModel),
        typeof(ContainerAppSecretModel),
        typeof(ContainerResourcesModel),
        typeof(CustomDomainModel),
        typeof(CustomHostnameAnalysisResultModel),
        typeof(CustomHostnameAnalysisResultCustomDomainVerificationFailureInfoModel),
        typeof(CustomHostnameAnalysisResultCustomDomainVerificationFailureInfoDetailsInlinedModel),
        typeof(CustomScaleRuleModel),
        typeof(DaprModel),
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
        typeof(VolumeModel),
        typeof(VolumeMountModel),
    };
}
