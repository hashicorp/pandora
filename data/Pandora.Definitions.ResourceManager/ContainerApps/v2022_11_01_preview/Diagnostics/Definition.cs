using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.Diagnostics;

internal class Definition : ResourceDefinition
{
    public string Name => "Diagnostics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContainerAppsDiagnosticsGetDetectorOperation(),
        new ContainerAppsDiagnosticsGetRevisionOperation(),
        new ContainerAppsDiagnosticsGetRootOperation(),
        new ContainerAppsDiagnosticsListDetectorsOperation(),
        new ContainerAppsDiagnosticsListRevisionsOperation(),
        new ManagedEnvironmentDiagnosticsGetDetectorOperation(),
        new ManagedEnvironmentDiagnosticsListDetectorsOperation(),
        new ManagedEnvironmentsDiagnosticsGetRootOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionConstant),
        typeof(ActiveRevisionsModeConstant),
        typeof(AffinityConstant),
        typeof(AppProtocolConstant),
        typeof(BindingTypeConstant),
        typeof(ContainerAppProvisioningStateConstant),
        typeof(EnvironmentProvisioningStateConstant),
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
        typeof(AppLogsConfigurationModel),
        typeof(BaseContainerModel),
        typeof(ConfigurationModel),
        typeof(ContainerModel),
        typeof(ContainerAppModel),
        typeof(ContainerAppProbeModel),
        typeof(ContainerAppProbeHTTPGetModel),
        typeof(ContainerAppProbeHTTPGetHTTPHeadersInlinedModel),
        typeof(ContainerAppProbeTcpSocketModel),
        typeof(ContainerAppPropertiesModel),
        typeof(ContainerResourcesModel),
        typeof(CorsPolicyModel),
        typeof(CustomDomainModel),
        typeof(CustomDomainConfigurationModel),
        typeof(CustomScaleRuleModel),
        typeof(DaprModel),
        typeof(DaprConfigurationModel),
        typeof(DiagnosticDataProviderMetadataModel),
        typeof(DiagnosticDataProviderMetadataPropertyBagInlinedModel),
        typeof(DiagnosticDataTableResponseColumnModel),
        typeof(DiagnosticDataTableResponseObjectModel),
        typeof(DiagnosticRenderingModel),
        typeof(DiagnosticSupportTopicModel),
        typeof(DiagnosticsModel),
        typeof(DiagnosticsCollectionModel),
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
        typeof(KedaConfigurationModel),
        typeof(LogAnalyticsConfigurationModel),
        typeof(ManagedEnvironmentModel),
        typeof(ManagedEnvironmentPropertiesModel),
        typeof(QueueScaleRuleModel),
        typeof(RegistryCredentialsModel),
        typeof(RevisionModel),
        typeof(RevisionPropertiesModel),
        typeof(ScaleModel),
        typeof(ScaleRuleModel),
        typeof(ScaleRuleAuthModel),
        typeof(SecretModel),
        typeof(SecretVolumeItemModel),
        typeof(TcpScaleRuleModel),
        typeof(TemplateModel),
        typeof(TrafficWeightModel),
        typeof(VnetConfigurationModel),
        typeof(VolumeModel),
        typeof(VolumeMountModel),
        typeof(WorkloadProfileModel),
    };
}
