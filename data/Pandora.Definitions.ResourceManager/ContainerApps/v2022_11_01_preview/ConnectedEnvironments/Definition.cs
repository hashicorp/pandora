using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ConnectedEnvironments;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectedEnvironments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CertificatesCreateOrUpdateOperation(),
        new CertificatesDeleteOperation(),
        new CertificatesGetOperation(),
        new CertificatesListOperation(),
        new CertificatesUpdateOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CertificateProvisioningStateConstant),
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(ConnectedEnvironmentProvisioningStateConstant),
        typeof(ExtendedLocationTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CertificateModel),
        typeof(CertificatePatchModel),
        typeof(CertificatePropertiesModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(ConnectedEnvironmentModel),
        typeof(ConnectedEnvironmentPropertiesModel),
        typeof(CustomDomainConfigurationModel),
        typeof(ExtendedLocationModel),
    };
}
