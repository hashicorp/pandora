using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.NodeType;

internal class Definition : ResourceDefinition
{
    public string Name => "NodeType";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DeleteNodeOperation(),
        new GetOperation(),
        new ListByManagedClustersOperation(),
        new ReimageOperation(),
        new RestartOperation(),
        new SkusListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessConstant),
        typeof(DirectionConstant),
        typeof(DiskTypeConstant),
        typeof(IPAddressTypeConstant),
        typeof(ManagedResourceProvisioningStateConstant),
        typeof(NodeTypeSkuScaleTypeConstant),
        typeof(NsgProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EndpointRangeDescriptionModel),
        typeof(FrontendConfigurationModel),
        typeof(NetworkSecurityRuleModel),
        typeof(NodeTypeModel),
        typeof(NodeTypeActionParametersModel),
        typeof(NodeTypeAvailableSkuModel),
        typeof(NodeTypePropertiesModel),
        typeof(NodeTypeSkuModel),
        typeof(NodeTypeSkuCapacityModel),
        typeof(NodeTypeSupportedSkuModel),
        typeof(NodeTypeUpdateParametersModel),
        typeof(SubResourceModel),
        typeof(SystemDataModel),
        typeof(VMSSDataDiskModel),
        typeof(VMSSExtensionModel),
        typeof(VMSSExtensionPropertiesModel),
        typeof(VaultCertificateModel),
        typeof(VaultSecretGroupModel),
    };
}
