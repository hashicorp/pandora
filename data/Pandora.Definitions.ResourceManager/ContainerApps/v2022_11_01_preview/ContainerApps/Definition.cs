using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ContainerApps;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerApps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DiagnosticsGetDetectorOperation(),
        new DiagnosticsGetRevisionOperation(),
        new DiagnosticsGetRootOperation(),
        new DiagnosticsListDetectorsOperation(),
        new DiagnosticsListRevisionsOperation(),
        new GetOperation(),
        new GetAuthTokenOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListCustomHostNameAnalysisOperation(),
        new ListSecretsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionConstant),
        typeof(ActiveRevisionsModeConstant),
        typeof(AffinityConstant),
        typeof(AppProtocolConstant),
        typeof(BindingTypeConstant),
        typeof(ContainerAppProvisioningStateConstant),
        typeof(DnsVerificationTestResultConstant),
        typeof(ExtendedLocationTypesConstant),
        typeof(IngressClientCertificateModeConstant),
        typeof(IngressTransportMethodConstant),
        typeof(LogLevelConstant),
        typeof(RevisionHealthStateConstant),
        typeof(RevisionProvisioningStateConstant),
        typeof(SchemeConstant),
        typeof(StorageTypeConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BaseContainerModel),
        typeof(ConfigurationModel),
        typeof(ContainerModel),
        typeof(ContainerAppModel),
        typeof(ContainerAppAuthTokenModel),
        typeof(ContainerAppAuthTokenPropertiesModel),
        typeof(ContainerAppProbeModel),
        typeof(ContainerAppProbeHTTPGetModel),
        typeof(ContainerAppProbeHTTPGetHTTPHeadersInlinedModel),
        typeof(ContainerAppProbeTcpSocketModel),
        typeof(ContainerAppPropertiesModel),
        typeof(ContainerAppSecretModel),
        typeof(ContainerResourcesModel),
        typeof(CorsPolicyModel),
        typeof(CustomDomainModel),
        typeof(CustomHostnameAnalysisResultModel),
        typeof(CustomHostnameAnalysisResultCustomDomainVerificationFailureInfoModel),
        typeof(CustomHostnameAnalysisResultCustomDomainVerificationFailureInfoDetailsInlinedModel),
        typeof(CustomScaleRuleModel),
        typeof(DaprModel),
        typeof(DiagnosticDataProviderMetadataModel),
        typeof(DiagnosticDataProviderMetadataPropertyBagInlinedModel),
        typeof(DiagnosticDataTableResponseColumnModel),
        typeof(DiagnosticDataTableResponseObjectModel),
        typeof(DiagnosticRenderingModel),
        typeof(DiagnosticSupportTopicModel),
        typeof(DiagnosticsModel),
        typeof(DiagnosticsDataApiResponseModel),
        typeof(DiagnosticsDefinitionModel),
        typeof(DiagnosticsPropertiesModel),
        typeof(DiagnosticsStatusModel),
        typeof(EnvironmentVarModel),
        typeof(ExtendedLocationModel),
        typeof(HTTPScaleRuleModel),
        typeof(IPSecurityRestrictionRuleModel),
        typeof(IngressModel),
        typeof(IngressStickySessionsModel),
        typeof(QueueScaleRuleModel),
        typeof(RegistryCredentialsModel),
        typeof(RevisionModel),
        typeof(RevisionPropertiesModel),
        typeof(ScaleModel),
        typeof(ScaleRuleModel),
        typeof(ScaleRuleAuthModel),
        typeof(SecretModel),
        typeof(SecretVolumeItemModel),
        typeof(SecretsCollectionModel),
        typeof(TcpScaleRuleModel),
        typeof(TemplateModel),
        typeof(TrafficWeightModel),
        typeof(VolumeModel),
        typeof(VolumeMountModel),
    };
}
