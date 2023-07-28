using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ManagedEnvironments;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedEnvironments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CertificatesCreateOrUpdateOperation(),
        new CertificatesDeleteOperation(),
        new CertificatesGetOperation(),
        new CertificatesListOperation(),
        new CertificatesUpdateOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DiagnosticsGetRootOperation(),
        new GetOperation(),
        new GetAuthTokenOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListWorkloadProfileStatesOperation(),
        new ManagedCertificatesCreateOrUpdateOperation(),
        new ManagedCertificatesDeleteOperation(),
        new ManagedCertificatesGetOperation(),
        new ManagedCertificatesListOperation(),
        new ManagedCertificatesUpdateOperation(),
        new ManagedEnvironmentDiagnosticsGetDetectorOperation(),
        new ManagedEnvironmentDiagnosticsListDetectorsOperation(),
        new NamespacesCheckNameAvailabilityOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CertificateProvisioningStateConstant),
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(EnvironmentProvisioningStateConstant),
        typeof(ManagedCertificateDomainControlValidationConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppLogsConfigurationModel),
        typeof(CertificateModel),
        typeof(CertificatePatchModel),
        typeof(CertificatePropertiesModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(CustomDomainConfigurationModel),
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
        typeof(EnvironmentAuthTokenModel),
        typeof(EnvironmentAuthTokenPropertiesModel),
        typeof(KedaConfigurationModel),
        typeof(LogAnalyticsConfigurationModel),
        typeof(ManagedCertificateModel),
        typeof(ManagedCertificatePatchModel),
        typeof(ManagedCertificatePropertiesModel),
        typeof(ManagedEnvironmentModel),
        typeof(ManagedEnvironmentPropertiesModel),
        typeof(VnetConfigurationModel),
        typeof(WorkloadProfileModel),
        typeof(WorkloadProfileStatesModel),
        typeof(WorkloadProfileStatesPropertiesModel),
    };
}
