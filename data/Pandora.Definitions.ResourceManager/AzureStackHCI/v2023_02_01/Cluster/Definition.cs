using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.Cluster;

internal class Definition : ResourceDefinition
{
    public string Name => "Cluster";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityOperation(),
        new ExtendSoftwareAssuranceBenefitOperation(),
        new UploadCertificateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClusterNodeTypeConstant),
        typeof(DiagnosticLevelConstant),
        typeof(ImdsAttestationConstant),
        typeof(ProvisioningStateConstant),
        typeof(SoftwareAssuranceIntentConstant),
        typeof(SoftwareAssuranceStatusConstant),
        typeof(StatusConstant),
        typeof(WindowsServerSubscriptionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterModel),
        typeof(ClusterDesiredPropertiesModel),
        typeof(ClusterIdentityResponseModel),
        typeof(ClusterIdentityResponsePropertiesModel),
        typeof(ClusterNodeModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterReportedPropertiesModel),
        typeof(RawCertificateDataModel),
        typeof(SoftwareAssuranceChangeRequestModel),
        typeof(SoftwareAssuranceChangeRequestPropertiesModel),
        typeof(SoftwareAssurancePropertiesModel),
        typeof(UploadCertificateRequestModel),
    };
}
