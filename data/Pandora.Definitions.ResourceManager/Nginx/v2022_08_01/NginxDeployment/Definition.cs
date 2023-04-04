using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxDeployment;

internal class Definition : ResourceDefinition
{
    public string Name => "NginxDeployment";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeploymentsCreateOrUpdateOperation(),
        new DeploymentsDeleteOperation(),
        new DeploymentsGetOperation(),
        new DeploymentsListOperation(),
        new DeploymentsListByResourceGroupOperation(),
        new DeploymentsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NginxPrivateIPAllocationMethodConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NginxDeploymentModel),
        typeof(NginxDeploymentPropertiesModel),
        typeof(NginxDeploymentUpdateParametersModel),
        typeof(NginxDeploymentUpdatePropertiesModel),
        typeof(NginxFrontendIPConfigurationModel),
        typeof(NginxLoggingModel),
        typeof(NginxNetworkInterfaceConfigurationModel),
        typeof(NginxNetworkProfileModel),
        typeof(NginxPrivateIPAddressModel),
        typeof(NginxPublicIPAddressModel),
        typeof(NginxStorageAccountModel),
        typeof(ResourceSkuModel),
    };
}
