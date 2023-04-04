using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ManagedEnvironments;

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
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new NamespacesCheckNameAvailabilityOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CertificateProvisioningStateConstant),
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(EnvironmentProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppLogsConfigurationModel),
        typeof(CertificateModel),
        typeof(CertificatePatchModel),
        typeof(CertificatePropertiesModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(LogAnalyticsConfigurationModel),
        typeof(ManagedEnvironmentModel),
        typeof(ManagedEnvironmentPropertiesModel),
        typeof(VnetConfigurationModel),
    };
}
